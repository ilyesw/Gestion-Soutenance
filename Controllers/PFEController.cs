// ============================================
// FICHIER : Controllers/PFEController.cs
// DESCRIPTION : Contrôleur CRUD pour gérer les PFE
// ============================================

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestSoutenance.Data;
using GestSoutenance.Models;

namespace GestSoutenance.Controllers
{
    /// <summary>
    /// Ce contrôleur gère toutes les opérations CRUD pour les PFE
    /// Le PFE a des relations avec Enseignant (encadrant) et Societe
    /// </summary>
    public class PFEController : Controller
    {
        // Le contexte de base de données
        private readonly SoutenanceContext _context;

        // Constructeur avec injection de dépendances
        public PFEController(SoutenanceContext context)
        {
            _context = context;
        }

        // ========================================
        // INDEX - Liste des PFE
        // ========================================
        public IActionResult Index()
        {
            // Récupérer tous les PFE avec leurs relations (Encadrant et Société)
            // Include() charge les données liées (évite les valeurs null)
            var listePFE = _context.PFEs
                .Include(p => p.Encadrant)  // Charger l'enseignant encadrant
                .Include(p => p.Societe)    // Charger la société
                .ToList();

            return View(listePFE);
        }

        // ========================================
        // DETAILS - Afficher un PFE
        // ========================================
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Charger le PFE avec ses relations
            var pfe = _context.PFEs
                .Include(p => p.Encadrant)
                .Include(p => p.Societe)
                .FirstOrDefault(p => p.PFEID == id);

            if (pfe == null)
            {
                return NotFound();
            }

            return View(pfe);
        }

        // ========================================
        // CREATE GET - Formulaire de création
        // ========================================
        public IActionResult Create()
        {
            // Préparer les listes déroulantes pour le formulaire
            // ViewBag permet de passer des données à la vue
            ChargerListesDeroulantes();
            return View();
        }

        // ========================================
        // CREATE POST - Enregistrer le nouveau PFE
        // ========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PFE pfe)
        {
            if (ModelState.IsValid)
            {
                _context.PFEs.Add(pfe);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Si erreur, recharger les listes déroulantes
            ChargerListesDeroulantes();
            return View(pfe);
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

            var pfe = _context.PFEs.Find(id);

            if (pfe == null)
            {
                return NotFound();
            }

            // Charger les listes déroulantes avec les valeurs actuelles
            ChargerListesDeroulantes(pfe.EncadrantID, pfe.SocieteID);
            return View(pfe);
        }

        // ========================================
        // EDIT POST - Enregistrer les modifications
        // ========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PFE pfe)
        {
            if (id != pfe.PFEID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.PFEs.Update(pfe);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ChargerListesDeroulantes(pfe.EncadrantID, pfe.SocieteID);
            return View(pfe);
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

            var pfe = _context.PFEs
                .Include(p => p.Encadrant)
                .Include(p => p.Societe)
                .FirstOrDefault(p => p.PFEID == id);

            if (pfe == null)
            {
                return NotFound();
            }

            return View(pfe);
        }

        // ========================================
        // DELETE POST - Confirmer la suppression
        // ========================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pfe = _context.PFEs.Find(id);

            if (pfe != null)
            {
                _context.PFEs.Remove(pfe);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // ========================================
        // MÉTHODE PRIVÉE - Charger les listes déroulantes
        // ========================================

        // Cette méthode prépare les listes déroulantes pour les formulaires
        // Elle est appelée par Create et Edit
        private void ChargerListesDeroulantes(int? encadrantId = null, int? societeId = null)
        {
            // Liste des enseignants pour le menu déroulant "Encadrant"
            // SelectList crée une liste d'options pour un <select>
            // Paramètres: (données, valeur, texte affiché, valeur sélectionnée)
            ViewBag.EncadrantID = new SelectList(
                _context.Enseignants.ToList(),  // Les données
                "ID",                            // La valeur (attribut value)
                "NomComplet",                    // Le texte affiché
                encadrantId                      // La valeur actuellement sélectionnée
            );

            // Liste des sociétés pour le menu déroulant "Société"
            ViewBag.SocieteID = new SelectList(
                _context.Societes.ToList(),
                "ID",
                "Lib",
                societeId
            );
        }
    }
}
