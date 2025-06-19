namespace TestWeb.UI.Models
{
    public class BusinessExternalDossier
    {
        public long? ID { get; set; } // Oplopend ID
        public Guid? Identifier { get; set; } // Unieke Guid
        public long? BusinessUnitID { get; set; } // 1
        public int? DossierNumber { get; set; } // Het dossiernummer, bijvoorbeeld: 20250001
        public string? DossierName { get; set; } // De naam van het dossier, bijvoorbeeld: David / Goliath
        public long? ExternalEmployeeID { get; set; } // Het ID van de medewerker waar dit dossier onder valt.
        public bool? IsInactive { get; set; } // Geeft aan of het dossier gearchiveerd is of niet.

        public string? FormattedName => $"{DossierNumber} - {DossierName}"; // Gebruiken als weergave in de lijst.
    }

}
