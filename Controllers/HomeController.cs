// ============================================
// FICHIER : Controllers/HomeController.cs
// DESCRIPTION : Contrôleur pour la page d'accueil
// ============================================

using Microsoft.AspNetCore.Mvc;

namespace GestSoutenance.Controllers
{
    /// <summary>
    /// Ce contrôleur gère la page d'accueil de l'application
    /// </summary>
    public class HomeController : Controller
    {
        // ========================================
        // INDEX - Page d'accueil
        // URL : / ou /Home ou /Home/Index
        // ========================================
        public IActionResult Index()
        {
            return View();
        }
    }
}
