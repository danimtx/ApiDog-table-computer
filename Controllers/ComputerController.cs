using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDog_table_computer.Context;
using ApiDog_table_computer.Models;
using System.Collections;

namespace ApiDog_table_computer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly AplicationBDContext _context;

        public ComputerController(AplicationBDContext context)
        {
            _context = context;
        }

        //codigo for me
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Computer computer)
        {
            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();
            return Ok("La computadora se agrego correctamente");
        }

        [HttpGet]
        public async Task<ActionResult<List<Computer>>> GetAll()
        {
            return await _context.Computers.ToListAsync();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Computer computer)
        {
            var CModificar = await _context.Computers.FirstOrDefaultAsync(x => x.Id == computer.Id);
            if(CModificar == null)
            {
                return BadRequest("No existe esa computadora");
            }

            CModificar.Placa = computer.Placa;
            CModificar.Procesador = computer.Procesador;
            CModificar.Ram = computer.Ram;
            CModificar.SSD = computer.SSD;
            CModificar.Firmware = computer.Firmware;
            CModificar.Descripcion = computer.Descripcion;

            await _context.SaveChangesAsync();
            return Ok("Computadora actualizada");

        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var CEliminar = await _context.Computers.FirstOrDefaultAsync(x => x.Id == id);
            if(CEliminar == null)
            {
                return BadRequest("No existe es computadora");
            }
            _context.Computers.Remove(CEliminar);
            await _context.SaveChangesAsync();
            return Ok("Computadora eliminada");
        }

        /*
         * Codigo generado automaticamnte
         * 
         * 
         * 
        // GET: api/Computer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computer>>> GetComputers()
        {
            return await _context.Computers.ToListAsync();
        }

        // GET: api/Computer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Computer>> GetComputer(int id)
        {
            var computer = await _context.Computers.FindAsync(id);

            if (computer == null)
            {
                return NotFound();
            }

            return computer;
        }

        // PUT: api/Computer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputer(int id, Computer computer)
        {
            if (id != computer.Id)
            {
                return BadRequest();
            }

            _context.Entry(computer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Computer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Computer>> PostComputer(Computer computer)
        {
            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComputer", new { id = computer.Id }, computer);
        }

        // DELETE: api/Computer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputer(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer == null)
            {
                return NotFound();
            }

            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComputerExists(int id)
        {
            return _context.Computers.Any(e => e.Id == id);
        }*/
    }
}
