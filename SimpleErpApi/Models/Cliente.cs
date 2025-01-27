using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleErpApi.Models;

[Table("clientes")]
public class Cliente
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Column("id")]
  public int Id { get; set; }

  [Required]
  [StringLength(255)]
  [Column("nome")]
  public string Nome { get; set; } = default!;

  [Required]
  [Column("documento_identificador")]
  public string DocumentoIdentificacao { get; set; } = default!;

  [Required]
  [StringLength(255)]
  [Column("endereco")]
  public string Endereco { get; set; } = default!;

  [Required]
  [StringLength(255)]
  [Column("email")]
  public string Email { get; set; } = default!;

  [Required]
  [StringLength(15)]
  [Column("telefone")]
  public string Telefone { get; set; } = default!;
}
