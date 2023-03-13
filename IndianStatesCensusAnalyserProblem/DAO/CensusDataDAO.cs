using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class CensusDataDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;
        public CensusDataDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToInt64(area);
            this.density = Convert.ToInt64(density);
        }
    }
}
