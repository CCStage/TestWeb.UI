using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Sockets;

namespace NewTestBlazorApp.Models
{
    public class BusinessExternalDossier
    {
        public long? ID { get; set; }
        public Guid? Identifier { get; set; }
        public long? BusinessUnitID { get; set; }
        public int? DossierNumber { get; set; }
        public string? DossierName { get; set; }
        public long? ExternalEmployeeID { get; set; }
        public bool? IsInactive { get; set; }
        public string? FormattedName => $"{DossierNumber} - {DossierName}";
        public List<BusinessExternalDossier>? SubDossiers { get; set; } 
    }

    
}
