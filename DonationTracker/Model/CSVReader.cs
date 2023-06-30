using System;
using CsvHelper;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Windows.Documents;
using System.Collections.Generic;

namespace DonationTracker.Model
{
    public abstract class CSVReader
    {
        public static List<Charity> Read(string filename)
        {
            using (var streamReader = new StreamReader(filename))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<CharityClassMap>();
                    return csvReader.GetRecords<Charity>().ToList();
                }
            }
        }
    }
}
