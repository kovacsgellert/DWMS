using DWMS.Common;

var builder = DistributedApplication.CreateBuilder(args);

var mongo = builder.AddMongoDB(AspireResourceConstants.MongoServer)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithMongoExpress()
    .WithDataVolume();

var inboundDb = mongo.AddDatabase(AspireResourceConstants.InboundDb);

builder.AddProject<Projects.DWMS_Inbound_Api>(AspireResourceConstants.InboundApi)
    .WithReference(inboundDb)
    .WaitFor(inboundDb);

builder.AddProject<Projects.DWMS_Inventory_Api>(AspireResourceConstants.InventoryApi);

builder.Build().Run();