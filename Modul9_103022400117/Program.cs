using System.Text.Json;

var json = File.ReadAllText("bank_transfer_config.json");
var options = new JsonSerializerOptions
{
    IncludeFields = true
};
var config = JsonSerializer.Deserialize<BankTransferConfig>(json, options);


if (config.lang == "en")
{
    Console.WriteLine("Please insert the amount of money to transfer:");
    var amount = int.Parse(Console.ReadLine());
    var fee = amount <= config.transfer.threshold ? config.transfer.low_fee : config.transfer.high_fee;

    Console.WriteLine("Transfer fee = " + fee);
    Console.WriteLine("Total amount = " + (amount + fee));

    Console.WriteLine("Select transfer method: ");
    for (int i = 0; i < config.method.Length; i++)
    {
        Console.WriteLine((i + 1) + " " + config.method[i]);
    }
    var methodInput = int.Parse(Console.ReadLine());
    var method = config.method[methodInput - 1];

    Console.WriteLine("Please type " + config.confirmation.en + " to confirm the transaction:");
    string confirmation = Console.ReadLine();

    Console.WriteLine(confirmation == config.confirmation.en ? "The transfer is completed using " + method : "Transfer is cancelled");
}
else if (config.lang == "id")
{
    Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
    var amount = int.Parse(Console.ReadLine());

    var fee = amount <= config.transfer.threshold ? config.transfer.low_fee : config.transfer.high_fee;
    Console.WriteLine("Biaya transfer = " + fee);
    Console.WriteLine("Total biaya = " + (amount + fee));
    Console.WriteLine("Pilih metode transfer: ");
    for (int i = 0; i < config.method.Length; i++)
    {
        Console.WriteLine((i + 1) + " " + config.method[i]);
    }
    var methodInput = int.Parse(Console.ReadLine());
    var method = config.method[methodInput - 1];

    Console.WriteLine("Ketik " + config.confirmation.id + " untuk mengkonfirmasi transaksi");
    string confirmation = Console.ReadLine();

    Console.WriteLine(confirmation == config.confirmation.id ? "proses transfer berhasil menggunakan " + method : "Transfer dibatalkan");
}