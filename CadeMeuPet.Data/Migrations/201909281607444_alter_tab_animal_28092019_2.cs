namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_tab_animal_28092019_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TAB_ANIMAL", "Identificacao", c => c.String(maxLength: 2, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TAB_ANIMAL", "Identificacao", c => c.Boolean(nullable: false));
        }
    }
}
