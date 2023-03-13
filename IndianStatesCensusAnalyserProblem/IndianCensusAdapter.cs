using IndianStateCensusAnalyser;
using IndianStatesCensusAnalyserProblem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndianStatesCensusAnalyserProblem
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> censusState;
        Dictionary<string, StateCodeDataDAO> datamap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            try
            {
                censusState = new Dictionary<string, CensusDTO>();
                censusData = GetCensusData(csvFilePath, dataHeaders);
                foreach (string data in censusData.Skip(1))
                {
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException("File Contains Wrong Delimeter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER);
                    }
                    string[] coloumn = data.Split(',');
                    if (csvFilePath.Contains("IndianStateCensusData.csv"))
                        censusState.Add(coloumn[0], new CensusDTO(new CensusDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                }
                return censusState;
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, StateCodeDataDAO> LoadStateCodeCensusData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            try
            {
                datamap = new Dictionary<string, StateCodeDataDAO>();
                censusData = GetCensusData(csvFilePath, dataHeaders);
                foreach (string data in censusData.Skip(1))
                {
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException("File Contains Wrong Delimeter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER);
                    }
                    string[] coloumn = data.Split(',');
                    if (csvFilePath.Contains("IndianStateCode.csv"))
                        datamap.Add(coloumn[1], new StateCodeDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3]));
                }
                return datamap;
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
