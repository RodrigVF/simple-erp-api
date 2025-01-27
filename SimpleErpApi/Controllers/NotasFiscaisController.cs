using Microsoft.AspNetCore.Mvc;
using SimpleErpApi.DTOs;
using SimpleErpApi.ErrorsExceptions;
using SimpleErpApi.Services.Interfaces;

namespace SimpleErpApi.Controllers;

[ApiController]
[Route("notas-fiscais")]
public class NotasFiscaisController : ControllerBase
{
	public NotasFiscaisController(INotaFiscalService service, ICalculoImpostoService calculoImpostoService)
	{
		_service = service;
		_calculoImpostoService = calculoImpostoService;
	}

	private INotaFiscalService _service;
	private ICalculoImpostoService _calculoImpostoService;

  [HttpGet]
  public IActionResult GetAll(int pagina, int tipoId, [FromQuery] bool relations = false)
  {
    try
    {
      var notasFiscais = _service.List(pagina, tipoId, relations);
      return StatusCode(200, notasFiscais);
    }
    catch (DefaultErrorException error)
    {
      return StatusCode(error.StatusCode, error.Message);
    }
  }

  [HttpGet("{id:int}")]
  public IActionResult GetOne([FromRoute] int id, [FromQuery] bool relations = false)
  {
    try
    {
      var notaFiscalDb = _service.GetById(id, relations);
      return StatusCode(200, notaFiscalDb);
    }
    catch (DefaultErrorException error)
    {
      return StatusCode(error.StatusCode, error.Message);
    }
  }

	[HttpPost]
	public IActionResult Create([FromBody] NotaFiscalDTO notaFiscalDTO)
	{
		try
		{
			var notaFiscal = _service.Insert(notaFiscalDTO);
			return StatusCode(201, notaFiscal);
		}
		catch (DefaultErrorException error)
		{
			return StatusCode(error.StatusCode, error.Message);
		}

	}

	[HttpPut("{id:int}")]
	public IActionResult Update([FromRoute] int id, [FromBody] NotaFiscalDTO notaFiscalDTO)
	{
		try
		{
			var notaFiscalDb = _service.Update(id, notaFiscalDTO);
			return StatusCode(200, notaFiscalDb);
		}
		catch (DefaultErrorException error)
		{
			return StatusCode(error.StatusCode, error.Message);
		}
	}

  [HttpPatch("{id:int}")]
  public IActionResult UpdateStatus(int id, int statusId)
  {
    try
    {
      var notaFiscalAtualizada = _service.UpdateStatus(id, statusId);
      return Ok(notaFiscalAtualizada);
    }
    catch (Exception ex)
    {
        return NotFound(ex.Message);
    }
  }

	[HttpDelete("{id:int}")]
	public IActionResult Delete([FromRoute] int id)
	{
		try
		{
			_service.Delete(id);
			return StatusCode(204);
		}
		catch (DefaultErrorException error)
		{
			return StatusCode(error.StatusCode, error.Message);
		}
	}

	[HttpGet("calcular-impostos")]
	public IActionResult CalcularImpostos([FromQuery] decimal valorTotal)
	{
		try
		{
			var impostosCalculados = _calculoImpostoService.CalcularImpostos(valorTotal);
			return StatusCode(200, impostosCalculados);
		}
		catch (DefaultErrorException error)
		{
			return StatusCode(error.StatusCode, error.Message);
		}
	}

  [HttpGet("tipos")]
  public IActionResult GetTipos()
  {
    try
    {
      var tipos = _service.ListTipos();
      return Ok(tipos);
    }
    catch (DefaultErrorException error)
    {
      return StatusCode(error.StatusCode, error.Message);
    }
  }

  [HttpGet("status")]
  public IActionResult GetStatus()
  {
    try
    {
      var status = _service.ListStatus();
      return Ok(status);
    }
    catch (DefaultErrorException error)
    {
      return StatusCode(error.StatusCode, error.Message);
    }
  }
}
