using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicles.Data;
using Vehicles.DTOs;
using Vehicles.Entities;

namespace Vehicles.Controllers
{
    [ApiController]
    [Route("api/details")]
    public class DetailsController : ControllerBase
    {
        private readonly ILogger<DetailsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DetailsController(ILogger<DetailsController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        //Search
        [HttpGet]
        public async Task<ActionResult<List<DetailDTO>>> GetDetails()
        {
            var detail = await _context.Details.OrderBy(b => b.Id).ToListAsync();
            return _mapper.Map<List<DetailDTO>>(detail);
        }

        //Search by parameter
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DetailDTO>> GetDetail(int id)
        {
            var detail = await _context.Details.FirstOrDefaultAsync(d => d.Id == id);

            if (detail == null)
            {
                return NotFound();
            }

            return _mapper.Map<DetailDTO>(detail);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult<Detail>> PostDetail([FromBody] DetailCreationDTO detailCreationDTO)
        {
            var detail = _mapper.Map<Detail>(detailCreationDTO);

            _context.Add(detail);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult<Detail>> PutDetail(int id, Detail detail)
        {
            if (id != detail.Id)
            {
                return BadRequest("No coinciden los campos a editar");
            }

            var exist = await _context.Details.AnyAsync(d => d.Id == id);

            if (!exist)
            {
                return NotFound();
            }

            _context.Update(detail);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<IActionResult> DeleteDetail(int id)
        {
            Detail detail = await _context.Details.FirstOrDefaultAsync(d => d.Id == id);

            if (detail == null)
            {
                return NotFound();
            }

            _context.Details.Remove(detail);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
