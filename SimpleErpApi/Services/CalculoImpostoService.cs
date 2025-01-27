using SimpleErpApi.Models;
using SimpleErpApi.ErrorsExceptions;
using SimpleErpApi.Services.Interfaces;

public class CalculoImpostoService : ICalculoImpostoService
{
  public ImpostosNotaFiscal CalcularImpostos(decimal valorTotal = 0)
  {
    if (valorTotal < 0)
      throw new DefaultErrorException("Parametro valorTotal é obrigatório!", 400);
    var impostos = new ImpostosNotaFiscal
    {
      ICMS = valorTotal * 0.18m,  // Exemplo de ICMS 18%
      IPI = valorTotal * 0.10m,   // Exemplo de IPI 10%
      PIS = valorTotal * 0.0165m, // Exemplo de PIS 1,65%
      COFINS = valorTotal * 0.076m // Exemplo de COFINS 7,6%
    };
    return impostos;
  }
}
