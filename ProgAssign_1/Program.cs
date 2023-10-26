using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Assignment1;
using System.Diagnostics;

namespace ProgAssign1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            List<DataAttributes> validRecords = new List<DataAttributes>();
            List<DataAttributes> badRecords = new List<DataAttributes>();

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
            csvConfig.MissingFieldFound = null;
            csvConfig.HeaderValidated = null;

            int validRowsCount = 0;
            int skippedRowsCount = 0;

            string inputPath = @"D:\\5510\\A1\\Sample Data";
            DirWalker dirWalker = new DirWalker();

            //Console.WriteLine("Please enter a file path: ");
            //string inputPath = Console.ReadLine();
            //string outputPath = Path.Combine(@"..\..\..\", "Output");  //ouputpath = D:\5510\A1\Output
            //Directory.CreateDirectory(outputPath);
            //string logPath = Path.Combine(@"..\..\..\", "log");  //logPath = D:\5510\A1\logs
            //Directory.CreateDirectory(logPath);

            List<string> dir = dirWalker.Walk(inputPath);
            string outputFile = @"..\..\..\Output\Output.csv";
            string logFile = @"..\..\..\log\log.txt";

            
            

            foreach (string csvFilePath in dir)
            {
                if (Path.GetExtension(csvFilePath).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(csvFilePath);
                    using (var reader = new StreamReader(csvFilePath)) 
                    {
                        using (var csv = new CsvReader(reader, csvConfig))
                        {
                            var records = csv.GetRecords<DataAttributes>();
                            DirectoryInfo dirc = new DirectoryInfo(csvFilePath);
                            DirectoryInfo date = dirc.Parent;
                            DirectoryInfo month = date.Parent;
                            DirectoryInfo year = month.Parent;
                            string datePart = date.Name;
                            string monthPart = month.Name;
                            string yearPart = year.Name;
                            string dateColm = datePart + "/" + monthPart + "/" + yearPart;
                            //string dateformat = "DD/MM/YYYY";   
                            foreach (var record in records)
                            {
                                record.Date = dateColm;
                                //DateTime.Parse(dateColm, dateformat, CultureInfo.InvariantCulture);

                                if (Validation.Validate(record))
                                {
                                    validRecords.Add(record);
                                    validRowsCount++;
                                }
                                else
                                {
                                    badRecords.Add(record);
                                    skippedRowsCount++;
                                }
                            }
                        }
                    }
                }
             }

            using (var writer = new StreamWriter(outputFile))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(validRecords);
            }

            using (var wrt = new StreamWriter(logFile))
            {
                foreach (var record in badRecords)
                {
                    wrt.WriteLine($"Incomplete records: {record.FirstName}, {record.LastName}, {record.StreetNumber}, {record.Street} , {record.City}, {record.Province},{record.PostalCode}, {record.Country},{record.PhoneNumber}, {record.EmailAddress},{record.Date}");
                }
                stopwatch.Stop();
                TimeSpan elapsed = stopwatch.Elapsed;
                wrt.WriteLine($"Total execution time: {elapsed}");
                wrt.WriteLine($"Total number of valid rows: {validRowsCount}");
                wrt.WriteLine($"Total number of skipped rows: {skippedRowsCount}");
            }
        }
    }
}
