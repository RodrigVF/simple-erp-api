using SimpleErpApi.DTOs;
using SimpleErpApi.ErrorsExceptions;
using SimpleErpApi.Models;
using SimpleErpApi.Services.Interfaces;

namespace SimpleErpApi.Services;

public class ProdutoService : IProdutoService
{
  private readonly SimpleErpContext _db;

  public ProdutoService(SimpleErpContext db)
  {
    _db = db;
  }

  public List<Produto> List(int pagina = 1)
  {
    if (pagina < 1) pagina = 1;
    int limit = 10;
    int offset = (pagina - 1) * limit;
    return _db.Produtos.Skip(offset).Take(limit).ToList();
  }

  public Produto GetById(int id)
  {
    var produtoDb = _db.Produtos.Find(id);
    if (produtoDb == null)
        throw new DefaultErrorException($"Produto de Id: {id} não encontrado!", 404);

    return produtoDb;
  }

  public Produto Insert(ProdutoDTO produtoDTO)
  {
    if (string.IsNullOrEmpty(produtoDTO.Nome))
        throw new DefaultErrorException("O campo Nome é obrigatório", 400);

    var produto = new Produto
    {
        Nome = produtoDTO.Nome,
        Descricao = produtoDTO.Descricao
    };

    _db.Produtos.Add(produto);
    _db.SaveChanges();
    return produto;
  }

  public Produto Update(int id, ProdutoDTO produtoDTO)
  {
    if (string.IsNullOrEmpty(produtoDTO.Nome))
        throw new DefaultErrorException("O campo Nome é obrigatório", 400);

    var produtoDb = _db.Produtos.Find(id);
    if (produtoDb == null)
        throw new DefaultErrorException($"Produto de Id: {id} não encontrado!", 404);

    produtoDb.Nome = produtoDTO.Nome;
    produtoDb.Descricao = produtoDTO.Descricao;

    _db.Produtos.Update(produtoDb);
    _db.SaveChanges();
    return produtoDb;
  }

  public void Delete(int id)
  {
    var produtoDb = _db.Produtos.Find(id);
    if (produtoDb == null)
        throw new DefaultErrorException($"Produto de Id: {id} não encontrado!", 404);

    _db.Produtos.Remove(produtoDb);
    _db.SaveChanges();
  }
}
