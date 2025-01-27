namespace SimpleErpApi.DTOs;


public record ProdutoDTO
{
	public string Nome {get; set; } = default!;

  public string Descricao {get; set; } = default!;
}
