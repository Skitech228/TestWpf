using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        const string parth = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        private static async Task<String> GetDataStream()
        {
            var client = new HttpClient();
            var reposo = await client.GetAsync(parth, HttpCompletionOption.ResponseHeadersRead);
            return await reposo.Content.ReadAsStringAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
            var data = GetDataStream().Result;

            var data_lines = data.Split('\n');

            foreach (var VARIABLE in data_lines)
            {
                yield return VARIABLE.Replace("Korea,","Korea -").Replace("Bonaire,","Bonaire -");
            }
        }

        private static DateTime[] Date() => GetDataLines()
                .First()
                .Split(',')
                .Skip(4)
                .Select(x => DateTime.Parse(x,CultureInfo.InvariantCulture))
                .ToArray();

        private static IEnumerable<(string Contrue, string Provinse, int[] Counts)> Contrues()
        {
            var data = GetDataLines()
                    .Skip(1)
                    .Select(line => line.Split(','));

            foreach (var UPPER in data)
            {
                var prov = UPPER[0].Trim();
                var contrue = UPPER[1].Trim();
                var counte = UPPER.Skip(4).Select(int.Parse).ToArray();

                yield return (contrue, prov, counte);
            }

        }
        static void Main(string[] args)
        {
            var russina_data = Contrues()
                    .First(v => v.Contrue.Equals("Russia", StringComparison.OrdinalIgnoreCase));
            //Объединение 2х последовательностей Date() и Contrues()
            Console.WriteLine(string.Join("\r\n", Date().Zip(russina_data.Counts,(date,count)=>$"{date:d}-{count}")));
            Console.ReadKey();
        }
    }
}
