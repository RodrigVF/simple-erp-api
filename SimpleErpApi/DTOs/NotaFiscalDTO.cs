using SimpleErpApi.ErrorsExceptions;

namespace SimpleErpApi.DTOs;

public record NotaFiscalDTO
{
  public int NumeroDocumento { get; set; } = default!;

  public int StatusId { get; set; } = default!;

  public int TipoId { get; set; } = default!;

  public int ClienteId { get; set; } = default!;

  public string Descricao { get; set; } = default!;

  public DateTime DataEmissao { get; set; } = default!;

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

  private decimal _icms;
  public decimal ICMS
  {
      get => _icms;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("ICMS não pode ser negativo!", 400);
          _icms = value;
      }
  }

  private decimal _ipi;
  public decimal IPI
  {
      get => _ipi;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("IPI não pode ser negativo!", 400);
          _ipi = value;
      }
  }

  private decimal _pis;
  public decimal PIS
  {
      get => _pis;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("PIS não pode ser negativo!", 400);
          _pis = value;
      }
  }

  private decimal _cofins;
  public decimal COFINS
  {
      get => _cofins;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("COFINS não pode ser negativo!", 400);
          _cofins = value;
      }
  }
}
