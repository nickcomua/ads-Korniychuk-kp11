namespace ASD
{
    public class GateValue
    {
        public string? aeroportOfArrival;
        public string? gate;
        public DateTime departureTime;
        public TimeSpan isDelayed;
        public override string ToString()
        {
            return $"{gate} {departureTime} {isDelayed} {aeroportOfArrival}";
        }
        public void print()
        {
            Console.WriteLine("gate {0};departureTime {1};isDelayed {2};aeroportOfArrival {3}", gate, departureTime, isDelayed, aeroportOfArrival);
        }
    }

    public class FlightsValue
    {
        public List<string> flightCode;
        public FlightsValue()
        {
            flightCode = new List<string>();
        }
        public override string ToString()
        {
            var str = "";
            foreach (var item in flightCode)
            {
                str += item + " ";
            }
            return str;
        }
        public void prtint()
        {
            foreach (var item in flightCode)
            {
                Console.WriteLine(item);
            }
        }
    }
    
    public class Key
    {
        public string key = ""; 
        public override bool Equals(object? obj)
        {
            if (obj is Key)
            {
                Key k = (Key)obj;
                return key == k.key;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash += c;
            }
            return hash;
        }
        public Key()
        {
        }
        public Key(string key)
        {
            this.key = key;
        }
        public override string ToString()
        {
            return key;
        }
    }

    public class Hashtable<Key, Value>
    where Value : class
    where Key : class//, IEquatable<Key>
    {
        public class Entry
        {
            public Key? key;
            public Value? value;
            public bool isDeleted;
        }
        public Entry[] table;
        public int size;
        public int loadness;
        public Hashtable()
        {
            this.size = 10;
            this.table = new Entry[10];
            this.loadness = 0;
        }

        //insertEntry
        public void insertEntry(Key key, Value value)
        {
            if (this.loadness >= this.size / 2)
            {
                this.rehashing();
            }
            int index = getHash(key);
            table[index] = new Entry();
            table[index].key = key;
            table[index].value = value;
            table[index].isDeleted = false;
            this.loadness++;
        }

        //findEntry 
        public Entry? findEntry(Key key)
        {
            int index = hashCode(key) % this.size;
            while (table[index] != null)
            {
                if (table[index].key!.Equals(key) && table[index].isDeleted == false)
                {
                    return table[index];
                }
                index = (index + 1) % size;
            }
            return null;
        }

        //removeEntry
        public void removeEntry(Key key)
        {
            var t = findEntry(key);
            if (t != null)
            {
                t.isDeleted = true;
                this.loadness--;
            }
            else
            {
                Console.WriteLine("No entry found");
            }
        }

        //HashCode    
        public int hashCode(Key key)
        {
            return key.GetHashCode();
            /*
            int hash = 0;
            foreach (char c in key.key)
            {
                hash += c;
            }
            return hash;*/
        }
        //rehashing
        public void rehashing()
        {
            Console.WriteLine("Rehashing");
            int newSize = size * 2;
            Entry[] newTable = new Entry[newSize];
            for (int i = 0; i < size; i++)
            {
                if (table[i] != null && table[i].isDeleted == false)
                {
                    int index = hashCode(table[i]!.key!) % newSize;
                    while (newTable[index] != null)
                    {
                        index = (index + 1) % newSize;
                    }
                    newTable[index] = table[i];
                }
            }
            table = newTable;
            size = newSize;
        }

        //getHash with line zonding
        public int getHash(Key key)
        {
            int index = hashCode(key) % size;
            while (table[index] != null)
            {
                if (table[index].key!.Equals(key) || table[index].isDeleted == true)
                {
                    return index;
                }
                index = (index + 1) % size;
            }
            return index;
        }

        public void print()
        {
            for (int i = 0; i < size; i++)
            {
                if (table[i] != null && table[i].isDeleted == false)
                {
                    Console.WriteLine("index {0};key {1};value {2}", i, table[i].key, table[i].value);
                }
            }
        }
    }
}