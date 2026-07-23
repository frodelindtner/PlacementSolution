var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume();

var standingsdb = postgres.AddDatabase("standingsdb");

builder.AddProject<Projects.PlacementTableApp>("placementtableapp")
    .WithReference(standingsdb)
    .WaitFor(standingsdb);

builder.Build().Run();
