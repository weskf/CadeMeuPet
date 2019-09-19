namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_tab_imagem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImagemAnimal",
                c => new
                    {
                        ImagemAnimalId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Caminho = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.ImagemAnimalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImagemAnimal");
        }
    }
}
