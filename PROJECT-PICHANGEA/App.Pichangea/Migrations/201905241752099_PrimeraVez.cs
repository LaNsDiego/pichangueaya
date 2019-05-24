namespace App.Pichangea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraVez : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CampoDeportivos",
                c => new
                    {
                        CampoDeportivoID = c.Int(nullable: false, identity: true),
                        CentroDeportivoID = c.Int(nullable: false),
                        TipoCampoID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Precio = c.Double(nullable: false),
                        Estado = c.Int(nullable: false),
                        CentroDeportivo_TipoCampoID = c.Int(),
                        TipoCampo_TipoCampoID = c.Int(),
                    })
                .PrimaryKey(t => t.CampoDeportivoID)
                .ForeignKey("dbo.TipoCampoes", t => t.CentroDeportivo_TipoCampoID)
                .ForeignKey("dbo.TipoCampoes", t => t.TipoCampo_TipoCampoID)
                .ForeignKey("dbo.CentroDeportivos", t => t.CentroDeportivoID, cascadeDelete: false)
                .Index(t => t.CentroDeportivoID)
                .Index(t => t.CentroDeportivo_TipoCampoID)
                .Index(t => t.TipoCampo_TipoCampoID);
            
            CreateTable(
                "dbo.TipoCampoes",
                c => new
                    {
                        TipoCampoID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        CampoMaterialID = c.String(),
                        Largo = c.Double(nullable: false),
                        Ancho = c.Double(nullable: false),
                        CampoMaterial_CampoMaterialID = c.Int(),
                    })
                .PrimaryKey(t => t.TipoCampoID)
                .ForeignKey("dbo.CampoMateriales", t => t.CampoMaterial_CampoMaterialID)
                .Index(t => t.CampoMaterial_CampoMaterialID);
            
            CreateTable(
                "dbo.CampoMateriales",
                c => new
                    {
                        CampoMaterialID = c.Int(nullable: false, identity: true),
                        Descripcion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CampoMaterialID);
            
            CreateTable(
                "dbo.CentroDeportivos",
                c => new
                    {
                        CentroDeportivoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UsuarioID = c.Int(nullable: false),
                        CorreoElectronico = c.Int(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Altitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                        Imagen = c.String(),
                        UbigeoID = c.Int(nullable: false),
                        Direccion = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CentroDeportivoID)
                .ForeignKey("dbo.Ubigeos", t => t.UbigeoID, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: false)
                .Index(t => t.UsuarioID)
                .Index(t => t.UbigeoID);
            
            CreateTable(
                "dbo.Ubigeos",
                c => new
                    {
                        UbigeoID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Departamento = c.String(),
                        Provincia = c.String(),
                        Distrito = c.String(),
                    })
                .PrimaryKey(t => t.UbigeoID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        CorreoElectronico = c.String(),
                        Celular = c.String(),
                        Clave = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Deportes",
                c => new
                    {
                        DeporteID = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeporteID);
            
            CreateTable(
                "dbo.DetalleEquipoes",
                c => new
                    {
                        DetalleEquipoID = c.Int(nullable: false, identity: true),
                        EquipoID = c.Int(nullable: false),
                        DeporteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleEquipoID)
                .ForeignKey("dbo.Deportes", t => t.DeporteID, cascadeDelete: false)
                .ForeignKey("dbo.Equipoes", t => t.EquipoID, cascadeDelete: false)
                .Index(t => t.EquipoID)
                .Index(t => t.DeporteID);
            
            CreateTable(
                "dbo.Equipoes",
                c => new
                    {
                        EquipoID = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                        Logo = c.String(),
                        UsuarioID = c.Int(nullable: false),
                        UbigeoID = c.Int(nullable: false),
                        Nivel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipoID)
                .ForeignKey("dbo.Ubigeos", t => t.UbigeoID, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: false)
                .Index(t => t.UsuarioID)
                .Index(t => t.UbigeoID);
            
            CreateTable(
                "dbo.DetalleInvitacionPartidoes",
                c => new
                    {
                        DetalleInvitacionPartidoID = c.Int(nullable: false, identity: true),
                        EquipoID = c.Int(nullable: false),
                        PartidoID = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleInvitacionPartidoID)
                .ForeignKey("dbo.Equipoes", t => t.EquipoID, cascadeDelete: false)
                .ForeignKey("dbo.Partidoes", t => t.PartidoID, cascadeDelete: false)
                .Index(t => t.EquipoID)
                .Index(t => t.PartidoID);
            
            CreateTable(
                "dbo.Partidoes",
                c => new
                    {
                        PartidoID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartidoID);
            
            CreateTable(
                "dbo.DetalleInvitacionUsuarios",
                c => new
                    {
                        DetalleInvitacionUsuarioID = c.Int(nullable: false, identity: true),
                        EquipoID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleInvitacionUsuarioID)
                .ForeignKey("dbo.Equipoes", t => t.EquipoID, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: false)
                .Index(t => t.EquipoID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Jugadors",
                c => new
                    {
                        JugadorID = c.Int(nullable: false, identity: true),
                        EquipoID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        FechaFichaje = c.DateTime(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.JugadorID)
                .ForeignKey("dbo.Equipoes", t => t.EquipoID, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: false)
                .Index(t => t.EquipoID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.MetodoPagoes",
                c => new
                    {
                        MetodoPagoID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.MetodoPagoID);
            
            CreateTable(
                "dbo.Pagoes",
                c => new
                    {
                        PagoID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Monto = c.Double(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                        MetodoPagoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PagoID)
                .ForeignKey("dbo.MetodoPagoes", t => t.MetodoPagoID, cascadeDelete: false)
                .Index(t => t.MetodoPagoID);
            
            CreateTable(
                "dbo.RealizacionPartidoes",
                c => new
                    {
                        RealizacionPartidoID = c.Int(nullable: false, identity: true),
                        ReservaID = c.Int(nullable: false),
                        PartidoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RealizacionPartidoID)
                .ForeignKey("dbo.Partidoes", t => t.PartidoID, cascadeDelete: false)
                .ForeignKey("dbo.Reservas", t => t.ReservaID, cascadeDelete: false)
                .Index(t => t.ReservaID)
                .Index(t => t.PartidoID);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        ReservaID = c.Int(nullable: false, identity: true),
                        PagoID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        CampoDeportivoID = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaEntrada = c.DateTime(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservaID)
                .ForeignKey("dbo.CampoDeportivos", t => t.CampoDeportivoID, cascadeDelete: false)
                .ForeignKey("dbo.Pagoes", t => t.PagoID, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: false)
                .Index(t => t.PagoID)
                .Index(t => t.UsuarioID)
                .Index(t => t.CampoDeportivoID);
            
            CreateTable(
                "dbo.RecomendacionCentroDeportivoes",
                c => new
                    {
                        RecomendacionCentroDeportivoID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        CentroDeportivoID = c.Int(nullable: false),
                        FechaRecomendacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecomendacionCentroDeportivoID)
                .ForeignKey("dbo.CentroDeportivos", t => t.CentroDeportivoID, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: false)
                .Index(t => t.UsuarioID)
                .Index(t => t.CentroDeportivoID);
            
            CreateTable(
                "dbo.RecomendacionUsuarios",
                c => new
                    {
                        RecomendacionUsuarioID = c.Int(nullable: false, identity: true),
                        UsuarioRecomendadoID = c.Int(nullable: false),
                        UsuarioRecomendadorID = c.Int(nullable: false),
                        FechaRecomendacion = c.DateTime(nullable: false),
                        UsuarioRecomendado_UsuarioID = c.Int(),
                        UsuarioRecomendador_UsuarioID = c.Int(),
                    })
                .PrimaryKey(t => t.RecomendacionUsuarioID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioRecomendado_UsuarioID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioRecomendador_UsuarioID)
                .Index(t => t.UsuarioRecomendado_UsuarioID)
                .Index(t => t.UsuarioRecomendador_UsuarioID);
            
            CreateTable(
                "dbo.RolUsuarios",
                c => new
                    {
                        RolUsuarioID = c.Int(nullable: false, identity: true),
                        TipoUsuarioID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RolUsuarioID)
                .ForeignKey("dbo.TipoUsuarios", t => t.TipoUsuarioID, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: false)
                .Index(t => t.TipoUsuarioID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.TipoUsuarios",
                c => new
                    {
                        TipoUsuarioID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoUsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolUsuarios", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.RolUsuarios", "TipoUsuarioID", "dbo.TipoUsuarios");
            DropForeignKey("dbo.RecomendacionUsuarios", "UsuarioRecomendador_UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.RecomendacionUsuarios", "UsuarioRecomendado_UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.RecomendacionCentroDeportivoes", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.RecomendacionCentroDeportivoes", "CentroDeportivoID", "dbo.CentroDeportivos");
            DropForeignKey("dbo.RealizacionPartidoes", "ReservaID", "dbo.Reservas");
            DropForeignKey("dbo.Reservas", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Reservas", "PagoID", "dbo.Pagoes");
            DropForeignKey("dbo.Reservas", "CampoDeportivoID", "dbo.CampoDeportivos");
            DropForeignKey("dbo.RealizacionPartidoes", "PartidoID", "dbo.Partidoes");
            DropForeignKey("dbo.Pagoes", "MetodoPagoID", "dbo.MetodoPagoes");
            DropForeignKey("dbo.Jugadors", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Jugadors", "EquipoID", "dbo.Equipoes");
            DropForeignKey("dbo.DetalleInvitacionUsuarios", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.DetalleInvitacionUsuarios", "EquipoID", "dbo.Equipoes");
            DropForeignKey("dbo.DetalleInvitacionPartidoes", "PartidoID", "dbo.Partidoes");
            DropForeignKey("dbo.DetalleInvitacionPartidoes", "EquipoID", "dbo.Equipoes");
            DropForeignKey("dbo.DetalleEquipoes", "EquipoID", "dbo.Equipoes");
            DropForeignKey("dbo.Equipoes", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Equipoes", "UbigeoID", "dbo.Ubigeos");
            DropForeignKey("dbo.DetalleEquipoes", "DeporteID", "dbo.Deportes");
            DropForeignKey("dbo.CentroDeportivos", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.CentroDeportivos", "UbigeoID", "dbo.Ubigeos");
            DropForeignKey("dbo.CampoDeportivos", "CentroDeportivoID", "dbo.CentroDeportivos");
            DropForeignKey("dbo.CampoDeportivos", "TipoCampo_TipoCampoID", "dbo.TipoCampoes");
            DropForeignKey("dbo.CampoDeportivos", "CentroDeportivo_TipoCampoID", "dbo.TipoCampoes");
            DropForeignKey("dbo.TipoCampoes", "CampoMaterial_CampoMaterialID", "dbo.CampoMateriales");
            DropIndex("dbo.RolUsuarios", new[] { "UsuarioID" });
            DropIndex("dbo.RolUsuarios", new[] { "TipoUsuarioID" });
            DropIndex("dbo.RecomendacionUsuarios", new[] { "UsuarioRecomendador_UsuarioID" });
            DropIndex("dbo.RecomendacionUsuarios", new[] { "UsuarioRecomendado_UsuarioID" });
            DropIndex("dbo.RecomendacionCentroDeportivoes", new[] { "CentroDeportivoID" });
            DropIndex("dbo.RecomendacionCentroDeportivoes", new[] { "UsuarioID" });
            DropIndex("dbo.Reservas", new[] { "CampoDeportivoID" });
            DropIndex("dbo.Reservas", new[] { "UsuarioID" });
            DropIndex("dbo.Reservas", new[] { "PagoID" });
            DropIndex("dbo.RealizacionPartidoes", new[] { "PartidoID" });
            DropIndex("dbo.RealizacionPartidoes", new[] { "ReservaID" });
            DropIndex("dbo.Pagoes", new[] { "MetodoPagoID" });
            DropIndex("dbo.Jugadors", new[] { "UsuarioID" });
            DropIndex("dbo.Jugadors", new[] { "EquipoID" });
            DropIndex("dbo.DetalleInvitacionUsuarios", new[] { "UsuarioID" });
            DropIndex("dbo.DetalleInvitacionUsuarios", new[] { "EquipoID" });
            DropIndex("dbo.DetalleInvitacionPartidoes", new[] { "PartidoID" });
            DropIndex("dbo.DetalleInvitacionPartidoes", new[] { "EquipoID" });
            DropIndex("dbo.Equipoes", new[] { "UbigeoID" });
            DropIndex("dbo.Equipoes", new[] { "UsuarioID" });
            DropIndex("dbo.DetalleEquipoes", new[] { "DeporteID" });
            DropIndex("dbo.DetalleEquipoes", new[] { "EquipoID" });
            DropIndex("dbo.CentroDeportivos", new[] { "UbigeoID" });
            DropIndex("dbo.CentroDeportivos", new[] { "UsuarioID" });
            DropIndex("dbo.TipoCampoes", new[] { "CampoMaterial_CampoMaterialID" });
            DropIndex("dbo.CampoDeportivos", new[] { "TipoCampo_TipoCampoID" });
            DropIndex("dbo.CampoDeportivos", new[] { "CentroDeportivo_TipoCampoID" });
            DropIndex("dbo.CampoDeportivos", new[] { "CentroDeportivoID" });
            DropTable("dbo.TipoUsuarios");
            DropTable("dbo.RolUsuarios");
            DropTable("dbo.RecomendacionUsuarios");
            DropTable("dbo.RecomendacionCentroDeportivoes");
            DropTable("dbo.Reservas");
            DropTable("dbo.RealizacionPartidoes");
            DropTable("dbo.Pagoes");
            DropTable("dbo.MetodoPagoes");
            DropTable("dbo.Jugadors");
            DropTable("dbo.DetalleInvitacionUsuarios");
            DropTable("dbo.Partidoes");
            DropTable("dbo.DetalleInvitacionPartidoes");
            DropTable("dbo.Equipoes");
            DropTable("dbo.DetalleEquipoes");
            DropTable("dbo.Deportes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Ubigeos");
            DropTable("dbo.CentroDeportivos");
            DropTable("dbo.CampoMateriales");
            DropTable("dbo.TipoCampoes");
            DropTable("dbo.CampoDeportivos");
        }
    }
}
