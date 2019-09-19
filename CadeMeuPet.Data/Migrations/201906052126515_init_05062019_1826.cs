namespace CadeMeuPet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_05062019_1826 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Animal", newName: "TAB_ANIMAL");
            RenameTable(name: "dbo.CorAnimal", newName: "TAB_COR");
            RenameTable(name: "dbo.EspecieAnimal", newName: "TAB_ESPECIE");
            RenameTable(name: "dbo.RacaAnimal", newName: "TAB_RACA");
            RenameTable(name: "dbo.PorteAnimal", newName: "TAB_PORTE");
            RenameTable(name: "dbo.Cidade", newName: "TAB_CIDADE");
            RenameTable(name: "dbo.Estado", newName: "TAB_ESTADO");
            RenameTable(name: "dbo.Localizacao", newName: "TAB_LOCALIZACAO");
            RenameTable(name: "dbo.Usuario", newName: "TAB_USUARIO");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TAB_USUARIO", newName: "Usuario");
            RenameTable(name: "dbo.TAB_LOCALIZACAO", newName: "Localizacao");
            RenameTable(name: "dbo.TAB_ESTADO", newName: "Estado");
            RenameTable(name: "dbo.TAB_CIDADE", newName: "Cidade");
            RenameTable(name: "dbo.TAB_PORTE", newName: "PorteAnimal");
            RenameTable(name: "dbo.TAB_RACA", newName: "RacaAnimal");
            RenameTable(name: "dbo.TAB_ESPECIE", newName: "EspecieAnimal");
            RenameTable(name: "dbo.TAB_COR", newName: "CorAnimal");
            RenameTable(name: "dbo.TAB_ANIMAL", newName: "Animal");
        }
    }
}
