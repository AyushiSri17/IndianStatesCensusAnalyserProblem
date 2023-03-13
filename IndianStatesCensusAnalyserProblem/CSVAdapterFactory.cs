using IndianStateCensusAnalyser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    //case (CensusAnalyser.Country.US):
                    //    return new USCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
            }
            return default;
        }
    }
}
