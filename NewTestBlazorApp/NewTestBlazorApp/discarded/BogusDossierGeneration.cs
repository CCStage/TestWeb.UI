using Bogus;
using NewTestBlazorApp.Components.Pages;
using NewTestBlazorApp.Models;

namespace NewTestBlazorApp.discarded
{
    public class BogusDossierGeneration
    {
        private Faker faker;
        private List<BusinessExternalDossier> Dossiers;
        private List<BusinessExternalEmployee> Employees;


        public BogusDossierGeneration()
        {
            faker = new Faker("nl");
            Dossiers = new List<BusinessExternalDossier>();
            Employees = new List<BusinessExternalEmployee>();
        }

        public void BogusDossiers()
        {
            foreach (var employee in Employees)
            {
                var numberOfDossiers = faker.Random.Number(1, 100);
                for(int d = 0; d < numberOfDossiers; d++)
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

                    Dossiers.Add(businessDossier);
                }           
            }
        }
        public List<BusinessExternalDossier> GetDossiers()
        {
            return Dossiers;
        }
    }
}
