using Bogus;
using NewTestBlazorApp.Models;
using System.Reflection.Metadata;


namespace NewTestBlazorApp.discarded
{
    public class BogusDocumentGeneration
    {
        private Faker faker;
        private List<BusinessDocument> documents;

        public BogusDocumentGeneration()
        {
            faker = new Faker("nl");
            documents = new List<BusinessDocument>();
        }


        public void BogusDocuments(int count = 100)
        {
            var extensions = new[] { ".msg", ".docx", ".pdf", ".xlsx", ".txt" };

            for (int i = 0; i < count; i++)
            {
                var extension = faker.PickRandom(extensions);
                var documentName = faker.System.FileName(extension);

                var document = new BusinessDocument
                {
                    DocumentName = documentName,
                    ID = faker.Random.Number(1, 1000000),
                    Identifier = faker.Random.Guid(),
                    SizeInBytes = faker.Random.Number(1000, 1000000),
                    Extension = extension
                };

                documents.Add(document);
            }
        }

        public List<BusinessDocument> GetDocuments()
        {
            return documents;
        }
    }
}
