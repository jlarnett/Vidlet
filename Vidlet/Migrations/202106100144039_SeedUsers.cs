namespace Vidlet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd374c831-281f-4027-859e-672c42866e2d', N'admin@vidlet.com', 0, N'ADCZC2qix4BsyAFUvbJ5Uh1vPSLnmT+q6pIomT0M+RYXZMSlWhXE+nfXfvMF9brQhA==', N'70d9df18-c949-4961-882f-3dc286618323', NULL, 0, 0, NULL, 1, 0, N'admin@vidlet.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fd8b981c-fbb1-4ec6-a67f-e4905026b3cd', N'guest@vidlet.com', 0, N'AMyb6xawT+ERbQcC7D9ir9PWq1Yagm2BAf1wICPdJOmCxerquURjkytok6Ofg+j2KA==', N'5e080984-04b1-4a4f-b888-e90430a712e3', NULL, 0, 0, NULL, 1, 0, N'guest@vidlet.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8f466184-3b3e-47c5-997c-a41e2dd45de9', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd374c831-281f-4027-859e-672c42866e2d', N'8f466184-3b3e-47c5-997c-a41e2dd45de9')

");
        }
        
        public override void Down()
        {
        }
    }
}
