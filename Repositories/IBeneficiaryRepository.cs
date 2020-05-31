using Assignment2.Models;

namespace Assignment2.Repositories
{
    public interface IBeneficiaryRepository : IRepository<Beneficiary>
    {

        void Update(Beneficiary beneficiary);



    }
}
