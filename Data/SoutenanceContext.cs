// ============================================
// FICHIER : Data/SoutenanceContext.cs
// DESCRIPTION : Contexte de base de données Entity Framework
// ============================================

// Entity Framework Core est l'ORM (Object-Relational Mapping) que nous utilisons
// Il fait le lien entre nos classes C# et les tables de la base de données

using Microsoft.EntityFrameworkCore;
using GestSoutenance.Models;

namespace GestSoutenance.Data
{
    /// <summary>
    /// SoutenanceContext est la classe qui gère la connexion à la base de données
    /// Elle hérite de DbContext qui est fourni par Entity Framework
    /// </summary>
    public class SoutenanceContext : DbContext
    {
        // ========================================
        // CONSTRUCTEUR
        // ========================================

        // Le constructeur reçoit les options de configuration (comme la chaîne de connexion)
        // Ces options sont passées automatiquement par le système d'injection de dépendances
        public SoutenanceContext(DbContextOptions<SoutenanceContext> options)
            : base(options)
        {
            // Le constructeur appelle le constructeur parent avec les options
        }

        // ========================================
        // DBSETS (Tables de la base de données)
        // ========================================

        // Chaque DbSet représente une table dans la base de données
        // Le nom de la propriété sera le nom de la table

        // Table des enseignants
        public DbSet<Enseignant> Enseignants { get; set; }

        // Table des étudiants
        public DbSet<Etudiant> Etudiants { get; set; }

        // Table des sociétés
        public DbSet<Societe> Societes { get; set; }

        // Table des PFE (Projets de Fin d'Études)
        public DbSet<PFE> PFEs { get; set; }

        // Table d'association PFE-Etudiant
        public DbSet<PFE_Etudiant> PFE_Etudiants { get; set; }

        // ========================================
        // CONFIGURATION DU MODÈLE (Optionnel)
        // ========================================

        // Cette méthode permet de configurer les relations et contraintes
        // Elle est appelée automatiquement lors de la création du modèle
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // On appelle la méthode parent
            base.OnModelCreating(modelBuilder);

            // ----------------------------------------
            // Configuration de la table PFE
            // ----------------------------------------

            // On configure la relation entre PFE et Enseignant
            // Un PFE a UN enseignant encadrant (relation Many-to-One)
            modelBuilder.Entity<PFE>()
                .HasOne(p => p.Encadrant)           // Un PFE a un encadrant
                .WithMany(e => e.PFEsEncadres)      // Un enseignant peut encadrer plusieurs PFE
                .HasForeignKey(p => p.EncadrantID)  // La clé étrangère est EncadrantID
                .OnDelete(DeleteBehavior.Restrict); // Empêche la suppression si des PFE existent

            // On configure la relation entre PFE et Societe
            modelBuilder.Entity<PFE>()
                .HasOne(p => p.Societe)             // Un PFE a une société
                .WithMany(s => s.PFEs)              // Une société peut avoir plusieurs PFE
                .HasForeignKey(p => p.SocieteID)    // La clé étrangère est SocieteID
                .OnDelete(DeleteBehavior.Restrict); // Empêche la suppression si des PFE existent

            // ----------------------------------------
            // Configuration de la table PFE_Etudiant
            // ----------------------------------------

            // Relation PFE_Etudiant vers PFE
            modelBuilder.Entity<PFE_Etudiant>()
                .HasOne(pe => pe.PFE)               // Chaque ligne a un PFE
                .WithMany(p => p.PFE_Etudiants)     // Un PFE peut avoir plusieurs étudiants
                .HasForeignKey(pe => pe.PFEID)      // Clé étrangère PFEID
                .OnDelete(DeleteBehavior.Cascade);  // Supprime les associations si le PFE est supprimé

            // Relation PFE_Etudiant vers Etudiant
            modelBuilder.Entity<PFE_Etudiant>()
                .HasOne(pe => pe.Etudiant)          // Chaque ligne a un étudiant
                .WithMany(e => e.PFE_Etudiants)     // Un étudiant peut participer à plusieurs PFE
                .HasForeignKey(pe => pe.EtudiantId) // Clé étrangère EtudiantId
                .OnDelete(DeleteBehavior.Cascade);  // Supprime les associations si l'étudiant est supprimé
        }
    }
}
