using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleErpApi.ErrorsExceptions;

namespace SimpleErpApi.Models;

[Table("notas_fiscais")]
public class NotaFiscal
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Column("id")]
  public int Id { get; set; }

  [Required]
  [Column("numero_documento")]
  public int NumeroDocumento { get; set; }

  [Column("descricao", TypeName = "text")]
  public string Descricao { get; set; } = default!;

  [Required]
  [Column("status_id")]
  public int StatusId { get; set; }

  [ForeignKey("StatusId")]
  public NotaFiscalStatus NotaFiscalStatus { get; set; } = default!;

  [Required]
  [Column("tipo_id")]
  public int TipoId { get; set; }

  [ForeignKey("TipoId")]
  public NotaFiscalTipo NotaFiscalTipo { get; set; } = default!;

  [Required]
  [Column("cliente_id")]
  public int ClienteId { get; set; }

  [ForeignKey("ClienteId")]
  public Cliente Cliente { get; set; } = default!;

  [Required]
  [Column("data_emissao")]
  public DateTime DataEmissao { get; set; }

 private decimal _valorTotal;
  [Required]
  [Column("valor_total", TypeName = "decimal(18,2)")]
  public decimal ValorTotal
  {
      get => _valorTotal;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("Valor total deve ser positivo!", 400);
          _valorTotal = value;
      }
  }

  private decimal _icms;
  [Required]
  [Column("icms", TypeName = "decimal(18,2)")]
  public decimal ICMS
  {
      get => _icms;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("ICMS deve ser positivo!", 400);
          _icms = value;
      }
  }

  private decimal _ipi;
  [Required]
  [Column("ipi", TypeName = "decimal(18,2)")]
  public decimal IPI
  {
      get => _ipi;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("IPI deve ser positivo!", 400);
          _ipi = value;
      }
  }

  private decimal _pis;
  [Required]
  [Column("pis", TypeName = "decimal(18,2)")]
  public decimal PIS
  {
      get => _pis;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("PIS deve ser positivo!", 400);
          _pis = value;
      }
  }

  private decimal _cofins;
  [Required]
  [Column("cofins", TypeName = "decimal(18,2)")]
  public decimal COFINS
  {
      get => _cofins;
      set
      {
          if (value < 0)
              throw new DefaultErrorException("COFINS deve ser positivo!", 400);
          _cofins = value;
      }
  }
}
