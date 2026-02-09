# 📘 PARTIE 9 - GUIDE DE TEST

## 🚀 Comment démarrer l'application

### Étape 1 : Ouvrir le projet dans Visual Studio 2026

1. Ouvrez Visual Studio 2026
2. Cliquez sur **Ouvrir un projet ou une solution**
3. Naviguez vers `c:\Users\HP\Desktop\GestSoutenance`
4. Sélectionnez le fichier `GestSoutenance.csproj`

### Étape 2 : Restaurer les packages NuGet

1. Clic droit sur le projet dans l'Explorateur de solutions
2. Sélectionnez **Restaurer les packages NuGet**
3. Attendez que les packages soient téléchargés

### Étape 3 : Créer la base de données

1. Ouvrez **Outils → Gestionnaire de package NuGet → Console**
2. Exécutez :
   ```powershell
   Add-Migration InitialCreate
   Update-Database
   ```

### Étape 4 : Lancer l'application

1. Appuyez sur **F5** ou cliquez sur le bouton ▶️ (Démarrer)
2. Le navigateur s'ouvre automatiquement
3. Vous êtes sur la page d'accueil !

---

## 🧪 Tests de chaque fonctionnalité

### Test 1 : Page d'accueil

| Étape | Action                | Résultat attendu                                                       |
| ----- | --------------------- | ---------------------------------------------------------------------- |
| 1     | Ouvrir l'application  | Page d'accueil avec les cartes de navigation                           |
| 2     | Vérifier le menu      | 6 liens (Accueil, Étudiants, Enseignants, Sociétés, PFE, Affectations) |
| 3     | Cliquer sur une carte | Redirection vers la liste correspondante                               |

---

### Test 2 : CRUD Étudiants

#### 2.1 - Créer un étudiant

| Étape | Action                                                         | Résultat attendu                          |
| ----- | -------------------------------------------------------------- | ----------------------------------------- |
| 1     | Menu → Étudiants                                               | Liste des étudiants (vide au début)       |
| 2     | Cliquer "Ajouter un Étudiant"                                  | Formulaire vide                           |
| 3     | Remplir : Nom = "Ben Ali", Prénom = "Ahmed", Date = 15/03/2000 | Champs remplis                            |
| 4     | Cliquer "Enregistrer"                                          | Retour à la liste avec le nouvel étudiant |

#### 2.2 - Validation des champs

| Étape | Action                 | Résultat attendu                    |
| ----- | ---------------------- | ----------------------------------- |
| 1     | Laisser le Nom vide    | Message "Le nom est obligatoire"    |
| 2     | Laisser le Prénom vide | Message "Le prénom est obligatoire" |

#### 2.3 - Modifier un étudiant

| Étape | Action                             | Résultat attendu      |
| ----- | ---------------------------------- | --------------------- |
| 1     | Cliquer "Modifier" sur un étudiant | Formulaire pré-rempli |
| 2     | Changer le prénom en "Mohamed"     | Champ modifié         |
| 3     | Cliquer "Enregistrer"              | Liste mise à jour     |

#### 2.4 - Voir les détails

| Étape | Action            | Résultat attendu                   |
| ----- | ----------------- | ---------------------------------- |
| 1     | Cliquer "Détails" | Carte avec toutes les informations |

#### 2.5 - Supprimer un étudiant

| Étape | Action                             | Résultat attendu                     |
| ----- | ---------------------------------- | ------------------------------------ |
| 1     | Cliquer "Supprimer"                | Page de confirmation                 |
| 2     | Cliquer "Confirmer la Suppression" | Étudiant supprimé, retour à la liste |

---

### Test 3 : CRUD Enseignants

Répétez les mêmes étapes que pour les étudiants :

- ✅ Créer : Nom = "Trabelsi", Prénom = "Sami"
- ✅ Modifier le prénom
- ✅ Voir les détails
- ✅ Supprimer

---

### Test 4 : CRUD Sociétés

| Étape     | Action              | Données de test                                             |
| --------- | ------------------- | ----------------------------------------------------------- |
| Créer     | Ajouter une société | Nom: "TechnoSoft", Adresse: "Tunis Centre", Tel: "71234567" |
| Modifier  | Changer l'adresse   | Nouvelle adresse: "Ariana"                                  |
| Détails   | Vérifier les infos  | Toutes les données affichées                                |
| Supprimer | Confirmer           | Société supprimée                                           |

---

### Test 5 : CRUD PFE

⚠️ **Prérequis** : Avoir au moins 1 enseignant et 1 société créés

| Étape       | Action                     | Données de test                                                                   |
| ----------- | -------------------------- | --------------------------------------------------------------------------------- |
| Créer       | Ajouter un PFE             | Titre: "Application Web E-commerce", Date début: 01/02/2026, Date fin: 31/05/2026 |
| Vérifier    | Liste déroulante encadrant | L'enseignant créé apparaît                                                        |
| Vérifier    | Liste déroulante société   | La société créée apparaît                                                         |
| Enregistrer | Sauvegarder                | PFE créé avec encadrant et société                                                |

---

### Test 6 : Affectations PFE-Étudiant

⚠️ **Prérequis** : Avoir au moins 1 PFE et 1 étudiant créés

| Étape | Action                         | Résultat attendu                     |
| ----- | ------------------------------ | ------------------------------------ |
| 1     | Menu → Affectations            | Liste vide                           |
| 2     | Cliquer "Nouvelle Affectation" | Formulaire avec 2 listes déroulantes |
| 3     | Sélectionner un PFE            | Liste affiche le titre du PFE        |
| 4     | Sélectionner un étudiant       | Liste affiche le nom complet         |
| 5     | Enregistrer                    | Association créée                    |

---

## ✅ Checklist de validation finale

- [ ] L'application démarre sans erreur
- [ ] La page d'accueil s'affiche correctement
- [ ] Le menu de navigation fonctionne
- [ ] CRUD Étudiants : Créer, Lire, Modifier, Supprimer ✓
- [ ] CRUD Enseignants : Créer, Lire, Modifier, Supprimer ✓
- [ ] CRUD Sociétés : Créer, Lire, Modifier, Supprimer ✓
- [ ] CRUD PFE : Créer, Lire, Modifier, Supprimer ✓
- [ ] CRUD Affectations : Créer, Lire, Modifier, Supprimer ✓
- [ ] La validation des formulaires fonctionne
- [ ] Les listes déroulantes affichent les données

---

## 🐛 Problèmes courants et solutions

### Problème : "Table does not exist"

**Solution** : Exécutez `Update-Database` dans la Console du Gestionnaire de package

### Problème : "No connection string"

**Solution** : Vérifiez `appsettings.json` et la chaîne `SoutenanceConnection`

### Problème : Liste déroulante vide

**Solution** : Créez d'abord les enseignants/sociétés avant de créer un PFE

### Problème : Erreur 404

**Solution** : Vérifiez que le contrôleur et la vue existent

---

## 🎉 Félicitations !

Si tous les tests passent, votre application est prête !

Vous avez créé une application ASP.NET MVC complète avec :

- ✅ 5 modèles avec Data Annotations
- ✅ 1 DbContext Entity Framework
- ✅ 6 contrôleurs CRUD
- ✅ 26 vues Razor
- ✅ Interface Bootstrap responsive
- ✅ Base de données LocalDB
