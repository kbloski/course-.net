using CarWorkshop.Infrastructure.Presistance;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.CarWorkshops.Any())
                {
                    var mazdaAso = new CarWorkshop.Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Authorized Service Mazda",
                        ContactDetails = new CarWorkshop.Domain.Entities.CarWorkshopContactDetails
                        {
                            City = "Kraków",
                            Street = "Szewska 2",
                            PostalCode = "30-001",
                            PhoneNumber = "+48699222888"
                        }
                    };

                    mazdaAso.EncodeName();

                    _dbContext.CarWorkshops.Add(mazdaAso);

                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
