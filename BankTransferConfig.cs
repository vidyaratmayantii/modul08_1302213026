using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul08_1302213026
{
    internal class BankTransferConfig
    {
        public string lang { get; set; }
        public TransferBank transfer { get; set; }
        public string[] methods { get; set; }
        public Confirmation confirmation { get; set; }

        public BankTransferConfig() { }
        public BankTransferConfig(string lang, TransferBank transfer, string[] methods, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }

    public class TransferBank
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }

        public TransferBank() { }   
        public TransferBank(int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }

        public Confirmation() { }
        public Confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }

    class UIConfig
    {
        public BankTransferConfig Config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string filePath = "bank_transfer_config.json";
        BankTransferConfig bankcofig = new BankTransferConfig();
        public UIConfig() {
            try
            {
                ReadConfig();
            }catch (Exception ex)
            {
                SetDefault();
                WriteConfig();
            }
        }

        private BankTransferConfig ReadConfig() { 
            string configJsonData = File.ReadAllText(filePath);
            bankcofig = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
            return Config;
        }

        public void SetDefault()
        {
            string[] methods = {"RTO(real-time)", "SKN", "RTGS", "bi fast"};
            TransferBank transfer = new TransferBank(25000000, 6500, 15000);
            Confirmation confirm = new Confirmation("yes","ya");

            BankTransferConfig Config = new BankTransferConfig("en",transfer,methods, confirm);
        }
        public void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(Config, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
