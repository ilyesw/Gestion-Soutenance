// ============================================
// FICHIER : Program.cs
// DESCRIPTION : Point d'entrée de l'application ASP.NET Core
// ============================================

// Ce fichier configure et démarre notre application web
// C'est le premier fichier exécuté quand on lance l'application

using Microsoft.EntityFrameworkCore;
using GestSoutenance.Data;

// ========================================
// CRÉATION DU BUILDER
// ========================================

// Le builder permet de configurer tous les services de l'application
var builder = WebApplication.CreateBuilder(args);

// ========================================
// CONFIGURATION DES SERVICES
// ========================================

// 1. Ajouter le service MVC (Controllers avec Views)
// Cela permet d'utiliser les contrôleurs et les vues Razor
builder.Services.AddControllersWithViews();

// 2. Configurer Entity Framework avec SQL Server (LocalDB)
// On récupère la chaîne de connexion depuis appsettings.json
// Et on enregistre notre SoutenanceContext comme service
builder.Services.AddDbContext<SoutenanceContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SoutenanceConnection")
    )
);

// ========================================
// CONSTRUCTION DE L'APPLICATION
// ========================================

// On construit l'application avec tous les services configurés
var app = builder.Build();

// ========================================
// CONFIGURATION DU PIPELINE HTTP
// ========================================

// Le pipeline définit comment les requêtes HTTP sont traitées

// Si on n'est PAS en mode développement
if (!app.Environment.IsDevelopment())
{
    // Utiliser une page d'erreur générique
    app.UseExceptionHandler("/Home/Error");

    // Activer HSTS pour la sécurité HTTPS
    app.UseHsts();
}

// Rediriger automatiquement HTTP vers HTTPS
app.UseHttpsRedirection();

// Permettre de servir les fichiers statiques (CSS, JS, images)
// Ces fichiers sont dans le dossier wwwroot
app.UseStaticFiles();

// Activer le routage
app.UseRouting();

// Activer l'autorisation (même si on n'utilise pas l'authentification ici)
app.UseAuthorization();

// ========================================
// CONFIGURATION DES ROUTES
// ========================================

// Définir la route par défaut
// Format: {controller}/{action}/{id?}
// Exemple: /Etudiant/Edit/5 → EtudiantController.Edit(5)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// ========================================
// DÉMARRAGE DE L'APPLICATION
// ========================================

// Lancer l'application et écouter les requêtes HTTP
app.Run();
