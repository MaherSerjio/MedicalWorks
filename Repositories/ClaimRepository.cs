using Assignment2.Data;
using Assignment2.DTO;
using Assignment2.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2.Repositories
{
    public class ClaimRepository : Repository<Claim>, IClaimRepository
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ClaimRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;

        }

        public int DeleteAllClaimsByPolice_No(string Police_No)
        {
            var claims = _context.Claims.Where(c => c.Police_No == Police_No).ToList();

            int NumberOfClaimsDeleted = claims.Count();

            foreach (var claim in claims)
            {
                _context.Remove(claim);
            }

            _context.SaveChanges();
            return NumberOfClaimsDeleted;

        }

        public FilterdClaimsDTO GetAllClaims(ClaimsFilter claimsFilter)
        {

            FilterdClaimsDTO filterdClaimsdto = new FilterdClaimsDTO();
            filterdClaimsdto.FilterdClaims = new List<Claim>();

            filterdClaimsdto.NumberOfClaimsReturned = filterdClaimsdto.FilterdClaims.Count();

            // If user did not supply a filter
            if (claimsFilter.Police_No == null && claimsFilter.Claimed_Amount_From == null
                && claimsFilter.Claimed_Amount_To == null && claimsFilter.Incured_Date_From == null
                && claimsFilter.Claimed_Amount_To == null)
            {
                var claims = _context.Claims
                  .OrderByDescending(c => c.Claimed_Amount)
                  .Skip((claimsFilter.PageNumber - 1) * claimsFilter.PageSize)
                  .Take(claimsFilter.PageSize)
                  .ToList();

                filterdClaimsdto.FilterdClaims.AddRange(claims);
                filterdClaimsdto.NumberOfClaimsReturned = filterdClaimsdto.FilterdClaims.Count();
            }
            else if (claimsFilter.Police_No != null)
            {

                // If user did supply only a policy No
                var claims = _context.Claims
                .Where(c => c.Police_No == claimsFilter.Police_No)
                .OrderByDescending(c => c.Claimed_Amount)
                .Skip((claimsFilter.PageNumber - 1) * claimsFilter.PageSize)
                .Take(claimsFilter.PageSize)
                .ToList();

                filterdClaimsdto.FilterdClaims.AddRange(claims);
                filterdClaimsdto.NumberOfClaimsReturned = filterdClaimsdto.FilterdClaims.Count();


                // If user did supply  a policy No and ClaimedAmount From and To
                if (claimsFilter.Claimed_Amount_From != null && claimsFilter.Claimed_Amount_To != null)
                {
                    filterdClaimsdto.FilterdClaims.Clear();

                    var claimsAmountFilter = _context.Claims
                   .Where(c => (c.Police_No == claimsFilter.Police_No
                             && c.Claimed_Amount >= claimsFilter.Claimed_Amount_From)
                             && c.Claimed_Amount <= claimsFilter.Claimed_Amount_To)
                    .OrderByDescending(c => c.Claimed_Amount)
                    .Skip((claimsFilter.PageNumber - 1) * claimsFilter.PageSize)
                    .Take(claimsFilter.PageSize)
                    .ToList();

                    filterdClaimsdto.FilterdClaims.AddRange(claimsAmountFilter);
                    filterdClaimsdto.NumberOfClaimsReturned = filterdClaimsdto.FilterdClaims.Count();
                }

                // If user did supply  a policy No and IncuredDate From and To
                if (claimsFilter.Incured_Date_From != null && claimsFilter.Incured_Date_To != null)
                {
                    filterdClaimsdto.FilterdClaims.Clear();

                    var claimsIncuredFilter = _context.Claims
                   .Where(c => (c.Police_No == claimsFilter.Police_No
                             && c.Incured_Date >= claimsFilter.Incured_Date_From)
                             && c.Incured_Date <= claimsFilter.Incured_Date_To)
                    .OrderByDescending(c => c.Claimed_Amount)
                    .Skip((claimsFilter.PageNumber - 1) * claimsFilter.PageSize)
                    .Take(claimsFilter.PageSize)
                   .ToList();

                    filterdClaimsdto.FilterdClaims.AddRange(claimsIncuredFilter);
                    filterdClaimsdto.NumberOfClaimsReturned = filterdClaimsdto.FilterdClaims.Count();
                }

            }
            // If user did supply only  Claimed_Amount_From and To 
            else if (claimsFilter.Claimed_Amount_From != null && claimsFilter.Claimed_Amount_To != null)
            {
                filterdClaimsdto.FilterdClaims.Clear();

                var claimsAmountFilter = _context.Claims
               .Where(c => (c.Claimed_Amount >= claimsFilter.Claimed_Amount_From)
                         && c.Claimed_Amount <= claimsFilter.Claimed_Amount_To)
                .OrderByDescending(c => c.Claimed_Amount)
                .Skip((claimsFilter.PageNumber - 1) * claimsFilter.PageSize)
                .Take(claimsFilter.PageSize)
                .ToList();

                filterdClaimsdto.FilterdClaims.AddRange(claimsAmountFilter);
                filterdClaimsdto.NumberOfClaimsReturned = filterdClaimsdto.FilterdClaims.Count();
            }
            // If user did supply only Incured_Date From and To 
            else if (claimsFilter.Incured_Date_From != null && claimsFilter.Incured_Date_To != null)
            {
                filterdClaimsdto.FilterdClaims.Clear();

                var claimsIncuredFilter = _context.Claims
               .Where(c => (c.Incured_Date >= claimsFilter.Incured_Date_From)
                         && c.Incured_Date <= claimsFilter.Incured_Date_To)
                .OrderByDescending(c => c.Claimed_Amount)
                .Skip((claimsFilter.PageNumber - 1) * claimsFilter.PageSize)
                .Take(claimsFilter.PageSize)
                .ToList();

                filterdClaimsdto.FilterdClaims.AddRange(claimsIncuredFilter);
                filterdClaimsdto.NumberOfClaimsReturned = filterdClaimsdto.FilterdClaims.Count();
            }


            return filterdClaimsdto;



        }

        public void Update(int Id, ClaimDTO claimDTO)
        {
            var ClaimFromDb = _context.Claims.FirstOrDefault(c => c.Id == Id);

            _mapper.Map(claimDTO, ClaimFromDb);

            _context.SaveChanges();

        }
    }
}
