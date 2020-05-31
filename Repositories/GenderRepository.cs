using Assignment2.Data;
using Assignment2.Models;

namespace Assignment2.Repositories
{
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        private readonly AppDbContext _context;

        public GenderRepository(AppDbContext context) : base(context)
        {
            _context = context;


        }
    }
}
