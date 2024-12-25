using System;
using System.Collections.Generic;

namespace TestHotelReservation.Models;

public partial class Employe
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Telephone { get; set; }

    public string? Role { get; set; }

    public DateTime? DateEmbauche { get; set; }

    public bool? Actif { get; set; }

    public string? Prenom { get; set; }

    public virtual ICollection<HistoriqueExport> HistoriqueExports { get; } = new List<HistoriqueExport>();
}
