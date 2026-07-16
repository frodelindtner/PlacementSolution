var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PlacementTableApp>("placementtableapp");

builder.Build().Run();
