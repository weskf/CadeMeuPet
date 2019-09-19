namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_tab_fotos_animal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TAB_FOTOS_ANIMAL",
                c => new
                    {
                        FotoId = c.Int(nullable: false, identity: true),
                        AnimalId = c.Int(nullable: false),
                        CaminhoFoto = c.String(maxLength: 100, unicode: false),
                        DescricaoFoto = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.FotoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TAB_FOTOS_ANIMAL");
        }
    }
}
