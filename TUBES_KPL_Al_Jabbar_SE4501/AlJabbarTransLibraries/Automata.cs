using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlJabbarTransLibraries
{
    public class Automata
    {
        public enum prosesPesan
        {
            ASAL,
            TUJUAN,
            HARGA,
            DIBERANGKATKAN
        }

        public enum Trigger
        {
            PILIH_TUJUAN,
            CEK_HARGA,
            BERANGKAT
        }

        public prosesPesan currentState = prosesPesan.ASAL;

        public class Transition
        {
            public prosesPesan stateAwal;
            public prosesPesan stateAkhir;
            public Trigger trigger;

            public Transition(prosesPesan stateAwal, prosesPesan stateAkhir, Trigger trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.trigger = trigger;
            }
        }

        Transition[] transisi =
        {
                new Transition(prosesPesan.ASAL, prosesPesan.TUJUAN, Trigger.PILIH_TUJUAN),
                new Transition(prosesPesan.TUJUAN, prosesPesan.HARGA, Trigger.CEK_HARGA),
                new Transition(prosesPesan.HARGA, prosesPesan.DIBERANGKATKAN, Trigger.BERANGKAT)
            };

        public prosesPesan getStateBerikutnya(prosesPesan stateAwal, Trigger trigger)
        {
            prosesPesan stateAkhir = stateAwal;

            for (int i = 0; i < transisi.Length; i++)
            {
                Transition perubahan = transisi[i];

                if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
                {
                    stateAkhir = perubahan.stateAkhir;
                }
            }
            currentState = stateAkhir;
            return currentState;
        }

        public void activateTrigger(Trigger trigger)
        {
            currentState = getStateBerikutnya(currentState, trigger);
            Console.WriteLine(currentState);

            if (currentState == prosesPesan.ASAL)
            {
                Console.WriteLine("Asal keberangkatan");
            }
            else if (currentState == prosesPesan.TUJUAN)
            {
                Console.WriteLine("Pilih tujuan keberangkatan");
            }
            else if (currentState == prosesPesan.HARGA)
            {
                Console.WriteLine("Check harga");
            }
            else
            {
                Console.WriteLine("Berangkat");
            }
        }

        public void printCurrentState()
        {
            Console.WriteLine("State sekarang adalah : " + currentState);
        }
    }
}