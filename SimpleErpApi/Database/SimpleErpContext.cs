using Microsoft.EntityFrameworkCore;
using SimpleErpApi.Models;

public class SimpleErpContext : DbContext
{
  #nullable disable

  public SimpleErpContext(DbContextOptions<SimpleErpContext> options) : base(options) { }

  public DbSet<NotaFiscal> NotasFiscais { get; set; }

  public DbSet<NotaFiscalProduto> NotasFiscaisProdutos { get; set; }

  public DbSet<Cliente> Clientes { get; set; }

  public DbSet<Produto> Produtos { get; set; }

  public DbSet<NotaFiscalStatus> NotasFiscaisStatus { get; set; }
  public DbSet<NotaFiscalTipo> NotasFiscaisTipos { get; set; }



  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Cliente>().HasIndex(c => c.DocumentoIdentificacao).IsUnique().HasDatabaseName("IX_Clientes_DocumentoIdentificacao_UNIQUE");
    modelBuilder.Entity<NotaFiscal>().HasIndex(c => c.NumeroDocumento).IsUnique().HasDatabaseName("IX_NotasFiscais_NumeroDocumento_UNIQUE");


    modelBuilder.Entity<NotaFiscalStatus>().HasData(
      new NotaFiscalStatus { Id = 1, Nome = "RASCUNHO", Descricao = "Rascunho da nota fiscal (Ainda pode ser alterado e excluido)" },
      new NotaFiscalStatus { Id = 2, Nome = "LANÇADA", Descricao = "Nota fiscal lançada (Não pode mais ser alterada ou excluida)" }
    );

    modelBuilder.Entity<NotaFiscalTipo>().HasData(
      new NotaFiscalTipo { Id = 1, Nome = "ENTRADA", Descricao = "Nota fiscal de entrada (compra)" },
      new NotaFiscalTipo { Id = 2, Nome = "SAÍDA", Descricao = "Nota fiscal de saída (venda)" }
    );
  }
}
