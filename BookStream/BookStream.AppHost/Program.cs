using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<BookStream_API>("BookStreamAPI");
//builder.AddProject<BookStream_Infrastructure>("BookStreamInfrastructure");

builder.Build().Run();
