namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _init_26052019 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Animal", new[] { "Usuario_UsuarioId" });
            RenameColumn(table: "dbo.Animal", name: "Usuario_UsuarioId", newName: "UsuarioId");
            AlterColumn("dbo.Animal", "UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Animal", "UsuarioId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Animal", new[] { "UsuarioId" });
            AlterColumn("dbo.Animal", "UsuarioId", c => c.Int());
            RenameColumn(table: "dbo.Animal", name: "UsuarioId", newName: "Usuario_UsuarioId");
            CreateIndex("dbo.Animal", "Usuario_UsuarioId");
        }
    }
}
