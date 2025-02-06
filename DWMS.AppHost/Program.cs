var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DWMS_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    ;

builder.AddProject<Projects.DWMS_Inbound_Api>("dwms-inbound-api");

builder.AddProject<Projects.DWMS_Inventory_Api>("dwms-inventory-api");

builder.Build().Run();
