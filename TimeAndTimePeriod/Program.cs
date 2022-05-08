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
            Console.WriteLine(time4.Equals((object)time5));
            Console.WriteLine(time2 > time3);
            Console.WriteLine(time2 < time3);
            Console.WriteLine(time2 == time3);
            Console.WriteLine(time2 != time3);
            Console.WriteLine(time4 >= time5);
            Console.WriteLine(time5 <= time4);
            Console.WriteLine(time4 == time5);
            Console.WriteLine(time5 != time4);
            Console.WriteLine(time2 + time3);
            Console.WriteLine("==========================");
            TimePeriod timePeriod1 = new TimePeriod(45, 1, 1);
            Console.WriteLine(timePeriod1.ToString());
            TimePeriod timePeriod2 = new TimePeriod(23, 44);
            Console.WriteLine(timePeriod2);
            TimePeriod timePeriod3 = new TimePeriod(3423525342);
            Console.WriteLine(timePeriod3.ToString());
            TimePeriod timePeriod4 = new TimePeriod(time2, time);
            Console.WriteLine(timePeriod4.ToString());
            TimePeriod timePeriod5 = new TimePeriod(time, time2);
            Console.WriteLine(timePeriod5.ToString());
            TimePeriod timePeriod6 = new TimePeriod(time4, time5);
            Console.WriteLine(timePeriod6.ToString());
            TimePeriod timePeriod6_2 = new TimePeriod(time4, time5);
            Console.WriteLine(timePeriod6_2.ToString());
            TimePeriod timePeriod7 = new TimePeriod("543:44:22");
            Console.WriteLine(timePeriod7.ToString());
            Console.WriteLine(timePeriod1.Equals((object)timePeriod2));
            Console.WriteLine(timePeriod6.Equals((object)timePeriod6_2));
            Console.WriteLine(timePeriod2.Equals(timePeriod3));
            Console.WriteLine(timePeriod6.Equals(timePeriod6_2));
            Console.WriteLine("----------");
            TimePeriod[] timePeriods = new TimePeriod[]
            {
                timePeriod1,
                timePeriod2,
                timePeriod3,
                timePeriod4,
                timePeriod5,
                timePeriod6,
                timePeriod6_2,
                timePeriod7
            };
            Console.WriteLine("before: ");
            foreach (TimePeriod currentTime in timePeriods)
            {
                Console.WriteLine("VALUE: {0}", currentTime.ToString());
            }
            Array.Sort(timePeriods);
            Console.WriteLine("\nafter: ");
            foreach (TimePeriod currentTime in timePeriods)
            {
                Console.WriteLine("VALUE: {0}", currentTime.ToString());
            }
            Console.WriteLine(timePeriod1 > timePeriod2);
            Console.WriteLine(timePeriod1 > timePeriod7);
            Console.WriteLine(timePeriod1 < timePeriod7);
            Console.WriteLine(timePeriod3 < timePeriod7);
            Console.WriteLine(timePeriod6 >= timePeriod6_2);
            Console.WriteLine(timePeriod6 >= timePeriod7);
            Console.WriteLine(timePeriod6_2 <= timePeriod6);
            Console.WriteLine(timePeriod7 <= timePeriod1);
            Console.WriteLine(timePeriod6 == timePeriod6_2);
            Console.WriteLine(timePeriod1 == timePeriod2);
            Console.WriteLine(timePeriod1 != timePeriod2);
            Console.WriteLine(timePeriod6 != timePeriod6_2);
            TimePeriod timePeriod8 = timePeriod1 + timePeriod2;
            Console.WriteLine(timePeriod8.ToString());
            Console.WriteLine("=============================");
            Time time6 = time.Plus(timePeriod8);
            Console.WriteLine(time6.ToString());
            Time time7 = Time.Plus(time2, timePeriod2);
            Console.WriteLine(time7.ToString());
            Console.WriteLine("==============================");
            TimePeriod TimePeriod9 = timePeriod1.Plus(timePeriod4);
            Console.WriteLine(TimePeriod9.ToString());
            TimePeriod timePeriod10 = TimePeriod.Plus(timePeriod2, timePeriod3);
            Console.WriteLine(timePeriod10.ToString());
        }
    }
}
