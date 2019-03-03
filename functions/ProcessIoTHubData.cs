using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Functions
{
    public static class ProcessIoTHubData
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("ProcessIoTHubData")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "IoTEndpoint")]EventData message, [Table("IoT",Connection="AzureWebJobsStorage")]ICollector<Message> table, ILogger log)
        {
            var msg = Encoding.UTF8.GetString(message.Body.Array);
            var deviceMessage = JsonConvert.DeserializeObject<DeviceMessage>(msg);

            table.Add(new Message(deviceMessage));
            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
        }
    }

    public class DeviceMessage
    {
        [JsonProperty(PropertyName = "passengerIn")]
        public int PassengerIn{get;set;}

        [JsonProperty(PropertyName = "passengerOut")]
        public int PassangerOut{get;set;}
        
        [JsonProperty(PropertyName = "capacityAlert")]
        public bool CapacityAlert{get;set;}
    }

    public class Message : TableEntity
    {
        public int PassengerIn{get;set;}
        public int PassangerOut{get;set;}
        public bool CapacityAlert{get;set;}

        public Message(DeviceMessage msg)
        {
            this.PartitionKey = "IoT13NET";
            this.RowKey = Guid.NewGuid().ToString();
            this.PassengerIn = msg.PassengerIn;
            this.PassangerOut = msg.PassangerOut;
            this.CapacityAlert = msg.CapacityAlert;
        }

    }
    
}