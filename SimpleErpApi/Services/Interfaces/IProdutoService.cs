using SimpleErpApi.DTOs;
using SimpleErpApi.Models;

namespace SimpleErpApi.Services.Interfaces;

public interface IProdutoService
{
  List<Produto> List(int pagina = 1);
  Produto GetById(int id);
  Produto Insert(ProdutoDTO produtoDTO);
  Produto Update(int id, ProdutoDTO produtoDTO);
  void Delete(int id);
}
