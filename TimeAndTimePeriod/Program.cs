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
        }
    }
}
