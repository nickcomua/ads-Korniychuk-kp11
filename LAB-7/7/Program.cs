using System.Linq;

namespace ASD
{
    class Program
    {
        static Hashtable<Key, FlightsValue> Gates = new Hashtable<Key, FlightsValue>();
        static Hashtable<Key, GateValue> Flights = new Hashtable<Key, GateValue>();
        static int k = 0;
        // insert function insert to Flights and Gates date from user
        static void insert()
        {
            /* try
             {*/
            Console.WriteLine("Enter gate value");
            string gate = Console.ReadLine()!;
            Console.WriteLine("Enter flight code");
            string flightCode = Console.ReadLine()!;
            Console.WriteLine("Enter departure time");
            string departureTime = Console.ReadLine()!;
            Console.WriteLine("Enter aeroport of arrival");
            string aeroportOfArrival = Console.ReadLine()!;
            if (int.Parse(gate) > k || int.Parse(gate) <= 0)
            {
                Console.WriteLine("Bad gate value");
                return;
            }
            GateValue gvalue;
            //writ Flights.table 
            //Console.WriteLine(Flights.table.Count());
            if (Flights.loadness == 0)
                gvalue = new GateValue { gate = gate, departureTime = DateTime.Parse(departureTime), isDelayed = new TimeSpan(0), aeroportOfArrival = aeroportOfArrival };
            else
            {
                var f1 = Flights.table.ToList().Where(x =>x!=null && x.isDeleted == false && x.value!.departureTime.AddMinutes(105) >= DateTime.Parse(departureTime) && x.value.departureTime.AddMinutes(-105) <= DateTime.Parse(departureTime)).ToList();
                if (f1.Count(x => x!.value!.gate == gate) == 0)
                    gvalue = new GateValue { gate = gate, departureTime = DateTime.Parse(departureTime), isDelayed = new TimeSpan(0), aeroportOfArrival = aeroportOfArrival };
                else
                {
                    var l = Enumerable.Range(1, k).ToList();
                    Console.WriteLine(l[0]);
                    Console.WriteLine(l[1]);
                    foreach (var item in f1)
                    {
                        l.Remove(int.Parse(item!.value!.gate!));
                    }
                    if (l.Count == 0)
                    {
                        var f2 = Flights.table.ToList().Where(x =>x!=null && x.isDeleted == false && x.value!.departureTime.AddMinutes(105) >= DateTime.Parse(departureTime)).ToList();
                        Console.WriteLine();
                        foreach (var item in f2)
                        {
                            item.value.print();
                        }
                        Console.WriteLine();
                        f2 = f2.Where(x =>  f2.Count(y => x!.value!.departureTime.AddMinutes(210) <= y!.value!.departureTime && x.value.gate == y.value.gate) == 0).ToList();
                        f2.Sort((x, y) => DateTime.Compare(x.value!.departureTime, y.value!.departureTime));
                        Console.WriteLine();
                        foreach (var item in f2)
                        {
                            item.value.print();
                        }
                        Console.WriteLine();
                        gate = f2[0].value!.gate!;
                        gvalue = new GateValue { gate = gate, departureTime = f2[0].value!.departureTime.AddMinutes(105), isDelayed = f2[0].value!.departureTime.AddMinutes(105) - DateTime.Parse(departureTime), aeroportOfArrival = aeroportOfArrival };
                    }
                    else
                    {
                        gate = l[0].ToString();
                        gvalue = new GateValue { gate = gate, departureTime = DateTime.Parse(departureTime), isDelayed = new TimeSpan(0), aeroportOfArrival = aeroportOfArrival };
                    }
                }
            }
            Flights.insertEntry(new Key(flightCode), gvalue);
            var ttt = Gates.findEntry(new Key(gate));
            if (ttt == null)
            {
                var fvalue = new FlightsValue();
                fvalue.flightCode.Add(flightCode);
                Gates.insertEntry(new Key(gate), fvalue);
            }
            else
            {
                if (!ttt.value!.flightCode.Exists(x => x == flightCode))
                    ttt!.value!.flightCode.Add(flightCode);
            }
            /*}

           catch (Exception e)
           {
               Console.WriteLine(e.Message);
           }*/
        }


        static void Main(string[] args)
        {
            /*
            var k = new Key1 { key = "LH123" };
            var v = new GateValue { aeroportOfArrival = "WAW", gate = "1", departureTime = new DateTime(2019, 1, 1, 12, 0, 0), isDelayed = new TimeOnly(0) };
            var f = new FlightValue { aeroportOfArrival = "WAW", flightCode = "LH123", departureTime = new DateTime(2019, 1, 1, 12, 0, 0), isDelayed = new TimeOnly(0) };
            
            Flights.insertEntry(new Key1("2"), f);
            Gates.insertEntry(k, v);
            var e2 = Gates.findEntry(new Key1("3"));
            if (e2 == null)
            {
                Console.WriteLine("suck");
            }else
            Console.WriteLine(e2!.value!.aeroportOfArrival);
*/
            Console.WriteLine("Enter number of gates");
            k = int.Parse(Console.ReadLine()!);
            while (true)
            {
                Flights.print();
                Gates.print();
                switch (Console.ReadLine())
                {
                    case "insert":
                        {
                            insert();
                            break;
                        }
                    case "delete":
                        {
                            Console.WriteLine("Enter flight code");
                            string flightCode = Console.ReadLine()!;
                            var f = Flights.findEntry(new Key(flightCode));
                            if (f == null)
                            {
                                Console.WriteLine("Flight not found");
                                break;
                            }
                            f.isDeleted = true;
                            var g = Gates.findEntry(new Key(f.value.gate));
                            if (g == null)
                            {
                                Console.WriteLine("Gate not found");
                                break;
                            }
                            g.value.flightCode.Remove(flightCode);
                            if (g.value.flightCode.Count == 0)
                                Gates.removeEntry(new Key(f.value.gate));
                            break;
                        }
                    case "find":
                        {
                            Console.WriteLine("Enter flight code");
                            string flightCode = Console.ReadLine()!;
                            var f = Flights.findEntry(new Key(flightCode));
                            if (f == null)
                            {
                                Console.WriteLine("Flight not found");
                                break;
                            }
                            f.value.print();
                            break;
                        }
                    case "finde by gate":
                        {
                            Console.WriteLine("Enter gate");
                            string gate = Console.ReadLine()!;
                            var g = Gates.findEntry(new Key(gate));
                            if (g == null)
                            {
                                Console.WriteLine("Gate not found");
                                break;
                            }
                            g.value!.flightCode.ForEach(x => Console.WriteLine(x));
                            break;
                        }
                    case "exit":
                        {
                            return;
                        }
                }
            }
        }
    }
}