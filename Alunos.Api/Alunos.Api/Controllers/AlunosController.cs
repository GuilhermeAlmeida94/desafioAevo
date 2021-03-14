using Alunos.Infrastructure.Context;
using Alunos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alunos.Api.Alunos.CreateAluno;
using MediatR;
using Alunos.Api.Alunos.UpdateAluno;

namespace Alunos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public AlunosController(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, UpdateAlunoCommand command)
        {
            if (id != command.AlunoId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
                await _mediator.Send(command);           

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(CreateAlunoCommand command)
        {
            if (ModelState.IsValid)
                return await _mediator.Send(command);
            
            return BadRequest(ModelState);
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }
    }
}
