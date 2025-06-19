using Bogus;
using NewTestBlazorApp.Models;

namespace NewTestBlazorApp.discarded
{
    public class BogusUserGeneration
    {
        private Faker faker;
        private List<BusinessExternalEmployee> employee;

        public BogusUserGeneration()
        {
            faker = new Faker("nl");
            employee = new List<BusinessExternalEmployee>();
        }

        public void BogusUsers()
        {
            for (int i = 0; i < 5; i++)
            {
                var firstName = faker.Name.FirstName();
                var lastName = faker.Name.LastName();
                var intials = firstName.Substring(0,1).ToUpper() + lastName.Substring(0, 1).ToUpper();

                var businessEmployees = new BusinessExternalEmployee
                {
                    ID = faker.Random.Number(1, 100),
                    Identifier = faker.Random.Guid(),
                    Initials = intials,
                    EmployeeName = firstName + " " + lastName,
                };

                employee.Add(businessEmployees);
            }
        }

        public List<BusinessExternalEmployee> GetEmployees()
        {
            return employee;
        }

    }
}
