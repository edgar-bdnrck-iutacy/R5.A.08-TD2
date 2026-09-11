using Microsoft.AspNetCore.Mvc;
using R5.A._08_TD2.Models;
using R5.A._08_TD2.Repositories;

[Route("api/[controller]")]
[ApiController]
public class MarquesController : ControllerBase
{
    private readonly IMarqueRepository _repository;

    public MarquesController(IMarqueRepository repository)
    {
        _repository = repository;
    }

    // GET: api/Marques
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Marque>>> GetMarque()
    {
        var marques = await _repository.GetAllAsync();
        return Ok(marques);
    }

    // GET: api/Marques/5
    [HttpGet("{idmarque}")]
    public async Task<ActionResult<Marque>> GetMarque(int idmarque)
    {
        var marque = await _repository.GetByIdAsync(idmarque);

        if (marque == null)
        {
            return NotFound();
        }

        return marque;
    }

    // PUT: api/Marques/5
    [HttpPut("{idmarque}")]
    public async Task<IActionResult> PutMarque(int idmarque, Marque marque)
    {
        if (idmarque != marque.IdMarque)
        {
            return BadRequest();
        }

        if (!_repository.Exists(idmarque))
        {
            return NotFound();
        }

        await _repository.UpdateAsync(marque);

        return NoContent();
    }

    // POST: api/Marques
    [HttpPost]
    public async Task<ActionResult<Marque>> PostMarque(Marque marque)
    {
        await _repository.AddAsync(marque);

        return CreatedAtAction(
            nameof(GetMarque),
            new { idmarque = marque.IdMarque },
            marque
        );
    }

    // DELETE: api/Marques/5
    [HttpDelete("{idmarque}")]
    public async Task<IActionResult> DeleteMarque(int idmarque)
    {
        var marque = await _repository.GetByIdAsync(idmarque);

        if (marque == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(idmarque);

        return NoContent();
    }
}