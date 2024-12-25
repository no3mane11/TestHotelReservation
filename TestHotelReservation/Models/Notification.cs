using System;
using System.Collections.Generic;

namespace TestHotelReservation.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int? UtilisateurId { get; set; }

    public string? TypeUtilisateur { get; set; }

    public string Message { get; set; } = null!;

    public DateTime DateEnvoi { get; set; }

    public bool EstLu { get; set; }
}
