namespace Library.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Actors", newName: "Actor");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Actor", newName: "Actors");
        }
    }
}
