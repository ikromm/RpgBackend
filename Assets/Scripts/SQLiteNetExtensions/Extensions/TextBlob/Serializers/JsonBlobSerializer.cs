using System;
//using Newtonsoft.Json;

namespace SQLiteNetExtensions.Extensions.TextBlob.Serializers
{
    public class JsonBlobSerializer : ITextBlobSerializer
    {
        public string Serialize(object element)
        {
            return null;//JsonConvert.SerializeObject(element);
        }

        public object Deserialize(string text, Type type)
        {
            return null;//JsonConvert.DeserializeObject(text, type);
        }
    }
}
