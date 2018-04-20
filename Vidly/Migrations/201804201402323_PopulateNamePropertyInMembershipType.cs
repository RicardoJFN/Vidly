namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNamePropertyInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name = 'Pay as You Go' where id = 1");
            Sql("update MembershipTypes set Name = 'Monthly' where id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
