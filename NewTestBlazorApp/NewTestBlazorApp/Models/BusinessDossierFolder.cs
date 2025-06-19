namespace NewTestBlazorApp.Models
{
    public class BusinessDossierFolder
    {

        // done 
        public int? ID { get; set; } // Oplopend ID
        public Guid? Identifier { get; set; } // Unieke Guid
        public int? BusinessUnitID { get; set; } // 1
        public int? ExternalDossierID { get; set; } // Dossier waar deze map in staat
        public int? DossierFolderParentID { get; set; } // Het ID van de map waar deze map in staat
        public string? DossierFolderName { get; set; } // De naam van de map

        public List<BusinessDocument> Documents { get; set; } = new List<BusinessDocument>();
        public List<BusinessDossierFolder> SubFolders { get; set; } = new List<BusinessDossierFolder>();

        public bool IsExpanded { get; set; } = false;
    }
}
