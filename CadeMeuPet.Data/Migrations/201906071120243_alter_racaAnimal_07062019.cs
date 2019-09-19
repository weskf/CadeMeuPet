namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_racaAnimal_07062019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TAB_RACA", "EspecieAnimalId", c => c.Int(nullable: false));
            CreateIndex("dbo.TAB_RACA", "EspecieAnimalId");
            AddForeignKey("dbo.TAB_RACA", "EspecieAnimalId", "dbo.TAB_ESPECIE", "EspecieAnimalId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TAB_RACA", "EspecieAnimalId", "dbo.TAB_ESPECIE");
            DropIndex("dbo.TAB_RACA", new[] { "EspecieAnimalId" });
            DropColumn("dbo.TAB_RACA", "EspecieAnimalId");
        }
    }
}
