using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlJabbarTransLibraries.Automata;

namespace AlJabbarTransLibraries
{
    public class Alur
    {
        public enum Bandung
        {
            Tasik = 1,
            Cilacap,
            Magelang,
            Yogya,
            Wonogiri,
            Pacitan
        }

        public enum Jakarta
        {
            Tasik = 1,
            Banjar,
            Pangandaran
        }

        public enum AreaType
        {
            Bandung = 1,
            Jakarta
        }

        private prosesPesan currentState;



        public AreaType pilihAsal(int choice)
        {
            Debug.Assert(currentState == prosesPesan.ASAL, "Maaf, Anda hanya dapat memilih asal saat state berada di ASAL");


            Debug.Assert(choice != null && choice <= 2, "input tidak valid!");

            AreaType selectedEnum = AreaType.Bandung;
            Type enumType = typeof(AreaType);

            for (int i = 0; i <= System.Enum.GetNames(enumType).Length; i++)
            {
                if (choice == i)
                {
                    selectedEnum = (AreaType)i;
                    break;
                }
            }
            return selectedEnum;
        }



        public void cekHarga(int choice, int tujuanChoice)
        {
            AreaType kantorAsal = pilihAsal(choice);

            if (kantorAsal == AreaType.Bandung)
            {
                Bandung asalBandung = pilihTujuan<Bandung>(choice, tujuanChoice);

                switch (asalBandung)
                {
                    case Bandung.Tasik:
                        Console.WriteLine("Harga tiket Bandung - Tasik sebesar Rp. 100.000");
                        break;
                    case Bandung.Cilacap:
                        Console.WriteLine("Harga tiket Bandung - Cilacap sebesar Rp. 120.000");
                        break;
                    case Bandung.Magelang:
                        Console.WriteLine("Harga tiket Bandung - Magelang sebesar Rp. 140.000");
                        break;
                    case Bandung.Yogya:
                        Console.WriteLine("Harga tiket Bandung - Yogya sebesar Rp. 160.000");
                        break;
                    case Bandung.Wonogiri:
                        Console.WriteLine("Harga tiket Bandung - Wonogiri sebesar Rp. 180.000");
                        break;
                    case Bandung.Pacitan:
                        Console.WriteLine("Harga tiket Bandung - Pacitan sebesar Rp. 200.000");
                        break;
                    default:
                        throw new ArgumentException("Tujuan tidak valid!");
                }
            }
            else if (kantorAsal == AreaType.Jakarta)
            {
                Jakarta asalJakarta = pilihTujuan<Jakarta>(choice, tujuanChoice);

                switch (asalJakarta)
                {
                    case Jakarta.Tasik:
                        Console.WriteLine("Harga tiket Jakarta - Tasik sebesar Rp. 100.000");
                        break;
                    case Jakarta.Banjar:
                        Console.WriteLine("Harga tiket Jakarta - Banjar sebesar Rp. 120.000");
                        break;
                    case Jakarta.Pangandaran:
                        Console.WriteLine("Harga tiket Jakarta - Pangadaran sebesar Rp. 140.000");
                        break;
                    default:
                        throw new ArgumentException("Tujuan tidak valid");
                }
            }
        }
    }
}
