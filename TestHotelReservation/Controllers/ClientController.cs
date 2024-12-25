using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Nécessaire pour les sessions
using TestHotelReservation.Models;
using System.Linq; // Nécessaire pour LINQ (FirstOrDefault)

namespace TestHotelReservation.Controllers
{
    public class ClientController : Controller
    {
        private readonly LoginAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Injecter IHttpContextAccessor
        public ClientController(LoginAppContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public IActionResult Register(Client client)
        {
            if (ModelState.IsValid)
            {
                client.DateInscription = DateTime.Now;

                _context.Clients.Add(client);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(client);
        }

        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(string email, string motDePasse)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(motDePasse))
            {
                ViewBag.Message = "Veuillez saisir un email et un mot de passe.";
                return View();
            }

            var client = _context.Clients.FirstOrDefault(c => c.Email == email && c.MotDePasse == motDePasse);

            if (client != null)
            {
                // Stocker les informations dans la session via IHttpContextAccessor
                _httpContextAccessor.HttpContext.Session.SetString("ClientEmail", client.Email);
                _httpContextAccessor.HttpContext.Session.SetInt32("ClientId", client.ClientId);
                _httpContextAccessor.HttpContext.Session.SetString("ClientName", client.Nom);

                // Rediriger vers la page d'accueil ou tableau de bord
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Email ou mot de passe incorrect.";
            return View();
        }

        // Exemple de méthode pour afficher le nom du client dans la vue _Layout.cshtml
        public string GetClientName()
        {
            // Vérifiez si le nom du client est dans la session
            var clientName = _httpContextAccessor.HttpContext.Session.GetString("ClientName");

            return !string.IsNullOrEmpty(clientName) ? clientName : "Invité";
        }
    }
}
