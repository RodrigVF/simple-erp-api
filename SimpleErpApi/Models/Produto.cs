using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleErpApi.Models;

[Table("produtos")]
public class Produto
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  [Column("id")]
  public int Id { get; set; }

  [Required]
  [StringLength(255)]
  [Column("nome")]
  public string Nome { get; set; } = default!;

  [Column("descricao", TypeName = "text")]
  public string Descricao { get; set; } = default!;
}
