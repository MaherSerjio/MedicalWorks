using Assignment2.Data;
using Assignment2.Models;

namespace Assignment2.Repositories
{
    public class RelationshipRepository : Repository<Relationship>, IRelationshipRepository
    {
        private readonly AppDbContext _context;

        public RelationshipRepository(AppDbContext context) : base(context)
        {
            _context = context;


        }

    }
}
