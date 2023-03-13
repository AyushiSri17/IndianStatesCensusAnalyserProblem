using IndianStatesCensusAnalyserProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA
        }
        public Dictionary<string, CensusDTO> datamap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            datamap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return datamap;
        }

        public Dictionary<string, StateCodeDataDAO> codeDatamap;
        public Dictionary<string, StateCodeDataDAO> LoadStateCodeCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            codeDatamap = new CSVAdapterFactory().LoadStateCodeCsvData(country, csvFilePath, dataHeaders);
            return codeDatamap;
        }
    }
}
