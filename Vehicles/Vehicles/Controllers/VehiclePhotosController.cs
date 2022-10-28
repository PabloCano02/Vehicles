using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicles.Data;
using Vehicles.DTOs;
using Vehicles.Entities;
using Vehicles.Services;

namespace Vehicles.Controllers
{
    [ApiController]
    [Route("api/vehiclephotos")]
    public class VehiclePhotosController : ControllerBase
    {
        private readonly ILogger<VehiclePhotosController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorage _fileStorage;
        private readonly string _container = "Files";

        public VehiclePhotosController(ILogger<VehiclePhotosController> logger, ApplicationDbContext context, IMapper mapper, IFileStorage fileStorage)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _fileStorage = fileStorage;
        }

        //Search
        [HttpGet]
        public async Task<ActionResult<List<VehiclePhotoDTO>>> GetVehiclePhotos()
        {
            var vehiclePhoto = await _context.VehiclePhotos.OrderBy(vp => vp.Id).ToListAsync();
            return _mapper.Map<List<VehiclePhotoDTO>>(vehiclePhoto);
        }

        //Search by parameter
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VehiclePhotoDTO>> GetVehiclePhoto(int id)
        {
            var vehiclephoto = await _context.VehiclePhotos.FirstOrDefaultAsync(vp => vp.Id == id);

            if (vehiclephoto == null)
            {
                return NotFound();
            }

            return _mapper.Map<VehiclePhotoDTO>(vehiclephoto);

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult<VehiclePhoto>> PostVehiclePhoto([FromForm] VehiclePhotoCreationDTO vehiclePhotoCreationDTO)
        {
            var file = _mapper.Map<VehiclePhoto>(vehiclePhotoCreationDTO);

            if (vehiclePhotoCreationDTO.ImageId != null)
            {
                file.ImageId = await _fileStorage.SaveFile(_container, vehiclePhotoCreationDTO.ImageId);
            }

            _context.Add(file);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpPut("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        //public async Task<ActionResult<VehiclePhoto>> PutVehiclePhoto(int id, [FromForm] VehiclePhotoDTO vehiclePhotoDTO)
        //{
        //    if (id != vehiclePhotoDTO.Id)
        //    {
        //        return BadRequest("No coinciden los campos a editar");
        //    }

        //    var exist = await _context.VehiclePhotos.AnyAsync(vp => vp.Id == id);

        //    if (!exist)
        //    {
        //        return NotFound();
        //    }

        //    _context.Update(vehiclePhotoDTO);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult> DeleteVehiclePhoto(int id)
        {
            VehiclePhoto vehiclePhoto = await _context.VehiclePhotos.FirstOrDefaultAsync(vp => vp.Id == id);

            if (vehiclePhoto == null)
            {
                return NotFound();
            }

            _context.Remove(vehiclePhoto);
            await _context.SaveChangesAsync();
            return NoContent(); //204
        }
    }
}
