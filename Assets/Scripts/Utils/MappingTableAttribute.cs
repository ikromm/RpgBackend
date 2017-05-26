using UnityEngine;
using System.Collections;
using System;

namespace ikromm
{

    public class MappingTableAttribute : Attribute
    {
        public string TableName;

        public MappingTableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
