using System;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using static BankTransferConfig;

public class BankTransferConfig
{
    public Transfer transfer { get; set; }
    public Confirmation confirmation { get; set; }
    public string lang { get; set; }
    public List<string> method { get; set; }


    public class Transfer
    {

        public double threshold { get; set; }
        public double low_fee { get; set; }
        public int high_fee { get; set; }
        public Transfer(double threshold, double low_fee, int high_fee)
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
        public Confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }

    }

    public BankTransferConfig() { }
    public BankTransferConfig(Transfer transfer, Confirmation confirmation, string lang, List<string> method)
    {
        this.transfer = transfer;
        this.confirmation = confirmation;
        this.lang = lang;
        this.method = method;
    }

}

class LoadBank()
{
    public BankTransferConfig bankTransferConfig;
    private const string filePath = "bank_transfer_config.json";
    public void ReadConfig()
    {
        string json = File.ReadAllText(filePath);
        JsonSerializer.Deserialize<BankTransferConfig>(json);
    }

    public void WriteConfig()
    {
        var option = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(this, option);
        File.WriteAllText(filePath, jsonString);
    }

    public void defaultConfig()
    {

        BankTransferConfig defaultConfig = new BankTransferConfig();

        defaultConfig.transfer = new Transfer(25000000, 6500, 15000);

        defaultConfig.confirmation = new Confirmation("yes", "ya");
        defaultConfig.lang = "en";

        defaultConfig.method.Add("RTO");
        defaultConfig.method.Add("SKN");
        defaultConfig.method.Add("RTGS");
        defaultConfig.method.Add("BI FAST");
    }

}
