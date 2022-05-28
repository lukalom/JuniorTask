using JuniorTask.Infrastructure.Entities;
using JuniorTask.Infrastructure.IConfiguration;
using Microsoft.EntityFrameworkCore;

namespace JuniorTask.Infrastructure.Data.DB_Seed
{
    public class GenderSeed : ISeeder
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenderSeed(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Index { get; set; } = 1;

        public async Task Seed()
        {
            if (await _unitOfWork.Gender.Query().CountAsync() == 0)
            {
                var gender = new List<Gender>()
                {
                    new() { Name = Enums.Gender.Male.ToString()},
                    new() { Name = Enums.Gender.Female.ToString()}
                };
                await _unitOfWork.Gender.AddRangeAsync(gender);
                await _unitOfWork.SaveAsync();
            }
        }
    }

}
