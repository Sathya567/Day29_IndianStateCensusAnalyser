using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserNUnitTest
{
    public class UnitTest1
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string wrongIndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqm";

        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string wrongIndianStateCodeHeaders = "Cuntry,SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\K Sathya Sriman\source\repos\IndianStateCensusAnalyser\CensusAnalyserNUnitTest\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\K Sathya Sriman\source\repos\IndianStateCensusAnalyser\CensusAnalyserNUnitTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\K Sathya Sriman\source\repos\IndianStateCensusAnalyser\CensusAnalyserNUnitTest\CSVFiles\DelimeterIndianStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\K Sriman\source\repos\IndianStateCensusAnalyser\CensusAnalyserNUnitTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\K Sathya Sriman\source\repos\IndianStateCensusAnalyser\CensusAnalyserNUnitTest\CSVFiles\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\K Sathya Sriman\source\repos\IndianStateCensusAnalyser\CensusAnalyserNUnitTest\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\K Sathya Sriman\source\repos\IndianStateCensusAnalyser\CensusAnalyserNUnitTest\CSVFiles\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\K Sathya Sriman\source\repos\IndianStateCensusAnalyser\CensusAnalyserNUnitTest\CSVFiles\DelimeterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\K Sriman\source\repos\IndianStateCensusAnalyser\CensusAnalyserNUnitTest\CSVFiles\WrongIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        #region UC 1-2

        #region TC-1

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            #region UC-1-TC-1
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            #endregion UC-1-TC-1

            #region UC-2-TC-1
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
            #endregion UC-2Tc-1
        }

        #endregion TC-1

        #region TC-2

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            #region UC-1-TC-2
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            #endregion UC-1-TC-2

            #region UC-2-TC-2
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
            #endregion UC-2-TC-2
        }

        #endregion TC-2

        #region TC-3

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            #region UC-1-TC-3
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            #endregion UC-1-TC-3

            #region UC-2-TC-3
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
            #endregion UC-2-TC-3
        }

        #endregion TC-3

        #region TC-4

        [Test]
        public void GivenCorrectIndianCensusDataFileButWrongDelimeter_WhenReaded_ShouldReturnCustomException()
        {
            #region UC-1-TC-4
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            #endregion UC-1-TC-4

            #region UC-2-TC-4
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
            #endregion UC-2-TC-4
        }

        #endregion TC-4

        #region TC-5

        [Test]
        public void GivenCorrectIndianCensusDataFileButWrongCsvHeader_WhenReaded_ShouldReturnCustomException()
        {
            #region UC-1-TC-5
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, wrongIndianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            #endregion UC-1-TC-5

            #region UC-2-TC-5
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA, wrongIndianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
            #endregion UC-2-TC-5
        }

        #endregion TC-5

        #endregion UC 1-2

    }

}