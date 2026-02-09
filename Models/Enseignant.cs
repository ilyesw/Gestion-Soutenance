// ============================================
// FICHIER : Models/Enseignant.cs
// DESCRIPTION : Modèle représentant un enseignant
// ============================================

// On importe les bibliothèques nécessaires
using System.ComponentModel.DataAnnotations;      // Pour les Data Annotations (validation)
using System.ComponentModel.DataAnnotations.Schema; // Pour les configurations de table

namespace GestSoutenance.Models
{
    /// <summary>
    /// Cette classe représente un Enseignant dans notre système
    /// Un enseignant peut encadrer plusieurs PFE
    /// </summary>
    public class Enseignant
    {
        // ========================================
        // CLÉ PRIMAIRE
        // ========================================

        // [Key] indique que cette propriété est la clé primaire
        // La clé primaire identifie de manière unique chaque enseignant
        [Key]
        [Display(Name = "ID Enseignant")]  // Le nom affiché dans les formulaires
        public int ID { get; set; }

        // ========================================
        // PROPRIÉTÉS (Colonnes de la table)
        // ========================================

        // Le nom de l'enseignant
        [Required(ErrorMessage = "Le nom est obligatoire")]  // Champ obligatoire
        [Display(Name = "Nom")]                               // Nom affiché
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        public string Nom { get; set; }

        // Le prénom de l'enseignant
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [Display(Name = "Prénom")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères")]
        public string Prenom { get; set; }

        // ========================================
        // PROPRIÉTÉ DE NAVIGATION
        // ========================================

        // Un enseignant peut encadrer PLUSIEURS PFE
        // C'est une relation "Un-à-Plusieurs" (One-to-Many)
        // Cette propriété permet d'accéder à tous les PFE encadrés par cet enseignant
        public virtual ICollection<PFE>? PFEsEncadres { get; set; }

        // ========================================
        // PROPRIÉTÉ CALCULÉE (pour affichage)
        // ========================================

        // Cette propriété combine le nom et prénom pour un affichage facile
        // [NotMapped] signifie que cette propriété n'est PAS stockée dans la base de données
        [NotMapped]
        [Display(Name = "Nom Complet")]
        public string NomComplet
        {
            get
            {
                // On retourne "Prénom Nom"
                return Prenom + " " + Nom;
            }
        }
    }
}
