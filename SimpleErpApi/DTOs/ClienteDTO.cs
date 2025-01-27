namespace SimpleErpApi.DTOs;

public record ClienteDTO
{
  public string Nome { get; set; } = default!;

  public string DocumentoIdentificacao { get; set; } = default!;

  public string Endereco { get; set; } = default!;

  public string Email { get; set; } = default!;

  public string Telefone { get; set; } = default!;
}
