
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using Entities.Entities;
using UseCases.Streammers;
using UseCases.Shared.Exceptions;
using Entities.DTOs;

namespace Controller.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StreammersController : ControllerBase 
    {
        private readonly IMediator _mediator;

        public StreammersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<StreamDTO>>> List()
        {
            return await _mediator.Send(new List.Query());
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stream>> GetStream(int Id)
        {
            return await _mediator.Send(new Read.Query{ Id = Id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Update(int Id, Edit.Command command)
        {
            try
            {
                command.Id = Id;
                var result = await _mediator.Send(command);
                return Ok(result);

            } catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            } catch (SaveException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int Id)
        {
            return await _mediator.Send(new Delete.Command { Id = Id });
        }

    }
}
