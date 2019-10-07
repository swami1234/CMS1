namespace CMS1.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Content = c.String(),
                        IsVisibleInMenu = c.Boolean(nullable: false),
                        IsSidebarVisible = c.Boolean(nullable: false),
                        SidebarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sidebars", t => t.SidebarId, cascadeDelete: true)
                .Index(t => t.SidebarId);
            
            CreateTable(
                "dbo.Sidebars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserModalRoleModals",
                c => new
                    {
                        UserModal_id = c.Int(nullable: false),
                        RoleModal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserModal_id, t.RoleModal_Id })
                .ForeignKey("dbo.Users", t => t.UserModal_id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleModal_Id, cascadeDelete: true)
                .Index(t => t.UserModal_id)
                .Index(t => t.RoleModal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModalRoleModals", "RoleModal_Id", "dbo.Roles");
            DropForeignKey("dbo.UserModalRoleModals", "UserModal_id", "dbo.Users");
            DropForeignKey("dbo.Pages", "SidebarId", "dbo.Sidebars");
            DropIndex("dbo.UserModalRoleModals", new[] { "RoleModal_Id" });
            DropIndex("dbo.UserModalRoleModals", new[] { "UserModal_id" });
            DropIndex("dbo.Pages", new[] { "SidebarId" });
            DropTable("dbo.UserModalRoleModals");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Sidebars");
            DropTable("dbo.Pages");
        }
    }
}
