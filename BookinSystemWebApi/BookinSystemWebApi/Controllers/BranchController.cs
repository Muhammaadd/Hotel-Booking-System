using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookinSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService branchService;

        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(branchService.GetAllBranchesDto());
        }
    }
}
