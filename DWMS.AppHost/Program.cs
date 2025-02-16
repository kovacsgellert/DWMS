var builder = DistributedApplication.CreateBuilder(args);

var mongo = builder.AddMongoDB("dwms-mongo-server")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithMongoExpress()
    .WithDataVolume();

var inboundDb = mongo.AddDatabase("dwms-inbound-db");

builder.AddProject<Projects.DWMS_Inbound_Api>("dwms-inbound-api")
    .WithReference(inboundDb)
    .WaitFor(inboundDb);

builder.AddProject<Projects.DWMS_Inventory_Api>("dwms-inventory-api");

builder.Build().Run();