// <auto-generated>
// Code generated by luis:generate:cs
// Tool github: https://github.com/microsoft/botframework-cli
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
namespace iimWebAppBot.LuisHelper
{
    public partial class LuisIntent: IRecognizerConvert
    {
        [JsonProperty("text")]
        public string Text;

        [JsonProperty("alteredText")]
        public string AlteredText;

        public enum Intent {
            GetAdvancePOForMaterial,
            GetAdvancePOForOrganization,
            GetBackOrders,
            GetConsumptionCapexTrend,
            GetCurrentInventory,
            GetCurrentInventoryCapex,
            GetCurrentPOForMaterial,
            GetCurrentPOForOrganization,
            GetExhaustDetails,
            GetFillrate,
            GetHarvesting,
            GetHarvestUniverse,
            GetHelp,
            GetInstallBase,
            GetMaterialNumber,
            GetMaterialReportInfo,
            GetOpenHarvest,
            GetOutstandingOrders,
            GetOverdue,
            GetOverStock,
            GetPlantNumber,
            GetPODetails,
            GetPODetailsWithLine,
            GetPOPlacedCapexTrend,
            GetPredictedCapex,
            GetSLAMet,
            GetSupplierEfficiency,
            GetTotalERTReceived,
            GetTotalHarvested,
            GetUnderStock,
            GetVendorName,
            Greeting,
            None
        };
        [JsonProperty("intents")]
        public Dictionary<Intent, IntentScore> Intents;

        public class _Entities
        {
            // Simple entities
            public string[] VendorName;

            // Lists
            public string[][] MaterialNumberList;
            public string[][] OragnizationList;
            public string[][] PlantNumberList;
            public string[][] VendorNumber;

            // Regex entities
            public string[] MaterialNumber;
            public string[] PONumber;
            public string[] PONumberWithLine;
            public string[] PlantNumber;


            // Composites
            public class _InstanceVendor
            {
                public InstanceData[] VendorCode;
            }
            public class VendorClass
            {
                public string[] VendorCode;
                [JsonProperty("$instance")]
                public _InstanceVendor _instance;
            }
            public VendorClass[] Vendor;

            // Instance
            public class _Instance
            {
                public InstanceData[] MaterialNumber;
                public InstanceData[] MaterialNumberList;
                public InstanceData[] OragnizationList;
                public InstanceData[] PONumber;
                public InstanceData[] PONumberWithLine;
                public InstanceData[] PlantNumber;
                public InstanceData[] PlantNumberList;
                public InstanceData[] Vendor;
                public InstanceData[] VendorCode;
                public InstanceData[] VendorName;
                public InstanceData[] VendorNumber;
            }
            [JsonProperty("$instance")]
            public _Instance _instance;
        }
        [JsonProperty("entities")]
        public _Entities Entities;

        [JsonExtensionData(ReadData = true, WriteData = true)]
        public IDictionary<string, object> Properties {get; set; }

        public void Convert(dynamic result)
        {
            var app = JsonConvert.DeserializeObject<LuisIntent>(
                JsonConvert.SerializeObject(
                    result,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Error = OnError }
                )
            );
            Text = app.Text;
            AlteredText = app.AlteredText;
            Intents = app.Intents;
            Entities = app.Entities;
            Properties = app.Properties;
        }

        private static void OnError(object sender, ErrorEventArgs args)
        {
            // If needed, put your custom error logic here
            Console.WriteLine(args.ErrorContext.Error.Message);
            args.ErrorContext.Handled = true;
        }

        public (Intent intent, double score) TopIntent()
        {
            Intent maxIntent = Intent.None;
            var max = 0.0;
            foreach (var entry in Intents)
            {
                if (entry.Value.Score > max)
                {
                    maxIntent = entry.Key;
                    max = entry.Value.Score.Value;
                }
            }
            return (maxIntent, max);
        }
    }
}