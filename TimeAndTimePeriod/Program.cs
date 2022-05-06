using System;

namespace TimeAndTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Time time = new Time("23:33:22");
            Console.WriteLine(time.ToString());
            Time time2 = new Time(20, 03, 32);
            Console.WriteLine(time2.ToString());
            Time time3 = new Time(20, 39);
            Console.WriteLine(time3.ToString());
            Time time4 = new Time(10);
            Console.WriteLine(time4.ToString());
            Time time5 = new Time("10:00:00");
            Console.WriteLine(time5.ToString());
            Time[] times = new Time[]
            {
                time,
                time2,
                time3,
                time4,
                time5
            };
            Console.WriteLine("before: ");
            foreach(Time currentTime in times)
            {
                Console.WriteLine("VALUE: {0}", currentTime.ToString());
            }
            Array.Sort(times);
            Console.WriteLine("\nafter: ");
            foreach (Time currentTime in times)
            {
                Console.WriteLine("VALUE: {0}", currentTime.ToString());
            }
            Console.WriteLine(time.Equals((object)time2));
            Console.WriteLine(time3.Equals(time4));
            Console.WriteLine(time4.Equals(time5));
        }
    }
}
