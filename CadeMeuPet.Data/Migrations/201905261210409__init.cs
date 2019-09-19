namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        EspecieAnimalId = c.Int(nullable: false),
                        RacaAnimalId = c.Int(nullable: false),
                        CorAnimalId = c.Int(nullable: false),
                        PorteAnimalId = c.Int(nullable: false),
                        Identificacao = c.Boolean(nullable: false),
                        Caracteristica = c.String(nullable: false, maxLength: 500, unicode: false),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.CorAnimal", t => t.CorAnimalId)
                .ForeignKey("dbo.EspecieAnimal", t => t.EspecieAnimalId)
                .ForeignKey("dbo.RacaAnimal", t => t.RacaAnimalId)
                .ForeignKey("dbo.PorteAnimal", t => t.PorteAnimalId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioId)
                .Index(t => t.EspecieAnimalId)
                .Index(t => t.RacaAnimalId)
                .Index(t => t.CorAnimalId)
                .Index(t => t.PorteAnimalId)
                .Index(t => t.Usuario_UsuarioId);
            
            CreateTable(
                "dbo.CorAnimal",
                c => new
                    {
                        CorAnimalId = c.Int(nullable: false, identity: true),
                        Cor = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CorAnimalId);
            
            CreateTable(
                "dbo.EspecieAnimal",
                c => new
                    {
                        EspecieAnimalId = c.Int(nullable: false, identity: true),
                        Especie = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.EspecieAnimalId);
            
            CreateTable(
                "dbo.RacaAnimal",
                c => new
                    {
                        RacaAnimalId = c.Int(nullable: false, identity: true),
                        Raca = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.RacaAnimalId);
            
            CreateTable(
                "dbo.PorteAnimal",
                c => new
                    {
                        PorteAnimalId = c.Int(nullable: false, identity: true),
                        Porte = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.PorteAnimalId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 10, unicode: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        RedeSocial = c.String(maxLength: 100, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        NomeCidade = c.String(maxLength: 100, unicode: false),
                        Estado_EstadoId = c.Int(),
                        Localizacao_LocalizacaoId = c.Int(),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.Estado", t => t.Estado_EstadoId)
                .ForeignKey("dbo.Localizacao", t => t.Localizacao_LocalizacaoId)
                .Index(t => t.Estado_EstadoId)
                .Index(t => t.Localizacao_LocalizacaoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        NomeEstado = c.String(maxLength: 100, unicode: false),
                        Localizacao_LocalizacaoId = c.Int(),
                    })
                .PrimaryKey(t => t.EstadoId)
                .ForeignKey("dbo.Localizacao", t => t.Localizacao_LocalizacaoId)
                .Index(t => t.Localizacao_LocalizacaoId);
            
            CreateTable(
                "dbo.Localizacao",
                c => new
                    {
                        LocalizacaoId = c.Int(nullable: false, identity: true),
                        Bairro = c.String(maxLength: 250, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        DataLocalizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LocalizacaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estado", "Localizacao_LocalizacaoId", "dbo.Localizacao");
            DropForeignKey("dbo.Cidade", "Localizacao_LocalizacaoId", "dbo.Localizacao");
            DropForeignKey("dbo.Cidade", "Estado_EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Animal", "Usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Animal", "PorteAnimalId", "dbo.PorteAnimal");
            DropForeignKey("dbo.Animal", "RacaAnimalId", "dbo.RacaAnimal");
            DropForeignKey("dbo.Animal", "EspecieAnimalId", "dbo.EspecieAnimal");
            DropForeignKey("dbo.Animal", "CorAnimalId", "dbo.CorAnimal");
            DropIndex("dbo.Estado", new[] { "Localizacao_LocalizacaoId" });
            DropIndex("dbo.Cidade", new[] { "Localizacao_LocalizacaoId" });
            DropIndex("dbo.Cidade", new[] { "Estado_EstadoId" });
            DropIndex("dbo.Animal", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Animal", new[] { "PorteAnimalId" });
            DropIndex("dbo.Animal", new[] { "CorAnimalId" });
            DropIndex("dbo.Animal", new[] { "RacaAnimalId" });
            DropIndex("dbo.Animal", new[] { "EspecieAnimalId" });
            DropTable("dbo.Localizacao");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Usuario");
            DropTable("dbo.PorteAnimal");
            DropTable("dbo.RacaAnimal");
            DropTable("dbo.EspecieAnimal");
            DropTable("dbo.CorAnimal");
            DropTable("dbo.Animal");
        }
    }
}
