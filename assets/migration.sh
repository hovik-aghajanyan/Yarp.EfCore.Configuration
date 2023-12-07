#!/bin/bash

cd ../src/Yarp.EfCore.Configuration.PostgreSql/ || exit 
dotnet ef migrations add "$1" --startup-project ../../example/Yarp.EfCore.Configuration.Example --context PostgreYarpDbContext
cd ../Yarp.EfCore.Configuration.MsSql/  || exit
dotnet ef migrations add "$1" --startup-project ../../example/Yarp.EfCore.Configuration.Example --context MsSqlYarpDbContext

