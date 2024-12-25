using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Pour utiliser Include
using TestHotelReservation.Models;
using System.Linq;

namespace TestHotelReservation.Controllers
{
    public class ChambreController : Controller
    {
        private readonly LoginAppContext _context;

        public ChambreController(LoginAppContext context)
        {
            _context = context;
        }

        // Action pour afficher les chambres disponibles
        public IActionResult Index()
        {
            // Inclure le TypeChambre pour chaque chambre
            var chambresDisponibles = _context.Chambres
                .Include(c => c.TypeChambre) // Charger les informations sur le TypeChambre
                .Where(c => c.EstDisponible == true) // Filtrer par chambres disponibles
                .ToList();

            return View(chambresDisponibles);
        }

        // Action pour réserver une chambre
        [HttpPost]
        [HttpPost]
        public IActionResult Reserver(int chambreId)
        {
            var chambre = _context.Chambres.FirstOrDefault(c => c.ChambreId == chambreId);

            if (chambre != null && chambre.EstDisponible == true)
            {
                // Assurez-vous que le client est connecté (si un client est déjà logué)
                var clientId = HttpContext.Session.GetInt32("ClientId"); // Exemple de récupération du client connecté
                if (clientId == null)
                {
                    return RedirectToAction("Login", "Client"); // Rediriger si le client n'est pas connecté
                }

                // Créez une réservation pour cette chambre
                var reservation = new Reservation
                {
                    ChambreId = chambreId,
                    ClientId = clientId.Value,
                };

                _context.Reservations.Add(reservation);
                chambre.EstDisponible = false; // La chambre devient indisponible après la réservation
                _context.SaveChanges();

                // Créez une notification pour l'admin
                var notification = new Notification
                {
                    UtilisateurId = clientId.Value,
                    TypeUtilisateur = "Client",
                    Message = $"Une nouvelle réservation a été effectuée pour la chambre numéro {chambre.NumeroChambre}.",
                    DateEnvoi = DateTime.Now,
                    EstLu = false // Non lu (utiliser false pour un bool)
                };
                _context.Notifications.Add(notification);
                _context.SaveChanges();

                return RedirectToAction("Confirmation", new { chambreId = chambreId });
            }

            return RedirectToAction("Index");
        }



        public IActionResult Confirmation(int chambreId)
        {
            var chambre = _context.Chambres
                .Include(c => c.TypeChambre) // Charger TypeChambre lors de la récupération de la chambre
                .FirstOrDefault(c => c.ChambreId == chambreId);

            if (chambre == null)
            {
                // Gestion du cas où la chambre n'existe pas
                return NotFound();
            }

            return View(chambre);
        }
    }
}
