namespace TestWeb.UI.Models
{
    public class BusinessExternalEmployee
    {
            public long? ID { get; set; } // Oplopend ID
            public string? Identifier { get; set; } // Unieke Guid
            public long? BusinessUnitID { get; set; } // 1
            public string? Initials { get; set; } // De initialen van een medewerker
            public string? EmployeeName { get; set; } // De volledige naam

    }
}
