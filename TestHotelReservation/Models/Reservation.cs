using System;
using System.Collections.Generic;

namespace TestHotelReservation.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int ClientId { get; set; }

    public int ChambreId { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public decimal TarifParNuit { get; set; }

    public string EtatReservation { get; set; } = null!;

    public DateTime DateCreation { get; set; }

    public virtual Chambre Chambre { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Paiement> Paiements { get; } = new List<Paiement>();
}
