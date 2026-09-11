using Microsoft.AspNetCore.Mvc;
using R5.A._08_TD2.Models;
using R5.A._08_TD2.Repositories;

[Route("api/[controller]")]
[ApiController]
public class ProduitsController : ControllerBase
{
    private readonly IProduitRepository _repository;

    public ProduitsController(IProduitRepository repository)
    {
        _repository = repository;
    }

    // GET: api/Produits
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produit>>> GetProduit()
    {
        var produits = await _repository.GetAllAsync();
        return Ok(produits);
    }

    // GET: api/Produits/5
    [HttpGet("{idproduit}")]
    public async Task<ActionResult<Produit>> GetProduit(int idproduit)
    {
        var produit = await _repository.GetByIdAsync(idproduit);

        if (produit == null)
        {
            return NotFound();
        }

        return produit;
    }

    // PUT: api/Produits/5
    [HttpPut("{idproduit}")]
    public async Task<IActionResult> PutProduit(int idproduit, Produit produit)
    {
        if (idproduit != produit.IdProduit)
        {
            return BadRequest();
        }

        if (!_repository.Exists(idproduit))
        {
            return NotFound();
        }

        await _repository.UpdateAsync(produit);

        return NoContent();
    }

    // POST: api/Produits
    [HttpPost]
    public async Task<ActionResult<Produit>> PostProduit(Produit produit)
    {
        await _repository.AddAsync(produit);

        return CreatedAtAction(
            nameof(GetProduit),
            new { idproduit = produit.IdProduit },
            produit
        );
    }

    // DELETE: api/Produits/5
    [HttpDelete("{idproduit}")]
    public async Task<IActionResult> DeleteProduit(int idproduit)
    {
        var produit = await _repository.GetByIdAsync(idproduit);

        if (produit == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(idproduit);

        return NoContent();
    }
}