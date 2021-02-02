using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Core.DTO;
using Core.Service;

namespace Core
{
    public partial class CatalogarPatrimonioContext : DbContext
    {
        public CatalogarPatrimonioContext()
        {
        }

        public CatalogarPatrimonioContext(DbContextOptions<CatalogarPatrimonioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Almoxarifado> Almoxarifado { get; set; }
        public virtual DbSet<Dialogoservico> Dialogoservico { get; set; }
        public virtual DbSet<Disponibilidade> Disponibilidade { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Entrada> Entrada { get; set; }
        public virtual DbSet<Entradamaterial> Entradamaterial { get; set; }
        public virtual DbSet<Estoquematerial> Estoquematerial { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Patrimonio> Patrimonio { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Predio> Predio { get; set; }
        public virtual DbSet<Servico> Servico { get; set; }
        public virtual DbSet<ServicoMaterial> Servicomaterial { get; set; }
        public virtual DbSet<Statusservico> Statusservico { get; set; }
        public virtual DbSet<Tipomaterial> Tipomaterial { get; set; }
        public virtual DbSet<Tipopatrimonio> Tipopatrimonio { get; set; }
        public virtual DbSet<TipoServico> TipoServico { get; set; }
        public virtual DbSet<Transferencia> Transferencia { get; set; }
        public virtual DbSet<Transferenciamaterial> Transferenciamaterial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almoxarifado>(entity =>
            {
                entity.ToTable("almoxarifado");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("fk_tb_almoxarifado_empresa_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("idEmpresa")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Almoxarifado)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("fk_tb_almoxarifado_empresa");
            });

            modelBuilder.Entity<Dialogoservico>(entity =>
            {
                entity.ToTable("dialogoservico");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_dialogoServico_pessoa1_idx");

                entity.HasIndex(e => e.IdServico)
                    .HasName("fk_dialogoServico_servico1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataHora)
                    .HasColumnName("dataHora")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdPessoa)
                    .HasColumnName("idPessoa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdServico)
                    .HasColumnName("idServico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Mensagem)
                    .HasColumnName("mensagem")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Dialogoservico)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dialogoServico_pessoa1");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.Dialogoservico)
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dialogoServico_servico1");
            });

            modelBuilder.Entity<Disponibilidade>(entity =>
            {
                entity.ToTable("disponibilidade");

                entity.HasIndex(e => e.IdLocal)
                    .HasName("fk_Disponibilidade_Local1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dia)
                    .HasColumnName("dia")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Hora)
                    .HasColumnName("hora")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdLocal)
                    .HasColumnName("idLocal")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.Disponibilidade)
                    .HasForeignKey(d => d.IdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Disponibilidade_Local1");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresa");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrada>(entity =>
            {
                entity.ToTable("entrada");

                entity.HasIndex(e => e.IdFornecedor)
                    .HasName("fk_entradaMaterial_fornecedor1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataEntrada)
                    .HasColumnName("dataEntrada")
                    .HasColumnType("date");

                entity.Property(e => e.IdFornecedor)
                    .HasColumnName("idFornecedor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NotaFiscal).HasColumnName("notaFiscal");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.IdFornecedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_entradaMaterial_fornecedor1");
            });

            modelBuilder.Entity<Entradamaterial>(entity =>
            {
                entity.HasKey(e => new { e.IdMaterial, e.IdEntrada })
                    .HasName("PRIMARY");

                entity.ToTable("entradamaterial");

                entity.HasIndex(e => e.IdEntrada)
                    .HasName("fk_material_has_entrada_entrada1_idx");

                entity.HasIndex(e => e.IdMaterial)
                    .HasName("fk_material_has_entrada_material1_idx");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("idMaterial")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEntrada)
                    .HasColumnName("idEntrada")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.QuantidadeUtilizada)
                    .HasColumnName("quantidadeUtilizada")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdEntradaNavigation)
                    .WithMany(p => p.Entradamaterial)
                    .HasForeignKey(d => d.IdEntrada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_material_has_entrada_entrada1");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Entradamaterial)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_material_has_entrada_material1");
            });

            modelBuilder.Entity<Estoquematerial>(entity =>
            {
                entity.HasKey(e => new { e.IdMaterial, e.IdAlmoxarifado })
                    .HasName("PRIMARY");

                entity.ToTable("estoquematerial");

                entity.HasIndex(e => e.IdAlmoxarifado)
                    .HasName("fk_material_has_almoxarifado_almoxarifado1_idx");

                entity.HasIndex(e => e.IdMaterial)
                    .HasName("fk_material_has_almoxarifado_material1_idx");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("idMaterial")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdAlmoxarifado)
                    .HasColumnName("idAlmoxarifado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdAlmoxarifadoNavigation)
                    .WithMany(p => p.Estoquematerial)
                    .HasForeignKey(d => d.IdAlmoxarifado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_material_has_almoxarifado_almoxarifado1");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Estoquematerial)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_material_has_almoxarifado_material1");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.ToTable("fornecedor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("categoria")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Local>(entity =>
            {
                entity.ToTable("local");

                entity.HasIndex(e => e.IdPredio)
                    .HasName("fk_Local_Predio1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPredio)
                    .HasColumnName("idPredio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdPredioNavigation)
                    .WithMany(p => p.Local)
                    .HasForeignKey(d => d.IdPredio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Local_Predio1");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("material");

                entity.HasIndex(e => e.IdTipoMaterial)
                    .HasName("fk_material_tipoMaterial1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeveVincularMaterial)
                    .HasColumnName("deveVincularMaterial")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdTipoMaterial)
                    .HasColumnName("idTipoMaterial")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.StatusSolicitação)
                    .HasColumnName("statusSolicitação")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdTipoMaterialNavigation)
                    .WithMany(p => p.Material)
                    .HasForeignKey(d => d.IdTipoMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_material_tipoMaterial1");
            });

            modelBuilder.Entity<Patrimonio>(entity =>
            {
                entity.ToTable("patrimonio");

                entity.HasIndex(e => e.IdLocal)
                    .HasName("fk_Patrimonio_Local1_idx");

                entity.HasIndex(e => e.IdTipoPatrimonio)
                    .HasName("fk_patrimonio_tipoPatrimonio1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdLocal)
                    .HasColumnName("idLocal")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoPatrimonio)
                    .HasColumnName("idTipoPatrimonio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.QrCode)
                    .HasColumnName("qrCode")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.Patrimonio)
                    .HasForeignKey(d => d.IdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Patrimonio_Local1");

                entity.HasOne(d => d.IdTipoPatrimonioNavigation)
                    .WithMany(p => p.Patrimonio)
                    .HasForeignKey(d => d.IdTipoPatrimonio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_patrimonio_tipoPatrimonio1");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa");

                entity.HasIndex(e => e.Cpf)
                    .HasName("CPF_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("fk_tb_pessoa_empresa_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("dataNascimento")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("idEmpresa")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("enum('Administrador','Gestor','Almoxarife','Tecnico','Solicitante')")
                    .HasDefaultValueSql("'''Solicitante'''");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("fk_tb_pessoa_empresa");
            });

            modelBuilder.Entity<Predio>(entity =>
            {
                entity.ToTable("predio");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("fk_local_empresa1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("idEmpresa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Predio)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_local_empresa1");
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.ToTable("servico");

                entity.HasIndex(e => e.IdAlmoxarife)
                    .HasName("fk_servico_pessoa1_idx");

                entity.HasIndex(e => e.IdLocal)
                    .HasName("fk_Servico_Local1_idx");

                entity.HasIndex(e => e.IdSolicitante)
                    .HasName("fk_tb_ordemServico_solicitante_idx");

                entity.HasIndex(e => e.IdStatusServico)
                    .HasName("fk_servico_statusServico1_idx");

                entity.HasIndex(e => e.IdTecnico)
                    .HasName("fk_servico_pessoa2_idx");

                entity.HasIndex(e => e.IdTipoServico)
                    .HasName("fk_tb_ordemServico_tipoServico_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataAutorizacao)
                    .HasColumnName("dataAutorizacao")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DataConclusao)
                    .HasColumnName("dataConclusao")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DataSolicitacao)
                    .HasColumnName("dataSolicitacao")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdAlmoxarife)
                    .HasColumnName("idAlmoxarife")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdLocal)
                    .HasColumnName("idLocal")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSolicitante)
                    .HasColumnName("idSolicitante")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdStatusServico)
                    .HasColumnName("idStatusServico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTecnico)
                    .HasColumnName("idTecnico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoServico)
                    .HasColumnName("idTipoServico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observacao)
                    .HasColumnName("observacao")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdAlmoxarifeNavigation)
                    .WithMany(p => p.ServicoIdAlmoxarifeNavigation)
                    .HasForeignKey(d => d.IdAlmoxarife)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servico_pessoa1");

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.Servico)
                    .HasForeignKey(d => d.IdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Servico_Local1");

                entity.HasOne(d => d.IdSolicitanteNavigation)
                    .WithMany(p => p.ServicoIdSolicitanteNavigation)
                    .HasForeignKey(d => d.IdSolicitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_ordemServico_solicitante");

                entity.HasOne(d => d.IdStatusServicoNavigation)
                    .WithMany(p => p.Servico)
                    .HasForeignKey(d => d.IdStatusServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servico_statusServico1");

                entity.HasOne(d => d.IdTecnicoNavigation)
                    .WithMany(p => p.ServicoIdTecnicoNavigation)
                    .HasForeignKey(d => d.IdTecnico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servico_pessoa2");

                entity.HasOne(d => d.IdTipoServicoNavigation)
                    .WithMany(p => p.Servico)
                    .HasForeignKey(d => d.IdTipoServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tb_ordemServico_tipoServico");
            });

            modelBuilder.Entity<ServicoMaterial>(entity =>
            {
                entity.HasKey(e => new { e.IdMaterial, e.IdServico })
                    .HasName("PRIMARY");

                entity.ToTable("servicomaterial");

                entity.HasIndex(e => e.IdMaterial)
                    .HasName("fk_material_has_Servico_material1_idx");

                entity.HasIndex(e => e.IdPatrimonio)
                    .HasName("fk_servicoMaterial_patrimonio1_idx");

                entity.HasIndex(e => e.IdServico)
                    .HasName("fk_material_has_Servico_Servico1_idx");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("idMaterial")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdServico)
                    .HasColumnName("idServico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPatrimonio)
                    .HasColumnName("idPatrimonio")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Servicomaterial)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_material_has_Servico_material1");

                entity.HasOne(d => d.IdPatrimonioNavigation)
                    .WithMany(p => p.Servicomaterial)
                    .HasForeignKey(d => d.IdPatrimonio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servicoMaterial_patrimonio1");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.Servicomaterial)
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_material_has_Servico_Servico1");
            });

            modelBuilder.Entity<Statusservico>(entity =>
            {
                entity.ToTable("statusservico");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tipomaterial>(entity =>
            {
                entity.ToTable("tipomaterial");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipopatrimonio>(entity =>
            {
                entity.ToTable("tipopatrimonio");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoServico>(entity =>
            {
                entity.ToTable("tiposervico");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transferencia>(entity =>
            {
                entity.ToTable("transferencia");

                entity.HasIndex(e => e.IdAlmoxarifadoDestino)
                    .HasName("fk_transferirMaterial_almoxarifado2_idx");

                entity.HasIndex(e => e.IdAlmoxarifadoOrigem)
                    .HasName("fk_transferirMaterial_almoxarifado1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdAlmoxarifadoDestino)
                    .HasColumnName("idAlmoxarifadoDestino")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdAlmoxarifadoOrigem)
                    .HasColumnName("idAlmoxarifadoOrigem")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdAlmoxarifadoDestinoNavigation)
                    .WithMany(p => p.TransferenciaIdAlmoxarifadoDestinoNavigation)
                    .HasForeignKey(d => d.IdAlmoxarifadoDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transferirMaterial_almoxarifado2");

                entity.HasOne(d => d.IdAlmoxarifadoOrigemNavigation)
                    .WithMany(p => p.TransferenciaIdAlmoxarifadoOrigemNavigation)
                    .HasForeignKey(d => d.IdAlmoxarifadoOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transferirMaterial_almoxarifado1");
            });

            modelBuilder.Entity<Transferenciamaterial>(entity =>
            {
                entity.HasKey(e => new { e.IdMaterial, e.IdTransferencia })
                    .HasName("PRIMARY");

                entity.ToTable("transferenciamaterial");

                entity.HasIndex(e => e.IdMaterial)
                    .HasName("fk_Material_has_Transferencia_Material1_idx");

                entity.HasIndex(e => e.IdTransferencia)
                    .HasName("fk_Material_has_Transferencia_Transferencia1_idx");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("idMaterial")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTransferencia)
                    .HasColumnName("idTransferencia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Transferenciamaterial)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Material_has_Transferencia_Material1");

                entity.HasOne(d => d.IdTransferenciaNavigation)
                    .WithMany(p => p.Transferenciamaterial)
                    .HasForeignKey(d => d.IdTransferencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Material_has_Transferencia_Transferencia1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
