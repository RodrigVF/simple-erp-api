using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleErpApi.ErrorsExceptions;

namespace SimpleErpApi.Models;

[Table("notas_fiscais_produtos")]
public class NotaFiscalProduto
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("id")]
	public int Id { get; set; }

	[Required]
	[Column("nota_fiscal_id")]
	public int NotaFiscalId { get; set; }

	[ForeignKey("NotaFiscalId")]
	public NotaFiscal NotaFiscal { get; set; } = default!;

	[Required]
	[Column("produto_id")]
	public int ProdutoId { get; set; }

	[ForeignKey("ProdutoId")]
	public Produto Produto { get; set; } = default!;

	[Required]
	[Column("quantidade")]
	public int Quantidade { get; set; }

  private decimal _valorUnitario;
	[Required]
	[Column("valor_unitario", TypeName = "decimal(18,2)")]
  public decimal ValorUnitario
  {
    get => _valorUnitario;
    set
    {
      if (value < 0)
        throw new DefaultErrorException("Valor total deve ser positivo!", 400);
      _valorUnitario = value;
    }
  }

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
}
