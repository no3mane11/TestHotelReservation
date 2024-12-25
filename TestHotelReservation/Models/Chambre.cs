using System;
using System.Collections.Generic;

namespace TestHotelReservation.Models;
public partial class Chambre
{
    public int ChambreId { get; set; }

    public string NumeroChambre { get; set; } = null!;

    public int TypeChambreId { get; set; }

    public bool? EstDisponible { get; set; }

    // Nouvelle propriété ImageChambre
    public string ImageChambre { get; set; } = null!;  // Utilisez byte[] si vous préférez stocker les données binaires de l'image

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    public virtual TypeChambre TypeChambre { get; set; } = null!;
}
