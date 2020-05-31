using Assignment2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        [HttpGet]
        public IActionResult GetAllGenders()
        {

            var genders = _unitOfWork.Gender.GetAll();

            return Ok(genders);

        }
    }
}