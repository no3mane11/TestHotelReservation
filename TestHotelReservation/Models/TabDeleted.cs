using System;
using System.Collections.Generic;

namespace TestHotelReservation.Models;

public partial class TabDeleted
{
    public int ReservationId { get; set; }

    public int ClientId { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public string EtatReservation { get; set; } = null!;

    public DateTime DateCreation { get; set; }
}
