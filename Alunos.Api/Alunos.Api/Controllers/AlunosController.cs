using Alunos.Infrastructure.Context;
using Alunos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alunos.Api.Alunos.CreateAluno;
using MediatR;
using Alunos.Api.Alunos.UpdateAluno;
using Alunos.Api.Alunos.DeleteAluno;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound();

            return aluno;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, UpdateAlunoCommand command)
        {
            if (id != command.AlunoId)
                return BadRequest();

            if (ModelState.IsValid)
                await _mediator.Send(command);           

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(CreateAlunoCommand command)
        {
            if (ModelState.IsValid)
                return await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound();

            await _mediator.Send(new DeleteAlunoCommand{ AlunoId = id });

            return NoContent();
        }
    }
}
