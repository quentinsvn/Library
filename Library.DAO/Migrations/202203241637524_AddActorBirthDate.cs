namespace Library.DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActorBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actor", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actor", "BirthDate");
        }
    }
}
