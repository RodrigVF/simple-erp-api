using SimpleErpApi.ErrorsExceptions;

namespace SimpleErpApi.DTOs;


public record NotaFiscalProdutoDTO
{
  public int Id { get; set; } = default!;

  public int NotaFiscalId { get; set; } = default!;

  public int ProdutoId { get; set; } = default!;

  public int Quantidade { get; set; } = default!;

  private decimal _valorUnitario;
  public decimal ValorUnitario
  {
      get => _valorUnitario;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("Valor total não pode ser negativo!", 400);
          _valorUnitario = value;
      }
  }

  private decimal _valorTotal;
  public decimal ValorTotal
  {
      get => _valorTotal;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("Valor total não pode ser negativo!", 400);
          _valorTotal = value;
      }
  }
}
