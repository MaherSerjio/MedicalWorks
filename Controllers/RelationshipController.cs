using Assignment2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RelationshipController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        [HttpGet]
        public IActionResult GetAllRelationship()
        {

            var relationships = _unitOfWork.Relationship.GetAll();

            return Ok(relationships);

        }

    }
}