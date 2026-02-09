// ============================================
// FICHIER : Controllers/PFE_EtudiantController.cs
// DESCRIPTION : Contrôleur CRUD pour l'association PFE-Etudiant
// ============================================

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestSoutenance.Data;
using GestSoutenance.Models;

namespace GestSoutenance.Controllers
{
    /// <summary>
    /// Ce contrôleur gère l'association entre les PFE et les Étudiants
    /// Il permet d'affecter des étudiants à des PFE
    /// </summary>
    public class PFE_EtudiantController : Controller
    {
        // Le contexte de base de données
        private readonly SoutenanceContext _context;

        // Constructeur avec injection de dépendances
        public PFE_EtudiantController(SoutenanceContext context)
        {
            _context = context;
        }

        // ========================================
        // INDEX - Liste des associations PFE-Étudiant
        // ========================================
        public IActionResult Index()
        {
            // Récupérer toutes les associations avec les données liées
            var liste = _context.PFE_Etudiants
                .Include(pe => pe.PFE)        // Charger le PFE
                .Include(pe => pe.Etudiant)   // Charger l'étudiant
                .ToList();

            return View(liste);
        }

        // ========================================
        // DETAILS - Afficher une association
        // ========================================
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfeEtudiant = _context.PFE_Etudiants
                .Include(pe => pe.PFE)
                .Include(pe => pe.Etudiant)
                .FirstOrDefault(pe => pe.ID == id);

            if (pfeEtudiant == null)
            {
                return NotFound();
            }

            return View(pfeEtudiant);
        }

        // ========================================
        // CREATE GET - Formulaire d'affectation
        // ========================================
        public IActionResult Create()
        {
            ChargerListesDeroulantes();
            return View();
        }

        // ========================================
        // CREATE POST - Enregistrer l'affectation
        // ========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PFE_Etudiant pfeEtudiant)
        {
            if (ModelState.IsValid)
            {
                _context.PFE_Etudiants.Add(pfeEtudiant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ChargerListesDeroulantes();
            return View(pfeEtudiant);
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

            var pfeEtudiant = _context.PFE_Etudiants.Find(id);

            if (pfeEtudiant == null)
            {
                return NotFound();
            }

            ChargerListesDeroulantes(pfeEtudiant.PFEID, pfeEtudiant.EtudiantId);
            return View(pfeEtudiant);
        }

        // ========================================
        // EDIT POST - Enregistrer les modifications
        // ========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PFE_Etudiant pfeEtudiant)
        {
            if (id != pfeEtudiant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.PFE_Etudiants.Update(pfeEtudiant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ChargerListesDeroulantes(pfeEtudiant.PFEID, pfeEtudiant.EtudiantId);
            return View(pfeEtudiant);
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

            var pfeEtudiant = _context.PFE_Etudiants
                .Include(pe => pe.PFE)
                .Include(pe => pe.Etudiant)
                .FirstOrDefault(pe => pe.ID == id);

            if (pfeEtudiant == null)
            {
                return NotFound();
            }

            return View(pfeEtudiant);
        }

        // ========================================
        // DELETE POST - Confirmer la suppression
        // ========================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pfeEtudiant = _context.PFE_Etudiants.Find(id);

            if (pfeEtudiant != null)
            {
                _context.PFE_Etudiants.Remove(pfeEtudiant);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // ========================================
        // MÉTHODE PRIVÉE - Charger les listes déroulantes
        // ========================================
        private void ChargerListesDeroulantes(int? pfeId = null, int? etudiantId = null)
        {
            // Liste des PFE
            ViewBag.PFEID = new SelectList(
                _context.PFEs.ToList(),
                "PFEID",
                "Titre",
                pfeId
            );

            // Liste des étudiants
            ViewBag.EtudiantId = new SelectList(
                _context.Etudiants.ToList(),
                "ID",
                "NomComplet",
                etudiantId
            );
        }
    }
}
