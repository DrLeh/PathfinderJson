using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;

namespace PathfinderJson
{

    public class FieldReader : IDisposable
    {
        public void Dispose()
        {
            reader.Dispose();
        }

        PdfReader reader { get; set; }

        public FieldReader(string file)
        {
            reader = new PdfReader(file);
        }

        public T GetField<T>(string name)
        {
            var value = reader.AcroFields.GetField(name);
            if (string.IsNullOrWhiteSpace(value))
                return default(T);

            if (typeof(T) == typeof(bool))
                value = (value == "1" ? bool.TrueString : bool.FalseString);

            return (T)Convert.ChangeType(value, typeof(T));
        }

    }
}
