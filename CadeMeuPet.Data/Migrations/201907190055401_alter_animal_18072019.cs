namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_animal_18072019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TAB_ANIMAL", "LocalizacaoId", c => c.Int(nullable: false));
            CreateIndex("dbo.TAB_ANIMAL", "LocalizacaoId");
            AddForeignKey("dbo.TAB_ANIMAL", "LocalizacaoId", "dbo.TAB_LOCALIZACAO", "LocalizacaoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TAB_ANIMAL", "LocalizacaoId", "dbo.TAB_LOCALIZACAO");
            DropIndex("dbo.TAB_ANIMAL", new[] { "LocalizacaoId" });
            DropColumn("dbo.TAB_ANIMAL", "LocalizacaoId");
        }
    }
}
