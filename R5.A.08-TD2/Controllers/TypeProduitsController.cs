using Microsoft.AspNetCore.Mvc;
using R5.A._08_TD2.Models;
using R5.A._08_TD2.Repositories;

[Route("api/[controller]")]
[ApiController]
public class TypeProduitsController : ControllerBase
{
    private readonly ITypeProduitRepository _repository;

    public TypeProduitsController(ITypeProduitRepository repository)
    {
        _repository = repository;
    }

    // GET: api/TypeProduits
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TypeProduit>>> GetTypeProduit()
    {
        var types = await _repository.GetAllAsync();
        return Ok(types);
    }

    // GET: api/TypeProduits/5
    [HttpGet("{idtypeproduit}")]
    public async Task<ActionResult<TypeProduit>> GetTypeProduit(int idtypeproduit)
    {
        var typeproduit = await _repository.GetByIdAsync(idtypeproduit);

        if (typeproduit == null)
        {
            return NotFound();
        }

        return typeproduit;
    }

    // PUT: api/TypeProduits/5
    [HttpPut("{idtypeproduit}")]
    public async Task<IActionResult> PutTypeProduit(
        int idtypeproduit,
        TypeProduit typeproduit)
    {
        if (idtypeproduit != typeproduit.IdTypeProduit)
        {
            return BadRequest();
        }

        if (!_repository.Exists(idtypeproduit))
        {
            return NotFound();
        }

        await _repository.UpdateAsync(typeproduit);

        return NoContent();
    }

    // POST: api/TypeProduits
    [HttpPost]
    public async Task<ActionResult<TypeProduit>> PostTypeProduit(
        TypeProduit typeproduit)
    {
        await _repository.AddAsync(typeproduit);

        return CreatedAtAction(
            nameof(GetTypeProduit),
            new { idtypeproduit = typeproduit.IdTypeProduit },
            typeproduit
        );
    }

    // DELETE: api/TypeProduits/5
    [HttpDelete("{idtypeproduit}")]
    public async Task<IActionResult> DeleteTypeProduit(int idtypeproduit)
    {
        var typeproduit = await _repository.GetByIdAsync(idtypeproduit);

        if (typeproduit == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(idtypeproduit);

        return NoContent();
    }
}