using GridColor.Models;
using GridColor.Services;
using Microsoft.AspNetCore.Mvc;

namespace GridColor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ControllerBase
    {
        private readonly ILogger<GridController> _logger;
        private readonly GridService _gridService;

        public GridController(ILogger<GridController> logger, GridService gridService)
        {
            _logger = logger;
            _gridService = gridService;
        }

        [HttpPost(Name = "")]
        public IEnumerable<GridModel> Get([FromQuery] int Size, [FromQuery]  int RangeFrom, [FromQuery] int RangeTo)
        {
            return _gridService.GetGrid(Size, RangeFrom, RangeTo);
        }
    }
}