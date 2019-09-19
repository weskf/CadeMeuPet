namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_tab_usuario_29062019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TAB_USUARIO", "Celular", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TAB_USUARIO", "Celular");
        }
    }
}
