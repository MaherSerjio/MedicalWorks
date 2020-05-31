using Assignment2.DTO;
using Assignment2.Models;
using Assignment2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public ClaimController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet("{id}")]
        public IActionResult GetClaim(int Id)
        {
            var claim = _unitOfWork.Claim.Get(Id);

            return Ok(claim);
        }

        [HttpPost("filter")]
        public IActionResult GetAllClaims(ClaimsFilter claimsFilter)
        {

            var claims = _unitOfWork.Claim.GetAllClaims(claimsFilter);

            return Ok(claims);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var claims = _unitOfWork.Claim.GetAll();
            return Ok(claims);
        }


        [HttpPost]
        public async Task<IActionResult> Add(Claim claim)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ExistingPolicy = _unitOfWork.Policy.GetPolicyByPolice_No(claim.Police_No);

            if (ExistingPolicy == null)
            {
                return BadRequest(error: "the given policy no is not for an existing policy");
            }


            if (!(ExistingPolicy.Effective < claim.Incured_Date && claim.Incured_Date < ExistingPolicy.Expiry))
            {
                return BadRequest(error: "IncurredDate should fall within the Effective and Expiry of the policy");
            }

            if (claim.Claimed_Amount < 1)
            {
                return BadRequest(error: "ClaimedAmount should be greater than 1");
            }



            _unitOfWork.Claim.Add(claim);
            await _unitOfWork.SaveAllAsync();


            if (ExistingPolicy.Claims != null)
            {
                ExistingPolicy.Claims = ExistingPolicy.Claims.Concat(new[] { claim });
            }
            else
            {
                ExistingPolicy.Claims = new[] { claim };
            }


            _unitOfWork.Policy.Update(ExistingPolicy);
            await _unitOfWork.SaveAllAsync();

            return Ok(claim);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllClaimsByPolice_No([FromBody]string Police_No)
        {

            if (Police_No == null)
            {
                return BadRequest(error: "Policy_No is required");
            }


            int NumberOfDeletedClaims = _unitOfWork.Claim.DeleteAllClaimsByPolice_No(Police_No);

            await _unitOfWork.SaveAllAsync();

            return Ok(NumberOfDeletedClaims);

            throw new Exception($"Deleting claims failed on delete");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            _unitOfWork.Claim.Remove(id);

            await _unitOfWork.SaveAllAsync();
            return NoContent();

            throw new Exception($"Deleting claim {id} failed on delete");
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int Id, ClaimDTO claimdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ClaimFromDb = _unitOfWork.Claim.Get(Id);

            var ExistingPolicy = _unitOfWork.Policy.GetPolicyByPolice_No(ClaimFromDb.Police_No);


            if (ExistingPolicy.Effective > claimdto.Incured_Date || claimdto.Incured_Date > ExistingPolicy.Expiry)
            {
                return BadRequest(error: "IncurredDate should fall within the Effective and Expiry of the policy");
            }

            if (claimdto.Claimed_Amount < 1)
            {
                return BadRequest(error: "ClaimedAmount should be greater than 1");
            }


            _unitOfWork.Claim.Update(Id, claimdto);

            await _unitOfWork.SaveAllAsync();

            return NoContent();

            throw new Exception($"Updating claim {Id} failed on update");
        }








    }
}