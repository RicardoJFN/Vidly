namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenrePart2 : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (Type) values ('Comedy')");
            Sql("insert into Genres (Type) values ('Action')");
            Sql("insert into Genres (Type) values ('Family')");
            Sql("insert into Genres (Type) values ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
