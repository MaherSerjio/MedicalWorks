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
    public class PolicyController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public PolicyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet("{id}")]
        public IActionResult GetPolicy(int Id)
        {
            var policy = _unitOfWork.Policy.GetPolicyByIdWithBeneficiaries(Id);

            return Ok(policy);
        }

        [HttpGet("WithClaim")]
        public IActionResult GetAllPoliciesWithAtLeastOneClaim()
        {

            var policies = _unitOfWork.Policy.GetAllPolicies();

            return Ok(policies);

        }

        [HttpGet]
        public IActionResult GetAllExistingPolicies()
        {

            var policies = _unitOfWork.Policy.GetAll();

            return Ok(policies);

        }

        [HttpPost]
        public async Task<IActionResult> Add(Policy policy)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (policy.Effective.Date < DateTime.Now.Date)
            {
                return BadRequest(error: "Effective should be greater than today’s date");
            }

            if (policy.Beneficiaries.Count() < 1)
            {
                return BadRequest(error: "There should be at least one beneficiary ");
            }

            var SelfRelationship = 0;
            foreach (var beneficiary in policy.Beneficiaries)
            {
                if (beneficiary.RelationshipId == 1)
                {
                    SelfRelationship++;
                }

            }

            if (SelfRelationship > 1)
                return BadRequest(error: "Only one beneficiary with relationship self is allowed");

            var SumOfPremium = 0;

            foreach (var beneficiary in policy.Beneficiaries)
            {


                if (beneficiary.Age < 10)
                    SumOfPremium += 15;
                else if (beneficiary.Age >= 11 && beneficiary.Age <= 45)
                    SumOfPremium += 30;
                else
                    SumOfPremium += 63;
            }

            policy.Premium = SumOfPremium / policy.Beneficiaries.Count();
            policy.IsValid = true;

            _unitOfWork.Policy.Add(policy);
            await _unitOfWork.SaveAllAsync();


            policy.Police_No = DateTime.Now.Year + "-" + policy.Id;

            await _unitOfWork.SaveAllAsync();

            return Ok(policy);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            _unitOfWork.Policy.Remove(id);

            await _unitOfWork.SaveAllAsync();
            return NoContent();

            throw new Exception($"Deleting policy {id} failed on delete");
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update(Policy policy)
        {

            _unitOfWork.Policy.Update(policy);

            await _unitOfWork.SaveAllAsync();

            return Ok(policy);

            throw new Exception($"Deleting claim {policy.Id} failed on update");
        }






    }
}