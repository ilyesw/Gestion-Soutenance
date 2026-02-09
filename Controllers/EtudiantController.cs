// ============================================
// FICHIER : Controllers/EtudiantController.cs
// DESCRIPTION : Contrôleur CRUD pour gérer les étudiants
// ============================================

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestSoutenance.Data;
using GestSoutenance.Models;

namespace GestSoutenance.Controllers
{
    /// <summary>
    /// Ce contrôleur gère toutes les opérations CRUD pour les Étudiants
    /// CRUD = Create (Créer), Read (Lire), Update (Modifier), Delete (Supprimer)
    /// </summary>
    public class EtudiantController : Controller
    {
        // ========================================
        // CHAMPS PRIVÉS
        // ========================================

        // Le contexte de base de données pour accéder aux données
        private readonly SoutenanceContext _context;

        // ========================================
        // CONSTRUCTEUR
        // ========================================

        // Le constructeur reçoit le contexte par injection de dépendances
        // Cela permet d'accéder à la base de données
        public EtudiantController(SoutenanceContext context)
        {
            _context = context;
        }

        // ========================================
        // ACTION : INDEX (Liste des étudiants)
        // URL : /Etudiant ou /Etudiant/Index
        // ========================================

        // Cette action affiche la liste de tous les étudiants
        public IActionResult Index()
        {
            // On récupère tous les étudiants de la base de données
            // ToList() exécute la requête et retourne une liste
            var listeEtudiants = _context.Etudiants.ToList();

            // On passe la liste à la vue pour l'afficher
            return View(listeEtudiants);
        }

        // ========================================
        // ACTION : DETAILS (Détails d'un étudiant)
        // URL : /Etudiant/Details/5
        // ========================================

        // Cette action affiche les détails d'un étudiant spécifique
        // Le paramètre 'id' vient de l'URL (ex: /Etudiant/Details/5)
        public IActionResult Details(int? id)
        {
            // Vérifier si l'ID est fourni
            if (id == null)
            {
                // Si pas d'ID, retourner une erreur 404 (Non trouvé)
                return NotFound();
            }

            // Chercher l'étudiant avec cet ID
            var etudiant = _context.Etudiants.Find(id);

            // Vérifier si l'étudiant existe
            if (etudiant == null)
            {
                return NotFound();
            }

            // Afficher la vue avec les détails de l'étudiant
            return View(etudiant);
        }

        // ========================================
        // ACTION : CREATE GET (Afficher le formulaire)
        // URL : /Etudiant/Create
        // ========================================

        // Cette action affiche le formulaire vide pour créer un étudiant
        // [HttpGet] est implicite - c'est la méthode par défaut
        public IActionResult Create()
        {
            // Afficher le formulaire vide
            return View();
        }

        // ========================================
        // ACTION : CREATE POST (Enregistrer le nouvel étudiant)
        // URL : /Etudiant/Create (avec données POST)
        // ========================================

        // Cette action reçoit les données du formulaire et crée l'étudiant
        [HttpPost]                              // Accepte seulement les requêtes POST
        [ValidateAntiForgeryToken]              // Protection contre les attaques CSRF
        public IActionResult Create(Etudiant etudiant)
        {
            // Vérifier si les données sont valides (selon les Data Annotations)
            if (ModelState.IsValid)
            {
                // Ajouter l'étudiant à la base de données
                _context.Etudiants.Add(etudiant);

                // Sauvegarder les changements dans la base de données
                _context.SaveChanges();

                // Rediriger vers la liste des étudiants
                return RedirectToAction("Index");
            }

            // Si les données ne sont pas valides, réafficher le formulaire avec les erreurs
            return View(etudiant);
        }

        // ========================================
        // ACTION : EDIT GET (Afficher le formulaire de modification)
        // URL : /Etudiant/Edit/5
        // ========================================

        // Cette action affiche le formulaire pré-rempli pour modifier un étudiant
        public IActionResult Edit(int? id)
        {
            // Vérifier si l'ID est fourni
            if (id == null)
            {
                return NotFound();
            }

            // Chercher l'étudiant à modifier
            var etudiant = _context.Etudiants.Find(id);

            // Vérifier si l'étudiant existe
            if (etudiant == null)
            {
                return NotFound();
            }

            // Afficher le formulaire avec les données actuelles
            return View(etudiant);
        }

        // ========================================
        // ACTION : EDIT POST (Enregistrer les modifications)
        // URL : /Etudiant/Edit/5 (avec données POST)
        // ========================================

        // Cette action reçoit les données modifiées et met à jour l'étudiant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Etudiant etudiant)
        {
            // Vérifier que l'ID de l'URL correspond à l'ID de l'étudiant
            if (id != etudiant.ID)
            {
                return NotFound();
            }

            // Vérifier si les données sont valides
            if (ModelState.IsValid)
            {
                // Mettre à jour l'étudiant dans la base de données
                _context.Etudiants.Update(etudiant);
                _context.SaveChanges();

                // Rediriger vers la liste
                return RedirectToAction("Index");
            }

            // Si erreur, réafficher le formulaire
            return View(etudiant);
        }

        // ========================================
        // ACTION : DELETE GET (Afficher la confirmation)
        // URL : /Etudiant/Delete/5
        // ========================================

        // Cette action affiche une page de confirmation avant suppression
        public IActionResult Delete(int? id)
        {
            // Vérifier si l'ID est fourni
            if (id == null)
            {
                return NotFound();
            }

            // Chercher l'étudiant à supprimer
            var etudiant = _context.Etudiants.Find(id);

            // Vérifier si l'étudiant existe
            if (etudiant == null)
            {
                return NotFound();
            }

            // Afficher la page de confirmation
            return View(etudiant);
        }

        // ========================================
        // ACTION : DELETE POST (Confirmer la suppression)
        // URL : /Etudiant/Delete/5 (avec POST)
        // ========================================

        // Cette action supprime réellement l'étudiant après confirmation
        [HttpPost, ActionName("Delete")]        // ActionName permet d'avoir 2 méthodes Delete
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Chercher l'étudiant à supprimer
            var etudiant = _context.Etudiants.Find(id);

            // Si l'étudiant existe, le supprimer
            if (etudiant != null)
            {
                _context.Etudiants.Remove(etudiant);
                _context.SaveChanges();
            }

            // Rediriger vers la liste
            return RedirectToAction("Index");
        }
    }
}
