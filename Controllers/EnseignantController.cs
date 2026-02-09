// ============================================
// FICHIER : Controllers/EnseignantController.cs
// DESCRIPTION : Contrôleur CRUD pour gérer les enseignants
// ============================================

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestSoutenance.Data;
using GestSoutenance.Models;

namespace GestSoutenance.Controllers
{
    /// <summary>
    /// Ce contrôleur gère toutes les opérations CRUD pour les Enseignants
    /// </summary>
    public class EnseignantController : Controller
    {
        // Le contexte de base de données
        private readonly SoutenanceContext _context;

        // Constructeur avec injection de dépendances
        public EnseignantController(SoutenanceContext context)
        {
            _context = context;
        }

        // ========================================
        // INDEX - Liste des enseignants
        // ========================================
        public IActionResult Index()
        {
            // Récupérer tous les enseignants
            var listeEnseignants = _context.Enseignants.ToList();
            return View(listeEnseignants);
        }

        // ========================================
        // DETAILS - Afficher un enseignant
        // ========================================
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignant = _context.Enseignants.Find(id);

            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // ========================================
        // CREATE GET - Formulaire de création
        // ========================================
        public IActionResult Create()
        {
            return View();
        }

        // ========================================
        // CREATE POST - Enregistrer le nouvel enseignant
        // ========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                _context.Enseignants.Add(enseignant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enseignant);
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

            var enseignant = _context.Enseignants.Find(id);

            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // ========================================
        // EDIT POST - Enregistrer les modifications
        // ========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Enseignant enseignant)
        {
            if (id != enseignant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Enseignants.Update(enseignant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enseignant);
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

            var enseignant = _context.Enseignants.Find(id);

            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // ========================================
        // DELETE POST - Confirmer la suppression
        // ========================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var enseignant = _context.Enseignants.Find(id);

            if (enseignant != null)
            {
                _context.Enseignants.Remove(enseignant);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
