﻿using Domain.Entities.Abstractions;

namespace Domain.Entities;

public partial class Reservation : IEntity
{
    public int ChargerId { get; set; }

    public Guid UserId { get; set; }

    public Guid Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal? TotalAmount { get; set; }

    /// <summary>
    /// Navigational properties />
    /// </summary>

    public virtual Charger Charger { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
