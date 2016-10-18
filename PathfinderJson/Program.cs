using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace PathfinderJson
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"TestFile\Fighter.pdf";

            var c = new CharacterSheet(new FieldReader(file));
            var d = DateTime.Now;
            var fileName = $@"C:\users\devon\desktop\{d:yyyy_mm_dd_hh_mm_ss}.json";
            File.WriteAllText(fileName, JsonConvert.SerializeObject(c));
        }
    }
}
