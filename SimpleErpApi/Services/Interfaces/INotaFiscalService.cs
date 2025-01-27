using SimpleErpApi.DTOs;
using SimpleErpApi.Models;

namespace SimpleErpApi.Services.Interfaces;


public interface INotaFiscalService
{
	List<NotaFiscal> List(int pagina, int tipoId, bool relations);

	NotaFiscal GetById(int id, bool relations);

	NotaFiscal Insert(NotaFiscalDTO notaFiscalDTO);

	NotaFiscal Update(int id, NotaFiscalDTO notaFiscalDTO);

  NotaFiscal UpdateStatus(int id, int statusId);

	void Delete(int id);

  List<NotaFiscalTipo> ListTipos();

  List<NotaFiscalStatus> ListStatus();
}
