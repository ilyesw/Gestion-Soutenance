// ============================================
// FICHIER : Models/Etudiant.cs
// DESCRIPTION : Modèle représentant un étudiant
// ============================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestSoutenance.Models
{
    /// <summary>
    /// Cette classe représente un Étudiant dans notre système
    /// Un étudiant peut participer à plusieurs PFE via la table PFE_Etudiant
    /// </summary>
    public class Etudiant
    {
        // ========================================
        // CLÉ PRIMAIRE
        // ========================================

        [Key]
        [Display(Name = "ID Étudiant")]
        public int ID { get; set; }

        // ========================================
        // PROPRIÉTÉS (Colonnes de la table)
        // ========================================

        // Le nom de l'étudiant
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [Display(Name = "Nom")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        public string Nom { get; set; }

        // Le prénom de l'étudiant
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [Display(Name = "Prénom")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères")]
        public string Prenom { get; set; }

        // La date de naissance de l'étudiant
        // [DataType(DataType.Date)] affiche un sélecteur de date dans le formulaire
        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateNaiss { get; set; }

        // ========================================
        // PROPRIÉTÉ DE NAVIGATION
        // ========================================

        // Un étudiant peut participer à plusieurs PFE
        // Cette relation passe par la table d'association PFE_Etudiant
        public virtual ICollection<PFE_Etudiant>? PFE_Etudiants { get; set; }

        // ========================================
        // PROPRIÉTÉ CALCULÉE (pour affichage)
        // ========================================

        [NotMapped]
        [Display(Name = "Nom Complet")]
        public string NomComplet
        {
            get
            {
                return Prenom + " " + Nom;
            }
        }
    }
}
