using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

namespace ikromm
{
    public class ResourceMapping
    {
        [PrimaryKey]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
