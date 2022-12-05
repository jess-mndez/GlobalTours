using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entidades;
using API.Controllers;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public LugaresController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Lugar>>> GetLugares()
        {
            var Lugares = await _db.Lugar.ToListAsync();

            return Ok(Lugares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> GetLugar(int id)
        {
            return await _db.Lugar.FindAsync(id);
        }

    }
}