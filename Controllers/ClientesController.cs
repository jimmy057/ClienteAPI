using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClienteAPI.Modelo;
using ClienteAPI.DAL;

namespace ClienteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesApiController : ControllerBase
{
	private readonly AppDbContext _context;

	public ClientesApiController(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet("/")]
	public IActionResult Root() => Ok("API de Clientes corriendo correctamente");

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
	{
		return await _context.Clientes.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Cliente>> GetCliente(int id)
	{
		var cliente = await _context.Clientes.FindAsync(id);
		if (cliente == null)
			return NotFound();

		return cliente;
	}

	[HttpPost]
	public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
	{
		_context.Clientes.Add(cliente);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> PutCliente(int id, Cliente cliente)
	{
		if (id != cliente.Id)
			return BadRequest();

		_context.Entry(cliente).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!_context.Clientes.Any(e => e.Id == id))
				return NotFound();
			throw;
		}

		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteCliente(int id)
	{
		var cliente = await _context.Clientes.FindAsync(id);
		if (cliente == null)
			return NotFound();

		_context.Clientes.Remove(cliente);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	[HttpPost("bulk")]
	public async Task<IActionResult> AddMultiples([FromBody] List<Cliente> clientes)
	{
		if (clientes == null || clientes.Count == 0)
			return BadRequest("Debes enviar al menos un cliente.");

		_context.Clientes.AddRange(clientes);
		await _context.SaveChangesAsync();

		return Ok(clientes);
	}
}

