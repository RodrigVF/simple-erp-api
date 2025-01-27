using Microsoft.EntityFrameworkCore;
using SimpleErpApi.DTOs;
using SimpleErpApi.ErrorsExceptions;
using SimpleErpApi.Models;
using SimpleErpApi.Services.Interfaces;

namespace SimpleErpApi.Services;


public class NotaFiscalService : INotaFiscalService
{
	public NotaFiscalService(SimpleErpContext db)
	{
		_db = db;
	}

	private SimpleErpContext _db;

public List<NotaFiscal> List(int pagina = 0, int tipoId = 0, bool relations = false)
{
  if (pagina < 1)
  {
    return _db.NotasFiscais.ToList();
  }

  int limit = 10;
  int offset = (pagina - 1) * limit;

  var query = _db.NotasFiscais.AsQueryable();

  if (tipoId > 0)
  {
    query = query.Where(nf => nf.TipoId == tipoId);
  }

  // Se 'relations=true', inclui todas as relações
  if (relations)
  {
    query = query
      .Include(nf => nf.NotaFiscalStatus)
      .Include(nf => nf.NotaFiscalTipo)
      .Include(nf => nf.Cliente);
  }

  return query.Skip(offset).Take(limit).ToList();
}

	public NotaFiscal GetById(int id, bool relations = false)
	{
    var query = _db.NotasFiscais.AsQueryable();

    if (relations)
    {
      query = query
        .Include(nf => nf.NotaFiscalStatus)
        .Include(nf => nf.NotaFiscalTipo)
        .Include(nf => nf.Cliente);
    }

    var notaFiscalDb = query.FirstOrDefault(nf => nf.Id == id);
		if(notaFiscalDb == null)
      throw new DefaultErrorException($"Nota Fiscal de Id: {id} não encontrada!", 404);

		return notaFiscalDb;
	}

	public NotaFiscal Insert(NotaFiscalDTO notaFiscalDTO)
	{
		if (notaFiscalDTO.NumeroDocumento < 1)
			throw new DefaultErrorException("O campo NumeroDocumento é obrigatório", 400);

    var notaFiscal = new NotaFiscal
    {
        NumeroDocumento = notaFiscalDTO.NumeroDocumento,
        StatusId = notaFiscalDTO.StatusId,
        TipoId = notaFiscalDTO.TipoId,
        ClienteId = notaFiscalDTO.ClienteId,
        Descricao = notaFiscalDTO.Descricao,
        DataEmissao = notaFiscalDTO.DataEmissao,
        ValorTotal = notaFiscalDTO.ValorTotal,
        ICMS = notaFiscalDTO.ICMS,
        IPI = notaFiscalDTO.IPI,
        PIS = notaFiscalDTO.PIS,
        COFINS = notaFiscalDTO.COFINS
    };

		_db.NotasFiscais.Add(notaFiscal);
		_db.SaveChanges();
		return notaFiscal;
	}

	public NotaFiscal Update(int id, NotaFiscalDTO notaFiscalDTO)
	{
		if (notaFiscalDTO.NumeroDocumento < 1)
			throw new DefaultErrorException("O campo NumeroDocumento é obrigatório", 400);

		var notaFiscalDb = _db.NotasFiscais.Find(id);
		if (notaFiscalDb == null)
			throw new DefaultErrorException($"Nota Fiscal de Id: {id} não encontrada!", 404);

		foreach (var property in typeof(NotaFiscalDTO).GetProperties())
		{
			var value = property.GetValue(notaFiscalDTO);

			var entityProperty = typeof(NotaFiscal).GetProperty(property.Name);
			if (entityProperty != null && entityProperty.CanWrite)
			{
				entityProperty.SetValue(notaFiscalDb, value);
			}
		}

		_db.NotasFiscais.Update(notaFiscalDb);
		_db.SaveChanges();

		return notaFiscalDb;
	}

    public NotaFiscal UpdateStatus(int id, int statusId)
    {
      if (statusId < 1)
			  throw new DefaultErrorException("O campo statusId é obrigatório", 400);

      var notaFiscalDb = _db.NotasFiscais.Find(id);
      if (notaFiscalDb == null)
      {
          throw new Exception($"Nota Fiscal de Id: {id} não encontrada!");
      }

      // Atualiza apenas o status
      notaFiscalDb.StatusId = statusId;

      _db.NotasFiscais.Update(notaFiscalDb);
      _db.SaveChanges();

      return notaFiscalDb;
    }

	public void Delete(int id)
	{
		var notaFiscalDb = _db.NotasFiscais.Find(id);
		if(notaFiscalDb == null)
			throw new DefaultErrorException($"Nota Fiscal de Id: {id} não encontrada!", 404);

		_db.NotasFiscais.Remove(notaFiscalDb);
		_db.SaveChanges();
	}

  public List<NotaFiscalTipo> ListTipos()
  {
      return _db.NotasFiscaisTipos.ToList();
  }

  public List<NotaFiscalStatus> ListStatus()
  {
      return _db.NotasFiscaisStatus.ToList();
  }
}
