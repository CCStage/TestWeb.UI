using Bogus;
using NewTestBlazorApp.Models;
using System.Net;

namespace NewTestBlazorApp.discarded
{
    public class BogusFolderGeneration
    {
        private Faker faker;
        private List<BusinessExternalEmployee> employees;
        private List<BusinessExternalDossier> dossiers;
        private List<BusinessDossierFolder> folders;

        public BogusFolderGeneration()
        {
            faker = new Faker("nl");
            employees = new List<BusinessExternalEmployee>();
            dossiers = new List<BusinessExternalDossier>();
            folders = new List<BusinessDossierFolder>();
        }

        public void BogusEmployees()
        {
            for (int i = 0; i < 5; i++)
            {
                var firstName = faker.Name.FirstName();
                var lastName = faker.Name.LastName();
                var initials = firstName.Substring(0, 1).ToUpper() + lastName.Substring(0, 1).ToUpper();

                var businessEmployee = new BusinessExternalEmployee
                {
                    ID = faker.Random.Number(1, 100),
                    Identifier = faker.Random.Guid(),
                    BusinessUnitID = faker.Random.Number(1, 100),
                    Initials = initials,
                    EmployeeName = firstName + " " + lastName
                };

                employees.Add(businessEmployee);
            }
        }

        public void BogusDossiers()
        {
            foreach (var employee in employees)
            {
                var numberOfDossiers = faker.Random.Number(1, 2);
                for (int j = 0; j < numberOfDossiers; j++)
                {
                    var businessDossier = new BusinessExternalDossier
                    {
                        ID = faker.Random.Number(1, 1000),
                        Identifier = faker.Random.Guid(),
                        BusinessUnitID = faker.Random.Number(1, 100),
                        DossierNumber = faker.Random.Number(1, 999999),
                        DossierName = faker.Lorem.Word(),
                        ExternalEmployeeID = employee.ID,
                        IsInactive = faker.Random.Bool()
                    };

                    dossiers.Add(businessDossier);
                }
            }
        }

        public void BogusFolders()
        {
            foreach (var dossier in dossiers)
            {
                var numberOfFolders = faker.Random.Number(1, 4);
                for (int k = 0; k < numberOfFolders; k++)
                {
                    var businessFolder = new BusinessDossierFolder
                    {
                        ID = faker.Random.Number(1, 1000),
                        Identifier = faker.Random.Guid(),
                        BusinessUnitID = (int?)dossier.BusinessUnitID,
                        ExternalDossierID = (int?)dossier.ID,
                        DossierFolderParentID = null, // parent folder
                        DossierFolderName = faker.Lorem.Word()
                    };

                    folders.Add(businessFolder);

                    // Generate documents for this folder
                    GenerateDocumentsForFolder(businessFolder);

                    CreateSubFolders(businessFolder, 4); // 4 levels of subfolders 
                }
            }
        }

        private void GenerateDocumentsForFolder(BusinessDossierFolder folder)
        {
            var numberOfDocuments = faker.Random.Number(1, 5);

            var extensions = new List<string> { ".docx", ".pdf", ".txt", ".xlsx", ".pptx", ".msg", ".rtf", ".html" };

            for (int d = 0; d < numberOfDocuments; d++)
            {
                var extension = extensions[faker.Random.Number(0, extensions.Count - 1)];

                var document = new BusinessDocument
                {
                    ID = faker.Random.Number(1, 1000),
                    Identifier = faker.Random.Guid(),
                    DocumentName = faker.Lorem.Word() + extension,
                    SizeInBytes = faker.Random.Number(1000, 10000),
                    Extension = extension
                };

                folder.Documents.Add(document);
            }
        }


        private void CreateSubFolders(BusinessDossierFolder parentFolder, int remainingDepth)
        {
            if (remainingDepth <= 0) return;

            var numberOfSubFolders = faker.Random.Number(1, 4);

            for (int s = 0; s < numberOfSubFolders; s++)
            {
                var subFolder = new BusinessDossierFolder
                {
                    ID = faker.Random.Number(1, 1000),
                    Identifier = faker.Random.Guid(),
                    BusinessUnitID = parentFolder.BusinessUnitID,
                    ExternalDossierID = parentFolder.ExternalDossierID,
                    DossierFolderParentID = parentFolder.ID,
                    DossierFolderName = faker.Lorem.Word()
                };

                folders.Add(subFolder);
                GenerateDocumentsForFolder(subFolder);
                CreateSubFolders(subFolder, remainingDepth - 1);
            }
        }
    }
}
