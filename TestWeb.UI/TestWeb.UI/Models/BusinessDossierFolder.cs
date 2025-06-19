namespace TestWeb.UI.Models
{
    public class BusinessDossierFolder
    {
        public long? ID { get; set; } // Oplopend ID
        public Guid? Identifier { get; set; } // Unieke Guid
        public long? BusinessUnitID { get; set; } // 1
        public long? ExternalDossierID { get; set; } // Dossier waar deze map in staat
        public long? DossierFolderParentID { get; set; } // Het ID van de map waar deze map in staat
        public string? DossierFolderName { get; set; } // De naam van de map

    }
}
