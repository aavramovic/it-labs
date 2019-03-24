using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace World
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCounters = 4;
            //String destinations = "Bangkok, London, Paris, Dubai, Singapore, New York, Kuala Lumpur, " +
            //    "Tokyo, Istanbul, Seoul, Antalya, Phuket, Mecca, Hong Kong, Milan, Palma de Mallorca, " +
            //    "Barcelona, Pattaya, Osaka, Bali, Hong Kong, Singapore, Bangkok, London, Macau, Kuala, " +
            //    "Shenzhen, New York City, Antalya, Paris, Istanbul, Rome, Dubai, Guangzhou, Phuket, Mecca" +
            //    "Pattay, Taipei City, Prague, Shanghai, Las Vegas, Miami, Barcelona, Moscow, Beijing, " +
            //    "Los Angeles, Budapest, Vienna, Amsterdam, Sofia, Madrid, Orlando, Ho Chi Minh City, Lima, " +
            //    "Berlin, Tokyo, Warsaw, Chennai, Cairo, Nairobi, Hangzhou, Milan, San Francisco, Buenos Aires, " +
            //    "Venice, Mexico City, Dublin, Seoul, Mugla, Mumbai, Denpasar, Delhi, Toronto, Zhuhai, " +
            //    "St Petersburg, Burgas, Sydney, Djerba, Munich, Johannesburg, Cancun, Edirne, Suzhou, " +
            //    "Bucharest, Punta Cana, Agra, Jaipur, Brussels, Nice, Chiang Mai, Sharm el-Sheikh, Lisbon" +
            //    "East Province, Marrakech, Jakarta, Manama, Hanoi, Honolulu, Manila, Guilin, Auckland" +
            //    "Siem, Sousse, Amman, Vancouver, Abu Dhabi, Kiev, Doha, Florence, Rio de Janeiro, " +
            //    "Melbourne, Washington D.C., Riyadh, Christchurch, Frankfurt, Baku, Sao Paulo, Harare, Kolkata, Nanjing";
            String destinations = "Rome,London,Tokyo,Sofia,Istanbul,Toronto,Mayami,Zagreb,Belgrade,Moskva";

            World world = new World(numberOfCounters, destinations);

            world.ChooseOption();

        }
    }
    
    class Counter
    {
        public List<Service> Services { get; }
        readonly String ID;

        public Counter(String id)
        {
            Services = new List<Service>();
            ID = id;
        }

        public void AddService(Service s)
        {
            Services.Add(s);
        }

        public String getID()
        {
            return ID;
        }

        public int getSize()
        {
            return Services.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Service s in Services)
            {
                sb.Append(s.ToString()).Append("\n");
            }
            return sb.ToString();
        }
    }

    class Service
    {
        readonly String Name;
        readonly String LastName;
        readonly String Age;
        readonly String ID;
        readonly DateTime TimeOfPurchase;
        String Destination;

        public Service(String name, String lastName, String age, String destination, String id)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            ID = id;
            Destination = destination;
            TimeOfPurchase = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return Name + " " + LastName + " " + Age + " " + Destination;
        }

        public String getID()
        {
            return ID;
        }

        public bool CheckValid(DateTime from, DateTime to)
        {
            if (TimeOfPurchase > from && TimeOfPurchase < to)
                return true;
            return false;
        }
        //private class SortByIdAscendingOrder : IComparer<Service>
        //{
        //    int IComparer<Service>.Compare(Service _x, Service _y)
        //    {
        //        if (_x.getID().CompareTo(_y.getID()) > 0)
        //            return 1;
        //        else if (_x.getID().CompareTo(_y.getID()) < 0)
        //            return -1;
        //        else
        //            return 0;
        //    }
        //}

        //public static IComparer SortByIdAscending()
        //{
        //    return (IComparer)new SortByIdAscendingOrder();
        //}
        public float CalculatePrice()
        {
            return Destination.Length * 2000;
        }
    }
    class World
    {
        public int TotalAtempts { get; set; }
        public int TotalServed { get; set; }
        public int Counters { get; set; }
        readonly HashSet<String> destinations;
        private List<Counter> CounterList { get; set; }


        public World(int numberOfCounters, String destinations)
        {
            TotalAtempts = 0;
            this.destinations = StringToList(destinations);
            Counters = numberOfCounters;
            CounterList = new List<Counter>();
            //CounterList.Capacity = Counters;
            for(int i=0; i < numberOfCounters; i++)
            {
                CounterList.Add(new Counter(i.ToString()));
            }
        }

        private HashSet<String> StringToList(String destinations)
        {
            HashSet<String> dest = new HashSet<string>();
            String[] Parts = destinations.Split(',');
            foreach (String s in Parts)
            {
                dest.Add(s);
            }
            return dest;
        }

        public void ChooseOption()
        {
            Console.WriteLine("Press the key with the number of the option you want to choose:");
            Console.WriteLine("Option 1: Add new purchace");
            Console.WriteLine("Option 2: Total tickets sold from a specific counter");
            Console.WriteLine("Option 3: Total profit for a specific counter");
            Console.WriteLine("Option 4: All the sold tickets sorted by counter ID");
            Console.WriteLine("Option 5: Total agency profit");
            Console.WriteLine("Option 6: Agency success rate");
            Console.WriteLine("Option 7: EXIT");
            String option = Console.ReadLine();
            int number=0;
            try { 
                number = int.Parse(option);               
            }
            catch(Exception e)
            {
                Console.WriteLine("Input invalid, try again.\n", e);
                ChooseOption();
            }
            finally
            {
                if (number > 7 || number < 1)
                {
                    Console.WriteLine("Input invalid, try again.\n");
                    ChooseOption();
                }
            }
            switch (number)
            {
                case 1: Option1(); break;
                case 2: Option2(); break;
                case 3: Option3(); break;
                case 4: Option4(); break;
                case 5: Option5(); break;
                case 6: Option6(); break;
                case 7: Option7(); break;
                default: ChooseOption(); break;
            }

        }
        //Adds the service to a list and returns weather the desiredDestination exists if successful
        void Option1()//DONE
        {
            Console.Write("Enter current counter number (1 - " + Counters + ")" + ": ");
            String counter = Console.ReadLine();
            Console.WriteLine("Enter clients name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter clients last name: ");
            String lastName = Console.ReadLine();
            Console.WriteLine("Enter clients age: ");
            String age = Console.ReadLine();
            Console.WriteLine("Enter the desired destination: ");
            String destination = Console.ReadLine();
            TotalAtempts++;
            if (this.destinations.Contains(destination))
            {
                try
                {
                    CounterList[int.Parse(counter)].AddService(new Service(name, lastName, age, destination, counter));
                    Console.WriteLine("Ticket purchaced");
                    TotalServed++;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Invalid counter number, try again.", e);
                }
                //Services.Add(new Service(name, lastName, age, destination, counter));  
                //Console.WriteLine("Ticket purchaced");
            }
            else
            {
                Console.WriteLine("We currently don't have that destination as an avaiable option.");
            }
            EmptySpace();
        }
        //Total tickets sold from a specific counter
        void Option2()//DONE
        {
            Console.Write("Enter current counter number (1 - "+ Counters + ")" + ": ");
            String counter = Console.ReadLine();
            //Entering Dates
            Console.WriteLine("Enter date span");
            DateTime userTimeFrom, userTimeTo;
            Console.Write("From: ");
            userTimeFrom = EnterDate();
            Console.Write("To: ");
            userTimeTo = EnterDate();
            //End of entering dates
            int c = 0;

            foreach (Service s in CounterList[int.Parse(counter)].Services)
            {
                if (s.getID().Equals(counter) && s.CheckValid(userTimeFrom, userTimeTo))
                {
                    c++;
                }
            }
            Console.WriteLine("Total tickets solf for counter " + counter + " is: " + c);
            EmptySpace();
        }

        void Option3()//DONE
        {
            float c = 0;
            Console.Write("Enter current counter number (1 - " + Counters + ")" + ": ");
            String counter = Console.ReadLine();
            //Entering Dates
            Console.WriteLine("Enter date span");
            DateTime userTimeFrom, userTimeTo;
            Console.Write("From: ");
            userTimeFrom = EnterDate();
            Console.Write("To: ");
            userTimeTo = EnterDate();
            //End of entering dates
            foreach (Service s in CounterList[int.Parse(counter)].Services)
            {
                
                if (s.getID().Equals(counter) && s.CheckValid(userTimeFrom, userTimeTo))
                {
                    c += s.CalculatePrice();
                }
            }
            Console.WriteLine("Total income for counter " + counter + " is: " + c);
            EmptySpace();
        }
        void Option4()
        {
            //Entering Dates
            Console.WriteLine("Enter date span");
            DateTime userTimeFrom, userTimeTo;
            Console.Write("From: ");
            userTimeFrom = EnterDate();
            Console.Write("To: ");
            userTimeTo = EnterDate();
            //End of entering dates

            foreach (Counter c in CounterList)
            {
                if(c!=null && c.getSize()!=0 )
                {
                    List<Service> validUsers = new List<Service>();
                    foreach(Service s in c.Services)
                    {
                        if (s.CheckValid(userTimeFrom, userTimeTo))
                            validUsers.Add(s);
                    }
                    if(validUsers.Count != 0)
                    {
                        Console.WriteLine("Counter " + c.getID() + ": ");
                        foreach (Service s in validUsers)
                            Console.WriteLine(s.ToString());
                    }
                }
            }
            EmptySpace();
        }
        void Option5()
        {
            float sum = 0;
            foreach (Counter c in CounterList)
            {
                if (c != null && c.getSize() != 0)
                {
                    foreach(Service s in c.Services)
                    {
                        sum += s.CalculatePrice();
                    }
                }
            }
            Console.WriteLine("Total agency income is: " + sum);
            EmptySpace();
        }
        void Option6()
        {
            Console.WriteLine("Ratio tickets to customers is  " + TotalServed + " : " + TotalAtempts);
            try
            {
                decimal dec = (decimal)TotalServed / (decimal)TotalAtempts;
                Console.WriteLine("Ratio in decimal: " + dec);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Ratio in decimal: 0", e);
            }
            finally
            {
                EmptySpace();
            }
        }
        void Option7()
        {
            Console.WriteLine("\n\n///////////////////////\n\n");
            
        }
        private void EmptySpace()
        {
            Console.WriteLine("\nPress any key to go back to the main menu: ");
            Console.ReadKey();
            Console.WriteLine("\n\n///////////////////////\n\n");
            ChooseOption();
        }
        private DateTime EnterDate()
        {
            DateTime userDateTime;
            if (DateTime.TryParse(Console.ReadLine(), out userDateTime))
            {
                return userDateTime;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value, try again,");
                return EnterDate();
            }

        }
    }
}