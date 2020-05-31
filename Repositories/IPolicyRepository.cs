using Assignment2.DTO;
using Assignment2.Models;
using System.Collections.Generic;

namespace Assignment2.Repositories
{
    public interface IPolicyRepository : IRepository<Policy>
    {
        void Update(Policy policy);

        IEnumerable<PolicyDTO> GetAllPolicies();
        Policy GetPolicyByIdWithBeneficiaries(int id);
        Policy GetPolicyByPolice_No(string Police_No);
    }
}
