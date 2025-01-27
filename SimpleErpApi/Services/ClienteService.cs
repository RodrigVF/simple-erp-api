using SimpleErpApi.DTOs;
using SimpleErpApi.ErrorsExceptions;
using SimpleErpApi.Models;
using SimpleErpApi.Services.Interfaces;
using DocumentValidator;
using System.Text.RegularExpressions;

namespace SimpleErpApi.Services;

public class ClienteService : IClienteService
{
  private readonly SimpleErpContext _db;

  public ClienteService(SimpleErpContext db)
  {
    _db = db;
  }

  public List<Cliente> List(int pagina = 0)
  {
    if (pagina < 1)
    {
      return _db.Clientes.ToList();
    }

    int limit = 10;
    int offset = (pagina - 1) * limit;
    return _db.Clientes.Skip(offset).Take(limit).ToList();
  }

  public Cliente GetById(int id)
  {
    var clienteDb = _db.Clientes.Find(id);
    if (clienteDb == null)
      throw new DefaultErrorException($"Cliente de Id: {id} não encontrado!", 404);

    return clienteDb;
  }

public Cliente Insert(ClienteDTO clienteDTO)
{
  if (string.IsNullOrEmpty(clienteDTO.Nome))
    throw new DefaultErrorException("O campo Nome é obrigatório", 400);

  clienteDTO.DocumentoIdentificacao = Regex.Replace(clienteDTO.DocumentoIdentificacao, @"\D", "");

  if (!CnpjValidation.Validate(clienteDTO.DocumentoIdentificacao) && !CpfValidation.Validate(clienteDTO.DocumentoIdentificacao))
    throw new DefaultErrorException("O CPF ou CNPJ informado é inválido", 400);

  var cliente = new Cliente
  {
    Nome = clienteDTO.Nome,
    DocumentoIdentificacao = clienteDTO.DocumentoIdentificacao,
    Endereco = clienteDTO.Endereco,
    Telefone = clienteDTO.Telefone,
    Email = clienteDTO.Email
  };

  _db.Clientes.Add(cliente);
  _db.SaveChanges();
  return cliente;
}

public Cliente Update(int id, ClienteDTO clienteDTO)
{
  if (string.IsNullOrEmpty(clienteDTO.Nome))
    throw new DefaultErrorException("O campo Nome é obrigatório", 400);

  var clienteDb = _db.Clientes.Find(id);
  if (clienteDb == null)
    throw new DefaultErrorException($"Cliente de Id: {id} não encontrado!", 404);

  clienteDTO.DocumentoIdentificacao = Regex.Replace(clienteDTO.DocumentoIdentificacao, @"\D", "");

  if (!CnpjValidation.Validate(clienteDTO.DocumentoIdentificacao) && !CpfValidation.Validate(clienteDTO.DocumentoIdentificacao))
    throw new DefaultErrorException("O CPF ou CNPJ informado é inválido", 400);

  clienteDb.Nome = clienteDTO.Nome;
  clienteDb.DocumentoIdentificacao = clienteDTO.DocumentoIdentificacao;
  clienteDb.Endereco = clienteDTO.Endereco;
  clienteDb.Telefone = clienteDTO.Telefone;
  clienteDb.Email = clienteDTO.Email;

  _db.Clientes.Update(clienteDb);
  _db.SaveChanges();
  return clienteDb;
}

  public void Delete(int id)
  {
    var clienteDb = _db.Clientes.Find(id);
    if (clienteDb == null)
      throw new DefaultErrorException($"Cliente de Id: {id} não encontrado!", 404);

    _db.Clientes.Remove(clienteDb);
    _db.SaveChanges();
  }
}
