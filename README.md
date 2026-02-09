<img width="1918" height="1191" alt="image" src="https://github.com/user-attachments/assets/82314d88-fa82-406c-9c4d-e0859f69a365" /># 🎓 GestSoutenance

<div align="center">

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.0-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)

![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)
![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022/2026-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)
![Status](https://img.shields.io/badge/Status-Active-brightgreen?style=for-the-badge)

**[Français](#-français) | [English](#-english)**

---

### 🖼️ Aperçu / Preview

</div>

|                           Page d'accueil / Home                            |                       Liste des étudiants / Students List                        |
| :------------------------------------------------------------------------: | :------------------------------------------------------------------------------: |
| <img width="1903" height="1199" alt="image" src="https://github.com/user-attachments/assets/75129e1a-199e-4418-9de1-d676e54960e2" />
) | <img width="1919" height="1052" alt="image" src="https://github.com/user-attachments/assets/63e485ca-9ae1-491b-afc5-4e5dc830d209" />
) |

|                       Gestion des PFE / PFE Management                        |                            Affectations / Assignments                             |
| :---------------------------------------------------------------------------: | :-------------------------------------------------------------------------------: |
| ![PFE](https://via.placeholder.com/400x250/CC2927/FFFFFF?text=📁+Projets+PFE) | ![Assign](https://via.placeholder.com/400x250/28a745/FFFFFF?text=🔗+Affectations) |

> 💡 _Remplacez ces images par des captures d'écran réelles de votre application_
>
> 💡 _Replace these images with actual screenshots of your application_

---

## 🇫🇷 Français

### 📋 Description

**GestSoutenance** est une application web ASP.NET Core MVC complète pour la gestion des soutenances de Projets de Fin d'Études (PFE). Elle permet aux établissements d'enseignement de gérer efficacement les étudiants, les enseignants, les entreprises partenaires et les projets de fin d'études.

### ✨ Fonctionnalités

| Module                         | Description                                                                   |
| ------------------------------ | ----------------------------------------------------------------------------- |
| 👨‍🎓 **Gestion des Étudiants**   | CRUD complet pour la gestion des étudiants (Créer, Lire, Modifier, Supprimer) |
| 👨‍🏫 **Gestion des Enseignants** | Gestion des encadrants et superviseurs de PFE                                 |
| 🏢 **Gestion des Sociétés**    | Suivi des entreprises d'accueil pour les stages                               |
| 📁 **Gestion des PFE**         | Création et suivi des projets avec dates, encadrant et société                |
| 🔗 **Affectations**            | Liaison des étudiants à leurs projets de fin d'études                         |

### 🛠️ Technologies Utilisées

| Catégorie          | Technologie                        |
| ------------------ | ---------------------------------- |
| 🔧 Framework       | ASP.NET Core MVC (.NET 10)         |
| 🗄️ ORM             | Entity Framework Core (Code First) |
| 💾 Base de données | SQL Server LocalDB                 |
| 🎨 Frontend        | Bootstrap 5, Razor Views           |
| 🖥️ IDE             | Visual Studio 2022/2026            |

### 📁 Structure du Projet

```
GestSoutenance/
├── 📂 Controllers/           # Contrôleurs MVC
│   ├── EtudiantController.cs
│   ├── EnseignantController.cs
│   ├── SocieteController.cs
│   ├── PFEController.cs
│   └── PFE_EtudiantController.cs
├── 📂 Models/                # Classes de données
│   ├── Etudiant.cs
│   ├── Enseignant.cs
│   ├── Societe.cs
│   ├── PFE.cs
│   └── PFE_Etudiant.cs
├── 📂 Data/                  # DbContext
├── 📂 Views/                 # Vues Razor
│   ├── Etudiant/
│   ├── Enseignant/
│   ├── Societe/
│   ├── PFE/
│   ├── PFE_Etudiant/
│   └── Shared/
├── 📂 Migrations/            # Migrations EF Core
├── 📄 Program.cs             # Point d'entrée
├── 📄 appsettings.json       # Configuration
└── 📄 GestSoutenance.csproj  # Fichier projet
```

### 🚀 Installation et Démarrage

#### Prérequis

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022/2026](https://visualstudio.microsoft.com/) avec la charge de travail ASP.NET
- SQL Server LocalDB (inclus avec Visual Studio)

#### Étapes d'installation

1. **Cloner le dépôt**

   ```bash
   git clone https://github.com/votre-username/GestSoutenance.git
   cd GestSoutenance
   ```

2. **Ouvrir le projet**

   ```
   Double-cliquer sur GestSoutenance.sln
   ```

3. **Restaurer les packages NuGet**

   ```bash
   dotnet restore
   ```

4. **Créer la base de données**

   ```powershell
   # Dans la Console du Gestionnaire de packages
   Add-Migration InitialCreate
   Update-Database
   ```

5. **Lancer l'application**
   ```bash
   dotnet run
   # Ou appuyer sur F5 dans Visual Studio
   ```

### 📚 Documentation

| Document                                       | Description                |
| ---------------------------------------------- | -------------------------- |
| 📖 [Guide des Migrations](GUIDE_MIGRATIONS.md) | Commandes Entity Framework |
| 🧪 [Guide de Test](GUIDE_TEST.md)              | Instructions de test       |

---

## 🇬🇧 English

### 📋 Description

**GestSoutenance** is a complete ASP.NET Core MVC web application for managing Final Year Project (PFE) defenses. It enables educational institutions to efficiently manage students, teachers, partner companies, and end-of-study projects.

### ✨ Features

| Module                    | Description                                                                |
| ------------------------- | -------------------------------------------------------------------------- |
| 👨‍🎓 **Student Management** | Full CRUD operations for student management (Create, Read, Update, Delete) |
| 👨‍🏫 **Teacher Management** | Management of PFE supervisors and mentors                                  |
| 🏢 **Company Management** | Tracking of host companies for internships                                 |
| 📁 **PFE Management**     | Project creation and tracking with dates, supervisor, and company          |
| 🔗 **Assignments**        | Linking students to their final year projects                              |

### 🛠️ Technologies Used

| Category     | Technology                         |
| ------------ | ---------------------------------- |
| 🔧 Framework | ASP.NET Core MVC (.NET 10)         |
| 🗄️ ORM       | Entity Framework Core (Code First) |
| 💾 Database  | SQL Server LocalDB                 |
| 🎨 Frontend  | Bootstrap 5, Razor Views           |
| 🖥️ IDE       | Visual Studio 2022/2026            |

### 📁 Project Structure

```
GestSoutenance/
├── 📂 Controllers/           # MVC Controllers
│   ├── EtudiantController.cs
│   ├── EnseignantController.cs
│   ├── SocieteController.cs
│   ├── PFEController.cs
│   └── PFE_EtudiantController.cs
├── 📂 Models/                # Data Classes
│   ├── Etudiant.cs           # Student
│   ├── Enseignant.cs         # Teacher
│   ├── Societe.cs            # Company
│   ├── PFE.cs                # Final Year Project
│   └── PFE_Etudiant.cs       # Student-Project Assignment
├── 📂 Data/                  # DbContext
├── 📂 Views/                 # Razor Views
├── 📂 Migrations/            # EF Core Migrations
├── 📄 Program.cs             # Entry Point
├── 📄 appsettings.json       # Configuration
└── 📄 GestSoutenance.csproj  # Project File
```

### 🚀 Installation and Setup

#### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022/2026](https://visualstudio.microsoft.com/) with ASP.NET workload
- SQL Server LocalDB (included with Visual Studio)

#### Installation Steps

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-username/GestSoutenance.git
   cd GestSoutenance
   ```

2. **Open the project**

   ```
   Double-click on GestSoutenance.sln
   ```

3. **Restore NuGet packages**

   ```bash
   dotnet restore
   ```

4. **Create the database**

   ```powershell
   # In Package Manager Console
   Add-Migration InitialCreate
   Update-Database
   ```

5. **Run the application**
   ```bash
   dotnet run
   # Or press F5 in Visual Studio
   ```

### 📚 Documentation

| Document                                  | Description               |
| ----------------------------------------- | ------------------------- |
| 📖 [Migration Guide](GUIDE_MIGRATIONS.md) | Entity Framework commands |
| 🧪 [Testing Guide](GUIDE_TEST.md)         | Testing instructions      |

---

## 📊 Database Schema / Schéma de Base de Données

```mermaid
erDiagram
    ETUDIANT ||--o{ PFE_ETUDIANT : assigned_to
    PFE ||--o{ PFE_ETUDIANT : has
    ENSEIGNANT ||--o{ PFE : supervises
    SOCIETE ||--o{ PFE : hosts

    ETUDIANT {
        int Id PK
        string Nom
        string Prenom
        string Email
        string Filiere
    }

    ENSEIGNANT {
        int Id PK
        string Nom
        string Prenom
        string Email
        string Specialite
    }

    SOCIETE {
        int Id PK
        string Nom
        string Adresse
        string Telephone
    }

    PFE {
        int Id PK
        string Titre
        string Description
        date DateDebut
        date DateFin
        int EnseignantId FK
        int SocieteId FK
    }

    PFE_ETUDIANT {
        int Id PK
        int PFEId FK
        int EtudiantId FK
    }
```

---

## 🤝 Contributing / Contribution

Les contributions sont les bienvenues ! / Contributions are welcome!

1. Fork le projet / Fork the project
2. Créez votre branche / Create your branch (`git checkout -b feature/AmazingFeature`)
3. Committez vos changements / Commit your changes (`git commit -m 'Add AmazingFeature'`)
4. Poussez la branche / Push the branch (`git push origin feature/AmazingFeature`)
5. Ouvrez une Pull Request / Open a Pull Request

---

## 👨‍💻 Author / Auteur

<div align="center">

Projet réalisé dans le cadre du cours **ASP.NET MVC** - **ISET 2026**

_Project developed as part of the ASP.NET MVC course - ISET 2026_

</div>

## 📄 License / Licence

Ce projet est sous licence MIT - voir le fichier [LICENSE](LICENSE) pour plus de détails.

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

<div align="center">

### ⭐ Star this repo if you find it helpful! ⭐

**Made with ❤️ using ASP.NET Core MVC**

![Visitors](https://api.visitorbadge.io/api/visitors?path=GestSoutenance&label=Visitors&countColor=%23263759)

</div>
