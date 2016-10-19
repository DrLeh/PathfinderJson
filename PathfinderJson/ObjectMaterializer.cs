using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderJson
{
    public class ObjectMaterializer
    {
        public static T Create<T>(FieldReader reader, object param)
            where T : new()
        {
            var ret = new T();
            Populate(ret, reader, param);
            return ret;
        }

        public static void Populate<T>(T obj, FieldReader reader, object param)
            where T : new()
        {
            var properties = obj
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(FieldAttribute), true).Any());
            foreach (var prop in properties)
            {
                var fieldName = "";
                var att = (FieldAttribute)prop.GetCustomAttributes(typeof(FieldAttribute), true).FirstOrDefault();

                if (att == null)
                    continue;

                fieldName = att.GetFieldName(param.ToString());

                var method = reader.GetType().GetMethod($"{nameof(FieldReader.GetField)}");
                var generic = method.MakeGenericMethod(prop.PropertyType);

                try
                {
                    var value = generic.Invoke(reader, new[] { fieldName });
                    prop.SetValue(obj, value);
                }
                catch (Exception)
                {
                    Console.WriteLine(fieldName);
                }
            }
        }
    }
}
