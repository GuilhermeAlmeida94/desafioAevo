using Alunos.Infrastructure.Context;
using Alunos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Alunos.Domain.Requests;

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
        public async Task<IActionResult> PutAluno(int id, UpdateAlunoRequest request)
        {
            if (id != request.AlunoId)
                return BadRequest();

            if (ModelState.IsValid)
                await _mediator.Send(request);           

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(CreateAlunoRequest request)
        {
            if (ModelState.IsValid)
                return await _mediator.Send(request);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound();

            await _mediator.Send(new DeleteAlunoRequest{ AlunoId = id });

            return NoContent();
        }
    }
}
