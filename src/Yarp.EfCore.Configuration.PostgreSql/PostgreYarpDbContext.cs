using Microsoft.EntityFrameworkCore;

namespace Yarp.EfCore.Configuration.PostgreSql;

public class PostgreYarpDbContext:YarpDbContext
{
    public PostgreYarpDbContext(DbContextOptions<PostgreYarpDbContext> options) : base(options)
    {
    }
}