using FluentMigrator;

namespace MyRecipeBook.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.TABLE_USER, "Create table to save the user's information")]
public class Version001 : ForwardOnlyMigration
{
    public override void Up()
    {
        throw new NotImplementedException();
    }
}

