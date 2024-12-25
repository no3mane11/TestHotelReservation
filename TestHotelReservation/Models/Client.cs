using System;
using System.Collections.Generic;

namespace TestHotelReservation.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telephone { get; set; }

    public string MotDePasse { get; set; } = null!;

    public string? Adresse { get; set; }

    public DateTime DateInscription { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
