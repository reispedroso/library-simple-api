using Ecc.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecc.Controllers;

[Route("api/[controller]/{entity}")]
public class GenericController<T> : ControllerBase where T : class
{
    private readonly IRepository<T> _repository;
    public GenericController(IRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] T entity)
    {
        await _repository.Create(entity);
        return Ok();
    }


    [HttpGet("getbyid/{guid}")]
    public async Task<ActionResult<T>> GetById(Guid guid)
    {
        var entity = await _repository.GetById(guid);

        if (entity == null)
        {
            return NotFound();
        }

        return entity;
    }
    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<T>>> GetAll()
    {
        var entities = await _repository.GetAll();
        return entities.ToList();
    }
}