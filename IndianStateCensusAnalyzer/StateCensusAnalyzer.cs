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
    public class StateCensusAnalyzer
    {
        public static int ReadStateCensusData(string filepath)
        {
            if (!Path.GetExtension(filepath).Equals(".csv"))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_INCORRECT, "File extension incorrect");
            }

            else if (!File.Exists(filepath))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_EXISTS, "File does not exist");
            }

            else if (!File.ReadAllLines(filepath)[0].Equals("State,Population,AreaInSqKm,DensityPerSqKm"))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.HEADER_INCORRECT, "Header Incorrect");
            }
            using (var reader = new StreamReader(filepath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StateCensusData>().ToList();
                    Console.WriteLine("Read data from CSV");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.State + "___" + data.Population + "___" + data.AreaInSqKm + "___" + data.DensityPerSqKm);
                    }
                    return records.Count() - 1;
                }
            }
        }
    }
}
