using Microsoft.AspNetCore.Mvc;
using SimpleErpApi.DTOs;
using SimpleErpApi.ErrorsExceptions;
using SimpleErpApi.Services.Interfaces;

namespace SimpleErpApi.Controllers;

[ApiController]
[Route("clientes")]
public class ClientesController : ControllerBase
{
  private readonly IClienteService _service;

  public ClientesController(IClienteService service)
  {
    _service = service;
  }

  [HttpGet]
  public IActionResult GetAll(int pagina = 0)
  {
    try
    {
      var clientes = _service.List(pagina);
      return Ok(clientes);
    }
    catch (DefaultErrorException error)
    {
      return StatusCode(error.StatusCode, error.Message);
    }
  }

  [HttpGet("{id:int}")]
  public IActionResult GetOne([FromRoute] int id)
  {
    try
    {
      var clienteDb = _service.GetById(id);
      return Ok(clienteDb);
    }
    catch (DefaultErrorException error)
    {
      return StatusCode(error.StatusCode, error.Message);
    }
  }

  [HttpPost]
  public IActionResult Create([FromBody] ClienteDTO clienteDTO)
  {
    try
    {
      var cliente = _service.Insert(clienteDTO);
      return CreatedAtAction(nameof(GetOne), new { id = cliente.Id }, cliente);
    }
    catch (DefaultErrorException error)
    {
      return StatusCode(error.StatusCode, error.Message);
    }
  }

  [HttpPut("{id:int}")]
  public IActionResult Update([FromRoute] int id, [FromBody] ClienteDTO clienteDTO)
  {
    try
    {
      var clienteDb = _service.Update(id, clienteDTO);
      return Ok(clienteDb);
    }
    catch (DefaultErrorException error)
    {
      return StatusCode(error.StatusCode, error.Message);
    }
  }

  [HttpDelete("{id:int}")]
  public IActionResult Delete([FromRoute] int id)
  {
    try
    {
      _service.Delete(id);
      return NoContent();
    }
    catch (DefaultErrorException error)
    {
      return StatusCode(error.StatusCode, error.Message);
    }
  }
}
