namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypesRemaining : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name = 'Quarterly' where id = 3");
            Sql("update MembershipTypes set Name = 'Annual' where id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
