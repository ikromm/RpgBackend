using SQLite4Unity3d;

namespace ikromm.Characters
{
    public class Stat
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }

    public enum Stats
    {
        Fire,
        Water,
        Air,
        Earth
    }

}


