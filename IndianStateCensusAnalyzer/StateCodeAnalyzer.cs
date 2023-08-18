using CsvHelper;
using IndianStateCensusAnalyser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzer
{
    public class StateCodeAnalyzer
    {
        public static int ReadStateCodeData(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_EXISTS, "File does not exist");
            }

            if (!File.ReadAllLines(filepath)[0].Contains("/") || (File.ReadAllLines(filepath)[0].Contains("|")))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, "Delimeter Incorrect");
            }

            if (!Path.GetExtension(filepath).Equals(".csv"))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_INCORRECT, "File extension incorrect");
            }


            if (!File.ReadAllLines(filepath)[0].Equals("SrNo,State,Name,TIN,StateCode"))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.HEADER_INCORRECT, "Header Incorrect");
            }

            using (var reader = new StreamReader(filepath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StateCodeData>().ToList();
                    Console.WriteLine("Read data from CSV");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.SrNo + "___" + data.State + "___" + data.Name + "___" + data.TIN+"___"+data.StateCode);
                    }
                    return records.Count() - 1;
                }
            }
        }
    }
}
