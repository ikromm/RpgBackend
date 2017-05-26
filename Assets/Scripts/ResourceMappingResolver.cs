using System;
using System.Collections.Generic;

namespace ikromm
{
    public class ResourceMappingResolver<T> where T : struct
    {
        private Dictionary<T, string> Map = new Dictionary<T, string>();

        public string this[T key] { get { return Map[key]; } }

        public ResourceMappingResolver()
        {
            MappingTableAttribute attr = (MappingTableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(MappingTableAttribute), false);
            if (attr == null)
                throw new OrmException("A MappingTable attribute should be defined for {0}", typeof(T).ToString());

            List<ResourceMapping> mappings = DbManager.Instance.Query<ResourceMapping>("select * from " + attr.TableName);

            foreach (ResourceMapping entry in mappings)
            {
                try
                {
                    Map.Add((T)Enum.Parse(typeof(T), entry.Key), entry.Value);
                }
                catch (ArgumentException e)
                {
                    throw new OrmException(e, "{0} is not defined in {1}", entry.Key, typeof(T));
                }
            }
        }

    }
}
