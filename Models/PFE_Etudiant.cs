// ============================================
// FICHIER : Models/PFE_Etudiant.cs
// DESCRIPTION : Table d'association entre PFE et Etudiant
// ============================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestSoutenance.Models
{
    /// <summary>
    /// Cette classe représente la table d'association entre PFE et Etudiant
    /// Elle permet de gérer la relation "Plusieurs-à-Plusieurs" (Many-to-Many)
    /// Un PFE peut avoir plusieurs étudiants, et un étudiant peut participer à plusieurs PFE
    /// </summary>
    public class PFE_Etudiant
    {
        // ========================================
        // CLÉ PRIMAIRE
        // ========================================

        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        // ========================================
        // CLÉS ÉTRANGÈRES
        // ========================================

        // Clé étrangère vers le PFE
        [Display(Name = "PFE")]
        [Required(ErrorMessage = "Le PFE est obligatoire")]
        public int PFEID { get; set; }

        // Clé étrangère vers l'étudiant
        [Display(Name = "Étudiant")]
        [Required(ErrorMessage = "L'étudiant est obligatoire")]
        public int EtudiantId { get; set; }

        // ========================================
        // PROPRIÉTÉS DE NAVIGATION
        // ========================================

        // Navigation vers le PFE associé
        [ForeignKey("PFEID")]
        public virtual PFE? PFE { get; set; }

        // Navigation vers l'étudiant associé
        [ForeignKey("EtudiantId")]
        public virtual Etudiant? Etudiant { get; set; }
    }
}
