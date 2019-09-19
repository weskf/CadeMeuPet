namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_05062019_2010 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TAB_CIDADE", new[] { "Estado_EstadoId" });
            RenameColumn(table: "dbo.TAB_CIDADE", name: "Estado_EstadoId", newName: "EstadoId");
            AlterColumn("dbo.TAB_CIDADE", "EstadoId", c => c.Int(nullable: false));
            CreateIndex("dbo.TAB_CIDADE", "EstadoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TAB_CIDADE", new[] { "EstadoId" });
            AlterColumn("dbo.TAB_CIDADE", "EstadoId", c => c.Int());
            RenameColumn(table: "dbo.TAB_CIDADE", name: "EstadoId", newName: "Estado_EstadoId");
            CreateIndex("dbo.TAB_CIDADE", "Estado_EstadoId");
        }
    }
}
