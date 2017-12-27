using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheAnimeFetcher.Classes.Services
{
    public enum ContentType
    {
        [Value("json/txt")]
        JSON,
        [Value("xml/txt")]
        XML,
        [Value("text/html")]
        HTML
    }
    public static class ContentTypeExtensions
    {
        public static string GetValue(this ContentType value)
        {
            return value.GetType().GetField(value.ToString()).GetCustomAttribute<ValueAttribute>().Value;
        }
    }
    public class ValueAttribute : Attribute
    {
        public string Value { get; private set; }

        public ValueAttribute(string Value)
        {
            this.Value = Value;
        }
    }
}
