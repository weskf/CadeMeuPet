namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_tab_animal : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TAB_FOTOS_ANIMAL", "AnimalId");
            AddForeignKey("dbo.TAB_FOTOS_ANIMAL", "AnimalId", "dbo.TAB_ANIMAL", "AnimalId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TAB_FOTOS_ANIMAL", "AnimalId", "dbo.TAB_ANIMAL");
            DropIndex("dbo.TAB_FOTOS_ANIMAL", new[] { "AnimalId" });
        }
    }
}
