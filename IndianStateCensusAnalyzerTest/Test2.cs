using IndianStateCensusAnalyser;
using IndianStateCensusAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzerTest
{
    public class Test2
    {
        public static string stateCodeDataFilePath = @"E:\Bridgelabz\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\Files\StateCode.csv";
        public static string stateCodeDataFilePathNotExist = @"uyyvufv.csv";
        public static string stateCodeDataFilePathincorrect = @"C:\Users\JoganDanielA\Desktop\jvvj.txt";
        [Test]
        public void GivenStateCensusData_WhenAnalysed_RecordsShouldBeMatched()
        {
            Assert.AreEqual(StateCodeAnalyzer.ReadStateCodeData(stateCodeDataFilePath),36);
        }
        [Test]
        public void GivenStateCencusDataFileIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCodeAnalyzer.ReadStateCodeData(stateCodeDataFilePathincorrect);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "File extension incorrect");
            }

        }
        [Test]
        public void GivenStateCencusDataFileNotExists_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCodeAnalyzer.ReadStateCodeData(stateCodeDataFilePathNotExist);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "File does not exist");
            }

        }
        [Test]
        public void GivenStateCensusHeaderIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCodeAnalyzer.ReadStateCodeData(stateCodeDataFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Header incorrect");
            }
        }

        [Test]
        public void GivenStateDelimeterIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCodeAnalyzer.ReadStateCodeData(stateCodeDataFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(ex.Message, "Delimeter Incorrect");
            }
        }
    }
}
