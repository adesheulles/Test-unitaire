using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tpTestUnitaire
{
    class Ean13
    {
        private int[] ean13;
        public Ean13(int[] ean13)
        {
            this.ean13 = new int[12];
            int k = 0;
            foreach (int i in ean13)
            {
                this.ean13[k] = i;
                k++;
            }
        }
        public int PoidsImpair()
        {
            int poids = 0;
            for (int i = 0; i < 12; i = i + 2)
            {
                poids = poids + this.ean13[i];
            }
            return poids;
        }
        public int PoidsPair()
        {
            int poids = 0;
            for (int i = 1; i < 13; i = i + 2)
            {
                poids = poids + this.ean13[i];
            }
            return poids*3;
        }
        public int Reste()
        {
            int total = PoidsPair() + PoidsImpair();
            int reste = total % 10;
            return reste;
        }
        public int Cle()
        {
            int reste = Reste();
            if (reste == 0)
            {
                return 0;
            }
            else
            {
                return 10 - reste;
            }
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < 12; i++)
            {
                s += this.ean13[i];
                if (i % 4 == 0)
                {
                    s+="-";
                }
            }
            s += Cle();
            return s;
        }
    }
}
