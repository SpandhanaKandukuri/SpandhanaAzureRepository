﻿// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

const string serviceBusConnectionString = "Endpoint=sb://az-servicebus-spandhana.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=7Nu8y6rTB5w7/1lMz5zCJF7RTf8dRRSWq+ASbLZRbNs=";

const string queueName = "az-queue-spandhana";
//const string topicName = "";
const int maxNumberofMessages = 3;

ServiceBusClient client;
ServiceBusSender sender;


client = new ServiceBusClient(serviceBusConnectionString);
//sender = client.CreateSender(topicName);
sender = client.CreateSender(queueName);

using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
for (int i = 1; i <= maxNumberofMessages; i++)
{
    if (!batch.TryAddMessage(new ServiceBusMessage($"This a message - {i}")))
    {
        Console.WriteLine($"Message - {i} was not added to the batch");
    }
}

try
{
    await sender.SendMessagesAsync(batch);
    Console.WriteLine("Messages Sent");
}
catch (Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
}
finally
{
    await sender.DisposeAsync();
    await client.DisposeAsync();
}