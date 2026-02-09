// ============================================
// FICHIER : Controllers/SocieteController.cs
// DESCRIPTION : Contrôleur CRUD pour gérer les sociétés
// ============================================

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestSoutenance.Data;
using GestSoutenance.Models;

namespace GestSoutenance.Controllers
{
    /// <summary>
    /// Ce contrôleur gère toutes les opérations CRUD pour les Sociétés
    /// </summary>
    public class SocieteController : Controller
    {
        // Le contexte de base de données
        private readonly SoutenanceContext _context;

        // Constructeur avec injection de dépendances
        public SocieteController(SoutenanceContext context)
        {
            _context = context;
        }

        // ========================================
        // INDEX - Liste des sociétés
        // ========================================
        public IActionResult Index()
        {
            // Récupérer toutes les sociétés
            var listeSocietes = _context.Societes.ToList();
            return View(listeSocietes);
        }

        // ========================================
        // DETAILS - Afficher une société
        // ========================================
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var societe = _context.Societes.Find(id);

            if (societe == null)
            {
                return NotFound();
            }

            return View(societe);
        }

        // ========================================
        // CREATE GET - Formulaire de création
        // ========================================
        public IActionResult Create()
        {
            return View();
        }

        // ========================================
        // CREATE POST - Enregistrer la nouvelle société
        // ========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Societe societe)
        {
            if (ModelState.IsValid)
            {
                _context.Societes.Add(societe);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(societe);
        }

        // ========================================
        // EDIT GET - Formulaire de modification
        // ========================================
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var societe = _context.Societes.Find(id);

            if (societe == null)
            {
                return NotFound();
            }

            return View(societe);
        }

        // ========================================
        // EDIT POST - Enregistrer les modifications
        // ========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Societe societe)
        {
            if (id != societe.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Societes.Update(societe);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(societe);
        }

        // ========================================
        // DELETE GET - Page de confirmation
        // ========================================
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var societe = _context.Societes.Find(id);

            if (societe == null)
            {
                return NotFound();
            }

            return View(societe);
        }

        // ========================================
        // DELETE POST - Confirmer la suppression
        // ========================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var societe = _context.Societes.Find(id);

            if (societe != null)
            {
                _context.Societes.Remove(societe);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
