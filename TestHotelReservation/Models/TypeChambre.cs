using System;
using System.Collections.Generic;

namespace TestHotelReservation.Models;

public partial class TypeChambre
{
    public int TypeChambreId { get; set; }

    public string Nom { get; set; } = null!;

    public string? Description { get; set; }

    public decimal TarifParNuit { get; set; }

    public virtual ICollection<Chambre> Chambres { get; } = new List<Chambre>();
}
