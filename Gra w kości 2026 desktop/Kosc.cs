using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_w_kości_2026_desktop
{
    public class Kosc
    {
        private static  Random random = new Random();

        public int LiczbaOczek { get; set; } = 0;

        public bool CzyDostepna { get; set; } = true;

        public void Rzuc()
        {
            if (CzyDostepna)
            {
                LiczbaOczek = random.Next(1, 7);
            }
        }

        public void ZmienDostepnosc()
        {
            CzyDostepna = !CzyDostepna;
        }
    }
}
