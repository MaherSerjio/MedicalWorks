using Assignment2.Data;
using Assignment2.DTO;
using Assignment2.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2.Repositories
{
    public class PolicyRepository : Repository<Policy>, IPolicyRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PolicyRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<PolicyDTO> GetAllPolicies()
        {
            var policies = _context.Policies.Where(p => p.Claims.Count() >= 1).ToList();

            List<PolicyDTO> policyDTOs = new List<PolicyDTO>();

            foreach (var policy in policies)
            {
                PolicyDTO policyDTO = new PolicyDTO();
                policyDTO = _mapper.Map(policy, policyDTO);
                policyDTO.NumberOfSubmittedClaims = _context.Claims.Where(c => c.Police_No == policy.Police_No).Count();
                policyDTOs.Add(policyDTO);
            }

            return policyDTOs;



        }
        public Policy GetPolicyByIdWithBeneficiaries(int id)
        {
            var policy = _context.Policies.Include(p => p.Beneficiaries).FirstOrDefault(p => p.Id == id);

            return policy;
        }


        public Policy GetPolicyByPolice_No(string Police_No)
        {
            var policy = _context.Policies.FirstOrDefault(p => p.Police_No == Police_No);

            return policy;
        }

        public void Update(Policy policy)
        {
            var objFromDb = _context.Policies.FirstOrDefault(b => b.Id == policy.Id);

            _mapper.Map<Policy>(objFromDb);

            _context.SaveChanges();

        }


    }
}
