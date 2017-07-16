namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
       {

           //just type in C:\PS>get-help Update-Database -examples
//            -------------------------- EXAMPLE 1 --------------------------
//C:\PS>Update-Database
 
//# Update the database to the latest migration
 
//-------------------------- EXAMPLE 2 --------------------------
//C:\PS>Update-Database -TargetMigration Second
 
//# Update database to a migration named "Second"
//# This will apply migrations if the target hasn't been applied or roll back migrations
//# if it has
 
//-------------------------- EXAMPLE 3 --------------------------
//C:\PS>Update-Database -Script
 
//# Generate a script to update the database from it's current state  to the latest migration
 
//-------------------------- EXAMPLE 4 --------------------------
//C:\PS>Update-Database -Script -SourceMigration Second -TargetMigration First
 
//# Generate a script to migrate the database from a specified start migration
//# named "Second" to a specified target migration named "First"
 
//-------------------------- EXAMPLE 5 --------------------------
//C:\PS>Update-Database -Script -SourceMigration $InitialDatabase
 
//# Generate a script that can upgrade a database currently at any version to the latest version. 
//# The generated script includes logic to check the __MigrationsHistory table and only apply changes 
//# that haven't been previously applied.
 
//-------------------------- EXAMPLE 6 --------------------------
//C:\PS>Update-Database -TargetMigration $InitialDatabase
 
//# Runs the Down method to roll-back any migrations that have been applied to the database
//Remarks
        }
        
        public override void Down()
        {
        }
    }
}
