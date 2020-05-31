using Assignment2.DTO;
using Assignment2.Models;

namespace Assignment2.Repositories
{
    public interface IClaimRepository : IRepository<Claim>
    {

        FilterdClaimsDTO GetAllClaims(ClaimsFilter claimsFilter);

        void Update(int Id, ClaimDTO claimDTO);

        int DeleteAllClaimsByPolice_No(string Police_No);

    }
}
