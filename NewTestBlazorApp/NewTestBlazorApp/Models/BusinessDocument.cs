namespace NewTestBlazorApp.Models
{
    public class BusinessDocument
    {
        public long? ID { get; set; }
        public Guid? Identifier { get; set; }

        // Voorbeeld van Dynamische properties (deze kunnen altijd wisselen en de kolommen voor deze properties moeten dus dynamisch gegenereerd worden)
        public string? DocumentName { get; set; } // De naam van het document, i.e.: Email van bedrijf.msg
        public long? SizeInBytes { get; set; } // De grootte in bytes van het document
        public string? Extension { get; set; } // De extensie van het document, i.e. : .msg of .docx
    }
}
