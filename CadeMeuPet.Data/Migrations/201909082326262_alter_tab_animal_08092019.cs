namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_tab_animal_08092019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TAB_ANIMAL", "FotoId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TAB_ANIMAL", "FotoId");
        }
    }
}
