using Microsoft.EntityFrameworkCore;

namespace Yarp.EfCore.Configuration.MsSql;

public class MsSqlYarpDbContext(DbContextOptions<MsSqlYarpDbContext> options) :YarpDbContext(options)
{
    
}