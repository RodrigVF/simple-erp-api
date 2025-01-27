using SimpleErpApi.ErrorsExceptions;

public class ImpostosNotaFiscal
{
  private decimal _icms;
  public decimal ICMS
  {
      get => _icms;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("Parametro ICMS não pode ser negativo!", 400);
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
              throw new DefaultErrorException("Parametro IPI não pode ser negativo!", 400);
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
              throw new DefaultErrorException("Parametro PIS não pode ser negativo!", 400);
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
        throw new DefaultErrorException("Parametro COFINS não pode ser negativo!", 400);
      _cofins = value;
    }
  }
}
