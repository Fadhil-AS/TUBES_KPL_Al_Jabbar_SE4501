using static AlJabbarTransLibraries.Alur;
using static AlJabbarTransLibraries.Automata;
using AlJabbarTransLibraries;

namespace Al_JabbarTransLibraries
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Alur pesan = new Alur();
            Automata menu = new Automata();

            Console.WriteLine("Tempat keberangkatan tersedia:");
            pesan.PrintEnumValues<AreaType>();

            Console.WriteLine("Pilih tempat keberangkatan (angka):");
            int choice = int.Parse(Console.ReadLine());
            pesan.pilihAsal(choice);
            Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
            string keyakinan = Console.ReadLine();

            if (keyakinan == "Y" || keyakinan == "y")
            {
                menu.getStateBerikutnya(prosesPesan.ASAL, Trigger.PILIH_TUJUAN);
            }
            else if (keyakinan == "N" || keyakinan == "n")
            {
                while (keyakinan != "y" && keyakinan != "Y")
                {

                    Console.WriteLine("Pilih tempat keberangkatan (angka):");
                    choice = int.Parse(Console.ReadLine());
                    pesan.pilihAsal(choice);
                    Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                    keyakinan = Console.ReadLine();
                }

                menu.getStateBerikutnya(prosesPesan.ASAL, Trigger.PILIH_TUJUAN);
            }

            menu.printCurrentState();

            if (pesan.pilihAsal(choice) == AreaType.Bandung)
            {
                Console.WriteLine("Trayek tersedia di kantor Bandung:");
                pesan.PrintEnumValues<Bandung>();
                Console.WriteLine("Pilih kota tujuan (angka):");
                int bandungChoice = int.Parse(Console.ReadLine());
                pesan.pilihTujuan<Enum>(choice, bandungChoice);
                Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                keyakinan = Console.ReadLine();
                if (keyakinan == "Y" || keyakinan == "y")
                {
                    menu.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA);
                }
                else if (keyakinan == "N" || keyakinan == "n")
                {
                    while (keyakinan != "y" && keyakinan != "Y")
                    {
                        Console.WriteLine("Pilih kota tujuan (angka):");
                        bandungChoice = int.Parse(Console.ReadLine());
                        pesan.pilihTujuan<Enum>(choice, bandungChoice);
                        Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                        keyakinan = Console.ReadLine();
                    }
                    menu.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA);
                }
                menu.printCurrentState();
                pesan.cekHarga(choice, bandungChoice);
            }
            else if (pesan.pilihAsal(choice) == AreaType.Jakarta)
            {
                Console.WriteLine("Trayek tersedia di kantor Jakarta:");
                pesan.PrintEnumValues<Jakarta>();
                Console.WriteLine("Pilih kota tujuan (angka):");
                int jakartaChoice = int.Parse(Console.ReadLine());
                pesan.pilihTujuan<Enum>(choice, jakartaChoice);
                Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                keyakinan = Console.ReadLine();
                if (keyakinan == "Y" || keyakinan == "y")
                {
                    menu.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA);
                }
                else if (keyakinan == "N" || keyakinan == "n")
                {
                    while (keyakinan != "y" && keyakinan != "Y")
                    {
                        Console.WriteLine("Pilih kota tujuan (angka):");
                        jakartaChoice = int.Parse(Console.ReadLine());
                        pesan.pilihTujuan<Enum>(choice, jakartaChoice);
                        Console.WriteLine("Apakah anda yakin dengan pilihan anda? Sebaiknya jangan terlalu gegabah (Y / N)");
                        keyakinan = Console.ReadLine();
                    }
                    menu.getStateBerikutnya(prosesPesan.TUJUAN, Trigger.CEK_HARGA);
                }
                menu.printCurrentState();
                pesan.cekHarga(choice, jakartaChoice);
            }
            menu.getStateBerikutnya(prosesPesan.HARGA, Trigger.CEK_HARGA);
        }
    }
}
