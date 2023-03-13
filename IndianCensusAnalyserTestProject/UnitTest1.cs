using IndianStateCensusAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using IndianStatesCensusAnalyserProblem;

namespace IndianCensusAnalyserTestProject
{
    [TestClass]
    public class IndianCensusAnalyserTestClass
    {
        Dictionary<string, CensusDTO> dict = new Dictionary<string, CensusDTO>();
        CSVAdapterFactory factory = new CSVAdapterFactory();
        string indianPopulation = @"C:\Users\Ayushi\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFile\IndianStateCensusData.csv";
        string incorrectFile = @"C:\Users\Ayushi\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFile\IndianCensus.csv";
        public const string incorrectFileType = @"C:\Users\Ayushi\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFile\IndianCensus.txt";
        public const string incorrectDelimeter = @"C:\Users\Ayushi\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFile\DelimeterIndiaStateCensusData.csv";
        public const string incorrectHeader = @"C:\Users\Ayushi\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFile\WrongIndiaStateCensusData.csv";

        //TC_1.1-Ensure the no. of records matches
        [TestMethod]
        public void Given_CSVFile_Should_Return_NoOfRecord()
        {
            dict = factory.LoadCsvData(CensusAnalyser.Country.INDIA, indianPopulation, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, dict.Count);
        }

        //TC_1.2-Incorrect CSV file should return file not found exception
        [TestMethod]
        public void Given_State_CensusCSVFile_If_Incorrect_Returns_FileNotFound_Exception()
        {
            var result = Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCsvData(CensusAnalyser.Country.INDIA, incorrectFile, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("File Not Found", result.Message);
        }

        //TC_1.3-Incorrect file type should return Invalid file type exception
        [TestMethod]
        [DataRow(incorrectFileType, "Invalid file type")]//it takes object because of which passing the constant value
        public void Given_State_CensusCSVFile_If_Incorrect_Returns_InvalidFileType_Exception(string file, string expected)
        {
            var result = Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCsvData(CensusAnalyser.Country.INDIA, file, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, result.Message);
        }

        //TC_1.4-Incorrect Delimeter should return File contains wrong delimeter
        [TestMethod]
        [DataRow(incorrectDelimeter, "File Contains Wrong Delimeter")]
        public void Given_State_CensusCSVFile_If_Incorrect_Returns_WrongDelimeter_Exception(string file, string expected)
        {
            var result = Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCsvData(CensusAnalyser.Country.INDIA, file, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, result.Message);
        }

        //TC_1.5-Incorrect header should return Incorrect header in Data 
        [TestMethod]
        [DataRow(incorrectHeader, "Incorrect header in Data")]
        public void Given_State_CensusCSVFile_If_Incorrect_Return_IncorrectHeader_Exception(string file, string expected)
        {
            var result = Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadCsvData(CensusAnalyser.Country.INDIA, file, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, result.Message);
        }
    }
}