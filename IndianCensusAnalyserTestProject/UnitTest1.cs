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
        Dictionary<string, CensusDTO> dict = new Dictionary<string, CensusDTO>();//For census
        Dictionary<string, StateCodeDataDAO> stateDict = new Dictionary<string, StateCodeDataDAO>();//For state code
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

        //Test cases for state code
        string indianStateCode = @"C:\Users\Ayushi\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFile\IndianStateCode.csv";
        public const string incorrectStateFile = @"C:\Users\Ayushi\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFile\IndianState.csv";
        public const string incorrectStateFileType = @"C:\Users\Ayushi\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFile\IndianCensus.txt";
        public const string incorrectStateDelimeter = @"C:\Users\Ayushi\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFile\DelimeterIndiaStateCode.csv";
        public const string incorrectStateHeader = @"C:\Users\Ayushi\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFile\WrongHeaderStateCode.csv";

        //TC_2.1-Ensure the no. of records matches
        [TestMethod]
        public void Given_StateCodeCSVFile_Should_Return_NoOfRecord()
        {
            stateDict = factory.LoadStateCodeCsvData(CensusAnalyser.Country.INDIA, indianStateCode, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, stateDict.Count);
        }

        //TC_2.2-Incorrect CSV file should return file not found exception
        [TestMethod]
        [DataRow(incorrectStateFile, "File Not Found")]
        public void Given_State_StateCodeCSVFile_If_Incorrect_Returns_FileNotFound_Exception(string file, string expected)
        {
            var result = Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadStateCodeCsvData(CensusAnalyser.Country.INDIA, file, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(expected, result.Message);
        }

        //TC_2.3-Incorrect file type should return Invalid file type exception
        [TestMethod]
        [DataRow(incorrectStateFileType, "Invalid file type")]
        public void Given_StateCodeCensusCSVFile_If_Incorrect_Returns_InvalidFileType_Exception(string file, string expected)
        {
            var result = Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadStateCodeCsvData(CensusAnalyser.Country.INDIA, file, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(expected, result.Message);
        }

        //TC_2.4-Incorrect Delimeter should return File contains wrong delimeter
        [TestMethod]
        [DataRow(incorrectStateDelimeter, "File Contains Wrong Delimeter")]
        public void Given_StateCodeCensusCSVFile_If_Incorrect_Returns_WrongDelimeter_Exception(string file, string expected)
        {
            var result = Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadStateCodeCsvData(CensusAnalyser.Country.INDIA, file, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(expected, result.Message);
        }

        //TC_2.5-Incorrect header should return Incorrect header in Data 
        [TestMethod]
        [DataRow(incorrectStateHeader, "Incorrect header in Data")]
        public void Given_StateCodeCensusCSVFile_If_Incorrect_Return_IncorrectHeader_Exception(string file, string expected)
        {
            var result = Assert.ThrowsException<CensusAnalyserException>(() => factory.LoadStateCodeCsvData(CensusAnalyser.Country.INDIA, file, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(expected, result.Message);
        }
    }
}