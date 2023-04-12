using modul08_1302213026;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
       BankTransferConfig config = new BankTransferConfig();
        TransferBank transferBank = new TransferBank();
        UIConfig uIConfig = new UIConfig();

        Console.WriteLine("Masukan bahasa yang dipilih: ");
        string bahasa = Console.ReadLine();
            if (bahasa == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer: ");
                
            }
            else if (bahasa == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }
             int moneyToTf = int.Parse(Console.ReadLine());

            int biaya;
            if(moneyToTf <= config.transfer.threshold) {
                biaya = (moneyToTf + uIConfig.);
            }
            else
            {
                biaya=( moneyToTf + uIConfig.transfer.high_fee);
            }
        Console.WriteLine("Biaya yang harus dibayarkan adalah:" +biaya);
        
       

    }
}