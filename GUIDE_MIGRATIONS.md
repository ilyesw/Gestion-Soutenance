# 📘 PARTIE 8 - GUIDE DES MIGRATIONS

## Qu'est-ce qu'une Migration ?

Une **migration** permet de créer ou mettre à jour la base de données
à partir de vos classes de modèle (Code First).

Entity Framework compare vos modèles C# avec la base de données
et génère le code SQL nécessaire.

---

## 🔧 Prérequis

Avant d'exécuter les migrations, assurez-vous que :

1. ✅ Le projet compile sans erreurs
2. ✅ Les packages NuGet sont installés (voir GestSoutenance.csproj)
3. ✅ La chaîne de connexion est correcte dans `appsettings.json`

---

## 📋 Commandes de Migration

### Dans Visual Studio (Package Manager Console)

Ouvrez la console avec : **Outils → Gestionnaire de package NuGet → Console du Gestionnaire de package**

```powershell
# ============================================
# ÉTAPE 1 : Créer la migration initiale
# ============================================
# Cette commande analyse vos modèles et crée les fichiers de migration
# "InitialCreate" est le nom de la migration (vous pouvez le changer)

Add-Migration InitialCreate

# ============================================
# ÉTAPE 2 : Appliquer la migration à la base de données
# ============================================
# Cette commande crée la base de données et les tables

Update-Database

# ============================================
# COMMANDES UTILES
# ============================================

# Voir la liste des migrations
Get-Migration

# Annuler la dernière migration (si pas encore appliquée)
Remove-Migration

# Revenir à une migration précédente
Update-Database NomDeLaMigration

# Générer le script SQL (sans l'exécuter)
Script-Migration
```

---

### En ligne de commande (.NET CLI)

Si vous utilisez le terminal ou VS Code :

```bash
# Naviguer vers le dossier du projet
cd c:\Users\HP\Desktop\GestSoutenance

# ============================================
# ÉTAPE 1 : Créer la migration initiale
# ============================================
dotnet ef migrations add InitialCreate

# ============================================
# ÉTAPE 2 : Appliquer la migration
# ============================================
dotnet ef database update

# ============================================
# COMMANDES UTILES
# ============================================

# Voir les migrations
dotnet ef migrations list

# Supprimer la dernière migration
dotnet ef migrations remove

# Générer le script SQL
dotnet ef migrations script
```

---

## 🗃️ Ce que la migration va créer

La migration va créer les tables suivantes dans `GestSoutenanceDB` :

| Table           | Description                       |
| --------------- | --------------------------------- |
| `Enseignants`   | Liste des enseignants             |
| `Etudiants`     | Liste des étudiants               |
| `Societes`      | Liste des sociétés                |
| `PFEs`          | Liste des projets de fin d'études |
| `PFE_Etudiants` | Table d'association PFE-Étudiant  |

---

## ⚠️ En cas d'erreur

### Erreur : "Cannot find 'dotnet ef'"

```bash
# Installer l'outil EF Core globalement
dotnet tool install --global dotnet-ef
```

### Erreur : "No DbContext was found"

Vérifiez que `SoutenanceContext.cs` est bien dans le dossier `Data/`

### Erreur de connexion à la base

Vérifiez la chaîne de connexion dans `appsettings.json`

---

## 📸 Vérification

Après `Update-Database`, vous pouvez vérifier :

1. **Dans Visual Studio** : Vue → Explorateur d'objets SQL Server
2. **Cherchez** : (localdb)\mssqllocaldb → Bases de données → GestSoutenanceDB
3. **Vérifiez** les 5 tables créées

---

**Prochaine étape :** Partie 9 - Guide de Test 🚀
