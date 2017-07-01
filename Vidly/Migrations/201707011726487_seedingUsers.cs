namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f49203d2-9592-41ea-b300-667f25651fff', N'admin@vidly.com', 0, N'AGKRWFypkswMnH1EG1n/E80h0lTvXJf3X7DIBE01HDtY7KP2y7Rg2bNpzMERMXOsvA==', N'3608d218-ed65-4ad3-b84e-e197c8b3b768', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fad03392-fffe-42d3-ab23-732796aa9362', N'guest@vidly.com', 0, N'AAClCSQEbhMOkLaE+21TEFTbcIZlQ6MlKzUHMhjn24Y8ReBX6ayHLuczGEZAr1PY7w==', N'63268cd0-37fd-42ef-985f-46ac29012b47', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'54277959-e60b-4f06-8b2d-df78ad9bad70', N'CanManageCustomers')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cd6f6806-1a83-497b-87cf-7a1d6310d1a8', N'CanManageMovies')

                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f49203d2-9592-41ea-b300-667f25651fff', N'54277959-e60b-4f06-8b2d-df78ad9bad70')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f49203d2-9592-41ea-b300-667f25651fff', N'cd6f6806-1a83-497b-87cf-7a1d6310d1a8')


            ");
        }
        
        public override void Down()
        {
        }
    }
}
