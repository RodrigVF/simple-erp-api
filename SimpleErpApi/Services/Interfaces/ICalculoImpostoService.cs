using SimpleErpApi.DTOs;
using SimpleErpApi.Models;

namespace SimpleErpApi.Services.Interfaces;


public interface ICalculoImpostoService
{
	ImpostosNotaFiscal CalcularImpostos(decimal valorTotal = 0);
}
