using SimpleErpApi.DTOs;
using SimpleErpApi.Models;

namespace SimpleErpApi.Services.Interfaces;


public interface IClienteService
{
	List<Cliente> List(int pagina);

	Cliente GetById(int id);

	Cliente Insert(ClienteDTO clienteDTO);

	Cliente Update(int id, ClienteDTO clienteDTO);

	void Delete(int id);
}
