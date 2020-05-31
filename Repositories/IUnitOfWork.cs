using System;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBeneficiaryRepository Beneficiary { get; }
        IClaimRepository Claim { get; }
        IPolicyRepository Policy { get; }
        IGenderRepository Gender { get; }
        IRelationshipRepository Relationship { get; }
        Task SaveAllAsync();
    }
}
