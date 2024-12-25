using System;
using System.Collections.Generic;

namespace TestHotelReservation.Models;

public partial class HistoriqueExport
{
    public int ExportId { get; set; }

    public int Id { get; set; }

    public string TypeFichier { get; set; } = null!;

    public DateTime DateExport { get; set; }

    public string CheminFichier { get; set; } = null!;

    public virtual Employe IdNavigation { get; set; } = null!;
}
