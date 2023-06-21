using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.Helpers.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsList(string moduleName)
        {
            if (!Enum.TryParse(moduleName, out Modules module))
            {
                throw new ArgumentException("Invalid module name.", nameof(moduleName));
            }

            switch (module)
            {
                case Modules.Settings:
                    return Settings.Permissions();
                case Modules.Users:
                    return Users.Permissions();
                case Modules.Roles:
                    return Roles.Permissions();
                case Modules.Dioceses:
                    return Dioceses.Permissions();
                case Modules.Priests:
                    return Priests.Permissions();
                case Modules.Contributions:
                    return Contributions.Permissions();
                case Modules.Pensions:
                    return Pensions.Permissions();
                case Modules.Reports:
                    return Reports.Permissions();
                default:
                    throw new ArgumentOutOfRangeException(nameof(module), module, "Invalid module.");
            }
        }


        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();

            var modules = Enum.GetValues(typeof(Modules));

            foreach (var module in modules)
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));

            return allPermissions;
        }

        public static class Settings
        {
            public const string Access = "Permissions.Settings: Accéder au module des paramètres";
            public const string ManageCosts = "Permissions.Settings: Paramétrer les frais de cotisation et d'allocation";

            public static List<string> Permissions() => new List<string>() { Access, ManageCosts };
        }

        public static class Users
        {
            public const string Access = "Permissions.Utilisateurs: Accéder au module de gestion des utilisateurs";
            public const string Create = "Permissions.Utilisateurs: Ajouter un nouvel utilisateur";
            public const string ManageRoles = "Permissions.Utilisateurs: Affecter un rôle à un utilisateur";

            public static List<string> Permissions() => new List<string>() { Access, Create, ManageRoles };
        }

        public static class Roles
        {
            public const string Access = "Permissions.Roles: Accéder au module de gestion des rôles";
            public const string Create = "Permissions.Roles: Ajouter un nouveau rôle";
            public const string ManagePermissions = "Permissions.Roles: Paramétrer les habilitations pour un rôle";

            public static List<string> Permissions() => new List<string>() { Access, Create, ManagePermissions };
        }

        public static class Dioceses
        {
            public const string Access = "Permissions.Dioceses: Accéder au module de gestion des diocèses";
            public const string Create = "Permissions.Dioceses: Ajouter un nouveau diocèse";
            public const string Delete = "Permissions.Dioceses: Supprimer un diocèse";
            public const string Edit = "Permissions.Dioceses: Modifier les infos d'un diocèse";
            public const string ImportData = "Permissions.Dioceses: Importer la liste des prêtres d'un diocèse";

            public static List<string> Permissions() => new List<string>() { Access, Create, Delete, Edit, ImportData };
        }

        public static class Priests
        {
            public const string Access = "Permissions.Priests: Accéder au module de gestion des prêtres";
            public const string Create = "Permissions.Priests: Ajouter un nouveau prêtre";
            public const string Delete = "Permissions.Priests: Supprimer un prêtre";
            public const string Edit = "Permissions.Priests: Modifier les infos d'un prêtre";
            public const string ViewAll = "Permissions.Priests: Consulter la liste de tous les prêtres";
            public const string Suspend = "Permissions.Priests: Mettre fin aux actions d'un prêtre au sein de l'OSS-TOGO";

            public static List<string> Permissions() => new List<string>() { Access, Create, Delete, Edit, ViewAll, Suspend };
        }

        public static class Contributions
        {
            public const string Access = "Permissions.Contributions: Accéder au module de gestion des cotisations";
            public const string Add = "Permissions.Contributions: Enregistrer les cotisations";
            public const string ViewAll = "Permissions.Contributions: Consulter la liste de toutes les cotisations";

            public static List<string> Permissions() => new List<string>() { Access, Add, ViewAll };
        }

        public static class Pensions
        {
            public const string Access = "Permissions.Pensions: Accéder au module de gestion des allocations";
            public const string Add = "Permissions.Pensions: Enregistrer les versements de pension";
            public const string ViewAll = "Permissions.Pensions: Consulter la liste de toutes les allocations versées";

            public static List<string> Permissions() => new List<string>() { Access, Add, ViewAll };
        }

        public static class Reports
        {
            public const string Access = "Permissions.Reports: Accéder au module des états";
            public const string ViewPriests = "Permissions.Reports: Consulter l'état des prêtres";
            public const string ViewDioceses = "Permissions.Reports: Consulter l'état des diocèses";
            public const string ViewPriestsByDiocese = "Permissions.Reports: Consulter l'état des prêtres par diocèse";
            public const string ViewContributions = "Permissions.Reports: Consulter l'état des cotisations";
            public const string ViewContributionsByPriest = "Permissions.Reports: Consulter l'état des cotisations par prêtre";
            public const string ViewContributionsByDiocese = "Permissions.Reports: Consulter l'état des cotisations par diocèse";
            public const string ViewPensions = "Permissions.Reports: Consulter l'état des allocations";
            public const string ViewPensionsByPriest = "Permissions.Reports: Consulter l'état des allocations par prêtre";

            public static List<string> Permissions() => new List<string>() 
            { Access, ViewPriests, ViewDioceses, ViewPriestsByDiocese, ViewContributions, ViewContributionsByPriest, ViewContributionsByDiocese, ViewPensions, ViewPensionsByPriest };
        }
    }
}
