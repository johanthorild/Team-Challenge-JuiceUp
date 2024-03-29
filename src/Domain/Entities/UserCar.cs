﻿using Domain.Entities.Abstractions;

namespace Domain.Entities;

public partial class UserCar : IEntity
{
    public int CarId { get; set; }

    public Guid UserId { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Navigational properties />
    /// </summary>

    public virtual CarModel Car { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
