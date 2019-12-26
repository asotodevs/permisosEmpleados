namespace PermisosApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreEmpleado = c.String(nullable: false, maxLength: 150),
                        ApellidoEmpleado = c.String(nullable: false),
                        FechaPermiso = c.DateTime(nullable: false),
                        TipoPermiso_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoPermisoes", t => t.TipoPermiso_Id, cascadeDelete: true)
                .Index(t => t.TipoPermiso_Id);
            
            CreateTable(
                "dbo.TipoPermisoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PermisoDescripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleadoes", "TipoPermiso_Id", "dbo.TipoPermisoes");
            DropIndex("dbo.Empleadoes", new[] { "TipoPermiso_Id" });
            DropTable("dbo.TipoPermisoes");
            DropTable("dbo.Empleadoes");
        }
    }
}
