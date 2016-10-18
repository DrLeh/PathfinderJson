using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderJson
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class FieldDefinedAttribute : Attribute
    {
    }


    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class FieldAttribute : Attribute
    {
        public FieldAttribute([CallerMemberName] string name = null)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public virtual string GetFieldName(string param = "") => Name.Replace(Constants.SubName, param);

    }

    //[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    //public class NumberedFieldAttribute : FieldAttribute
    //{
    //    public NumberedFieldAttribute([CallerMemberName] string positionalString = null)
    //        : base(positionalString)
    //    {
    //    }

    //    public string GetFieldName(string number)
    //    {
    //        return Name.Replace(Contants.Number, number.ToString());
    //    }
    //}


    //[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    //public class SubNamedFieldAttribute  : FieldAttribute
    //{
    //    public SubNamedFieldAttribute(string subName, [CallerMemberName] string name = null)
    //        :base(name)
    //    {
    //        SubName = subName;
    //    }

    //    public string SubName { get; private set; }
    //    public string GetFieldName(string number)
    //    {
    //        return Name.Replace(Constants.SubName, SubName);
    //    }

    //}
}
