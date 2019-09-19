namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_05062019_1832 : DbMigration
    {
        public override void Up()
        {
           // DropForeignKey("dbo.TAB_CIDADE", "Localizacao_LocalizacaoId", "dbo.TAB_LOCALIZACAO");
           // DropForeignKey("dbo.TAB_ESTADO", "Localizacao_LocalizacaoId", "dbo.TAB_LOCALIZACAO");
            DropIndex("dbo.TAB_CIDADE", new[] { "Localizacao_LocalizacaoId" });
            DropIndex("dbo.TAB_ESTADO", new[] { "Localizacao_LocalizacaoId" });
            AddColumn("dbo.TAB_LOCALIZACAO", "EstadoId", c => c.Int(nullable: false));
            AddColumn("dbo.TAB_LOCALIZACAO", "CidadeId", c => c.Int(nullable: false));
            CreateIndex("dbo.TAB_LOCALIZACAO", "EstadoId");
            CreateIndex("dbo.TAB_LOCALIZACAO", "CidadeId");
            AddForeignKey("dbo.TAB_LOCALIZACAO", "CidadeId", "dbo.TAB_CIDADE", "CidadeId");
            AddForeignKey("dbo.TAB_LOCALIZACAO", "EstadoId", "dbo.TAB_ESTADO", "EstadoId");
            //DropColumn("dbo.TAB_CIDADE", "Localizacao_LocalizacaoId");
            //DropColumn("dbo.TAB_ESTADO", "Localizacao_LocalizacaoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TAB_ESTADO", "Localizacao_LocalizacaoId", c => c.Int());
            AddColumn("dbo.TAB_CIDADE", "Localizacao_LocalizacaoId", c => c.Int());
            DropForeignKey("dbo.TAB_LOCALIZACAO", "EstadoId", "dbo.TAB_ESTADO");
            DropForeignKey("dbo.TAB_LOCALIZACAO", "CidadeId", "dbo.TAB_CIDADE");
            DropIndex("dbo.TAB_LOCALIZACAO", new[] { "CidadeId" });
            DropIndex("dbo.TAB_LOCALIZACAO", new[] { "EstadoId" });
            DropColumn("dbo.TAB_LOCALIZACAO", "CidadeId");
            DropColumn("dbo.TAB_LOCALIZACAO", "EstadoId");
            CreateIndex("dbo.TAB_ESTADO", "Localizacao_LocalizacaoId");
            CreateIndex("dbo.TAB_CIDADE", "Localizacao_LocalizacaoId");
            AddForeignKey("dbo.TAB_ESTADO", "Localizacao_LocalizacaoId", "dbo.TAB_LOCALIZACAO", "LocalizacaoId");
            AddForeignKey("dbo.TAB_CIDADE", "Localizacao_LocalizacaoId", "dbo.TAB_LOCALIZACAO", "LocalizacaoId");
        }
    }
}
