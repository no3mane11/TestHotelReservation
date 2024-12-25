using System;
using System.Collections.Generic;

namespace TestHotelReservation.Models;

public partial class Paiement
{
    public int PaiementId { get; set; }

    public decimal Montant { get; set; }

    public DateTime DatePaiement { get; set; }

    public string ModePaiement { get; set; } = null!;

    public int? ReservationId { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
