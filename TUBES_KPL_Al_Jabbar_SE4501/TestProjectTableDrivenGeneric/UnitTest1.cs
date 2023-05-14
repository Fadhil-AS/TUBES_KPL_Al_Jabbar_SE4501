using AlJabbarTransLibraries;
using static AlJabbarTransLibraries.Alur;

namespace TestProjectTableDrivenGeneric
{
    public class Tests
    {
        [TestFixture]
        public class ClassGenericTests
        {
            private Alur _classGeneric;

            [SetUp]
            public void Setup()
            {
                _classGeneric = new Alur();
            }

            [Test]
            public void PrintEnumValues_ValidEnumType_PrintsEnumValues()
            {
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    _classGeneric.PrintEnumValues<Bandung>();

                    string expectedOutput = "1. Tasik\r\n2. Cilacap\r\n3. Magelang\r\n4. Yogya\r\n5. Wonogiri\r\n6. Pacitan";
                    Assert.AreEqual(expectedOutput, sw.ToString().Trim());
                }
            }

            [Test]
            public void PrintEnumValues_NonEnumType_ReturnsErrorMessage()
            {
                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    _classGeneric.PrintEnumValues<string>();

                    string expectedOutput = "Tipe data bukan enum.";
                    Assert.AreEqual(expectedOutput, sw.ToString().Trim());
                }
            }

            [Test]
            public void PilihAsal_ValidChoice_ReturnsSelectedEnum()
            {
                int choice = 1;
                AreaType result = _classGeneric.pilihAsal(choice);

                Assert.AreEqual(AreaType.Bandung, result);
            }

            [Test]
            public void PilihTujuan_ValidChoices_ReturnsSelectedEnum()
            {
                int choice = 1;
                int choiceTujuan = 1;
                Bandung result = _classGeneric.pilihTujuan<Bandung>(choice, choiceTujuan);

                Assert.AreEqual(Bandung.Tasik, result);
            }

            [Test]
            public void CekHarga_ValidChoices_PrintsCorrectPrice()
            {
                int choice = 1;
                int tujuanChoice = 1;

                using (StringWriter sw = new StringWriter())
                {
                    Console.SetOut(sw);
                    _classGeneric.cekHarga(choice, tujuanChoice);

                    string expectedOutput = "Harga tiket Bandung - Tasik sebesar Rp. 100.000";
                    Assert.AreEqual(expectedOutput, sw.ToString().Trim());
                }
            }

        }
    }
}