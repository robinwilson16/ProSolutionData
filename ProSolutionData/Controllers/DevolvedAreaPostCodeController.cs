using ProSolutionData.Models;
using ProSolutionData.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProSolutionData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevolvedAreaPostCodeController : ControllerBase
    {
        private readonly DevolvedAreaPostCodeService _devolvedAreaPostCodeService;

        public DevolvedAreaPostCodeController(DevolvedAreaPostCodeService devolvedAreaPostCodeService)
        {
            _devolvedAreaPostCodeService = devolvedAreaPostCodeService;
        }

        [HttpGet]
        public ActionResult<List<DevolvedAreaPostCodeModel>?> GetAll() =>
            _devolvedAreaPostCodeService.GetAll();

        [HttpGet("{postCode}")]
        public ActionResult<DevolvedAreaPostCodeModel> Get(string postCode)
        {
            var devolvedAreaPostCode = _devolvedAreaPostCodeService.Get(postCode);

            if (devolvedAreaPostCode == null)
                return NotFound();

            return devolvedAreaPostCode;
        }
    }
}
