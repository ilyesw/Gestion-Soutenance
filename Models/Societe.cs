// ============================================
// FICHIER : Models/Societe.cs
// DESCRIPTION : Modèle représentant une société (entreprise)
// ============================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestSoutenance.Models
{
    /// <summary>
    /// Cette classe représente une Société (entreprise) où se déroule le stage
    /// Une société peut accueillir plusieurs PFE
    /// </summary>
    public class Societe
    {
        // ========================================
        // CLÉ PRIMAIRE
        // ========================================

        [Key]
        [Display(Name = "ID Société")]
        public int ID { get; set; }

        // ========================================
        // PROPRIÉTÉS (Colonnes de la table)
        // ========================================

        // Le libellé (nom) de la société
        [Required(ErrorMessage = "Le nom de la société est obligatoire")]
        [Display(Name = "Nom de la Société")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        public string Lib { get; set; }

        // L'adresse de la société
        [Required(ErrorMessage = "L'adresse est obligatoire")]
        [Display(Name = "Adresse")]
        [StringLength(200, ErrorMessage = "L'adresse ne peut pas dépasser 200 caractères")]
        public string Adresse { get; set; }

        // Le numéro de téléphone de la société
        [Display(Name = "Téléphone")]
        [StringLength(20, ErrorMessage = "Le téléphone ne peut pas dépasser 20 caractères")]
        [Phone(ErrorMessage = "Le format du téléphone n'est pas valide")]
        public string? Tel { get; set; }  // Le ? signifie que ce champ peut être vide (nullable)

        // ========================================
        // PROPRIÉTÉ DE NAVIGATION
        // ========================================

        // Une société peut accueillir PLUSIEURS PFE
        // Relation "Un-à-Plusieurs" (One-to-Many)
        public virtual ICollection<PFE>? PFEs { get; set; }
    }
}
