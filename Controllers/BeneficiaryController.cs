using Assignment2.Models;
using Assignment2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public BeneficiaryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        [HttpGet("{id}")]
        public IActionResult GetBeneficiary(int Id)
        {
            var beneficiary = _unitOfWork.Beneficiary.Get(Id);

            return Ok(beneficiary);
        }

        [HttpGet]
        public IActionResult GetAllBeneficiaries()
        {
            var beneficiaries = _unitOfWork.Beneficiary.GetAll();

            return Ok(beneficiaries);


        }


        [HttpPost]
        public async Task<IActionResult> Add(Beneficiary beneficiary)
        {
            _unitOfWork.Beneficiary.Add(beneficiary);
            await _unitOfWork.SaveAllAsync();

            return Ok(beneficiary);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            _unitOfWork.Beneficiary.Remove(id);

            await _unitOfWork.SaveAllAsync();
            return NoContent();

            throw new Exception($"Deleting beneficiary {id} failed on delete");
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Beneficiary beneficiary)
        {

            _unitOfWork.Beneficiary.Update(beneficiary);

            await _unitOfWork.SaveAllAsync();

            return Ok(beneficiary);

            throw new Exception($"Deleting beneficiary {beneficiary.Id} failed on update");
        }


    }
}