using Assignment2.Data;
using Assignment2.Models;
using AutoMapper;
using System.Linq;

namespace Assignment2.Repositories
{
    public class BeneficiaryRepository : Repository<Beneficiary>, IBeneficiaryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BeneficiaryRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;

        }


        public void Update(Beneficiary beneficiary)
        {
            var objFromDb = _context.Beneficiaries.FirstOrDefault(b => b.Id == beneficiary.Id);

            _mapper.Map<Beneficiary>(objFromDb);

            _context.SaveChanges();

        }
    }
}
