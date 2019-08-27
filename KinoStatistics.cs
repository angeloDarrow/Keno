using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProjectFromTheStart
{
    class KinoStatistics
    {
        public Dictionary<int, int> MostDrawnNumbers { get; set; }
        public int MaxDrawnNumbersFrequency { get; set; }
        public Dictionary<int, int> MostDrawnKinoNumbers { get; set; }
        public int MaxKinoNumbersFrequency { get; set; }

        public KinoStatistics()
        {
            MostDrawnNumbers = new Dictionary<int, int>();
            MostDrawnKinoNumbers = new Dictionary<int, int>();
        }
    }
}
