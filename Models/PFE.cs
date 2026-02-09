// ============================================
// FICHIER : Models/PFE.cs
// DESCRIPTION : Modèle représentant un Projet de Fin d'Études
// ============================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestSoutenance.Models
{
    /// <summary>
    /// Cette classe représente un PFE (Projet de Fin d'Études)
    /// Un PFE est encadré par UN enseignant et se déroule dans UNE société
    /// Un PFE peut avoir PLUSIEURS étudiants (via la table PFE_Etudiant)
    /// </summary>
    public class PFE
    {
        // ========================================
        // CLÉ PRIMAIRE
        // ========================================

        [Key]
        [Display(Name = "ID PFE")]
        public int PFEID { get; set; }

        // ========================================
        // PROPRIÉTÉS (Colonnes de la table)
        // ========================================

        // Le titre du PFE
        [Required(ErrorMessage = "Le titre du PFE est obligatoire")]
        [Display(Name = "Titre du PFE")]
        [StringLength(200, ErrorMessage = "Le titre ne peut pas dépasser 200 caractères")]
        public string Titre { get; set; }

        // La description du PFE
        [Display(Name = "Description")]
        [StringLength(1000, ErrorMessage = "La description ne peut pas dépasser 1000 caractères")]
        [DataType(DataType.MultilineText)]  // Affiche une zone de texte multiligne
        public string? Desc { get; set; }

        // La date de début du PFE (stage)
        [Required(ErrorMessage = "La date de début est obligatoire")]
        [Display(Name = "Date de Début")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateD { get; set; }

        // La date de fin du PFE (stage)
        [Required(ErrorMessage = "La date de fin est obligatoire")]
        [Display(Name = "Date de Fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateF { get; set; }

        // ========================================
        // CLÉS ÉTRANGÈRES (Foreign Keys)
        // ========================================

        // Clé étrangère vers l'enseignant encadrant
        // [ForeignKey] indique à Entity Framework que c'est une clé étrangère
        [Display(Name = "Encadrant")]
        [Required(ErrorMessage = "L'encadrant est obligatoire")]
        public int EncadrantID { get; set; }

        // Clé étrangère vers la société
        [Display(Name = "Société")]
        [Required(ErrorMessage = "La société est obligatoire")]
        public int SocieteID { get; set; }

        // ========================================
        // PROPRIÉTÉS DE NAVIGATION
        // ========================================

        // Navigation vers l'enseignant encadrant
        // [ForeignKey("EncadrantID")] lie cette propriété à la clé étrangère EncadrantID
        [ForeignKey("EncadrantID")]
        public virtual Enseignant? Encadrant { get; set; }

        // Navigation vers la société
        [ForeignKey("SocieteID")]
        public virtual Societe? Societe { get; set; }

        // Un PFE peut avoir plusieurs étudiants (relation Many-to-Many via PFE_Etudiant)
        public virtual ICollection<PFE_Etudiant>? PFE_Etudiants { get; set; }
    }
}
