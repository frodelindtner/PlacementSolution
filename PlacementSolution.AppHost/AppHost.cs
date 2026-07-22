var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5050))
    .WithDataVolume();

var standingsdb = postgres.AddDatabase("standingsdb");

builder.AddProject<Projects.PlacementTableApp>("placementtableapp")
    .WithReference(standingsdb)
    .WaitFor(standingsdb);

builder.Build().Run();
