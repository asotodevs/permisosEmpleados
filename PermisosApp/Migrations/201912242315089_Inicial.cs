namespace PermisosApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Empleadoes", name: "TipoPermiso_Id", newName: "TipoPermisoId");
            RenameIndex(table: "dbo.Empleadoes", name: "IX_TipoPermiso_Id", newName: "IX_TipoPermisoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Empleadoes", name: "IX_TipoPermisoId", newName: "IX_TipoPermiso_Id");
            RenameColumn(table: "dbo.Empleadoes", name: "TipoPermisoId", newName: "TipoPermiso_Id");
        }
    }
}
