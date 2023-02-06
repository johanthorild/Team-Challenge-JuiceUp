﻿using Application.Helpers;
using Application.Providers;

using Domain;
using Domain.Entities;
using Domain.Repositories;

using MediatR;

namespace Application.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextUserProvider _httpContextUserProvider;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IHttpContextUserProvider httpContextUserProvider,
        IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _httpContextUserProvider = httpContextUserProvider;
        _userRepository = userRepository;
    }

    public async Task<User> Handle(
        UpdateUserCommand command,
        CancellationToken cancellationToken)
    {
        // Only admins and the user itself can update the user
        if (command.Email != _httpContextUserProvider.Email && !_httpContextUserProvider.IsAdmin)
            throw new NotImplementedException(nameof(UpdateUserCommand));

        // Get existing user
        var existing = await _userRepository.GetById(command.Id);
        if (existing is null)
            throw new NotImplementedException(nameof(UpdateUserCommand));

        // Update Email (username)
        if (existing.Email != command.Email)
        {
            var existingEmail = await _userRepository.GetByEmail(command.Email);
            if (existingEmail != null)
                throw new NotImplementedException(nameof(UpdateUserCommand));

            existing.UpdateEmail(command.Email);
        }

        // Update Names
        if (existing.Firstname != command.Firstname)
            existing.UpdateFirstname(command.Firstname);
        if (existing.Lastname != command.Lastname)
            existing.UpdateLastname(command.Lastname);

        // Update Password
        if (!string.IsNullOrEmpty(command.PasswordBase64) &&
            !PasswordHelper.VerifyPassword(command.PasswordBase64, existing.Password, existing.Salt))
        {
            var (salt, hashedPassword) = PasswordHelper.GenerateHashedPasswordWithSalt(command.PasswordBase64);
            existing.UpdatePassword(hashedPassword, salt);
        }

        _userRepository.Update(existing);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new User(existing.Id);
    }
}
