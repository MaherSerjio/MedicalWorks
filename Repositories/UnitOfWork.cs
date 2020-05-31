using Assignment2.Data;
using AutoMapper;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public IClaimRepository Claim { get; private set; }
        public IPolicyRepository Policy { get; private set; }
        public IBeneficiaryRepository Beneficiary { get; private set; }
        public IGenderRepository Gender { get; private set; }
        public IRelationshipRepository Relationship { get; private set; }

        public UnitOfWork(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Claim = new ClaimRepository(context, mapper);
            Policy = new PolicyRepository(context, mapper);
            Beneficiary = new BeneficiaryRepository(context, mapper);
            Gender = new GenderRepository(context);
            Relationship = new RelationshipRepository(context);
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
