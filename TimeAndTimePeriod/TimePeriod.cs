using System;
using System.Collections.Generic;
using System.Text;

namespace TimeAndTimePeriod
{
    public struct TimePeriod: IComparable<TimePeriod>, IEquatable<TimePeriod>
    {
        public long Seconds { get; }

        public TimePeriod(int Hours, int Minutes, int Seconds)
        {
            try
            {
                if (Hours < 0 || Minutes < 0 || Minutes > 59 || Seconds < 0 || Seconds > 59)
                {
                    throw new Exception("Hours value must be above 0, Minutes value must be between 0 and 59, Seconds value must be between 0 and 59");
                }
                this.Seconds = Hours * 60 * 60 + Minutes * 60 + Seconds;
            }
            catch (Exception ex)
            {
                throw new Exception("Provided arguments are not valid for type Time", ex);
            }

        }

        public TimePeriod(int Hours, int Minutes)
        {
            try
            {
                if (Hours < 0 || Minutes < 0 || Minutes > 59)
                {
                    throw new Exception("Hours value must be above 0, Minutes value must be between 0 and 59");
                }
                this.Seconds = Hours * 60 * 60 + Minutes * 60;

            }
            catch (Exception ex)
            {
                throw new Exception("Provided arguments are not valid for type Time", ex);
            }
        }

        public TimePeriod(int Seconds)
        {
            try
            {
                if (Seconds < 0)
                {
                    throw new Exception("Seconds value must be above 0");
                }
                this.Seconds = Seconds;

            }
            catch (Exception ex)
            {
                throw new Exception("Provided arguments are not valid for type Time", ex);
            }
        }

        public TimePeriod(long Seconds)
        {
            try
            {
                if (Seconds < 0)
                {
                    throw new Exception("Seconds value must be above 0");
                }
                this.Seconds = Seconds;

            }
            catch (Exception ex)
            {
                throw new Exception("Provided arguments are not valid for type Time", ex);
            }
        }

        public TimePeriod(Time a, Time b)
        {
            try
            {
                long aSeconds = a.Hours * 60 * 60 + a.Minutes * 60 + a.Seconds;
                long bSeconds = b.Hours * 60 * 60 + b.Minutes * 60 + b.Seconds;
                long difference;
                if(bSeconds >= aSeconds)
                {
                    difference = bSeconds - aSeconds;
                }
                else
                {
                    long maxSeconds = 24 * 60 * 60;
                    long differencePart1 = maxSeconds - aSeconds;
                    difference = differencePart1 + bSeconds;
                }
                this.Seconds = difference;

            }
            catch (Exception ex)
            {
                throw new Exception("Provided arguments are not valid for type Time", ex);
            }
        }

        public TimePeriod(string timeString)
        {
            try
            {
                var splited = timeString.Split(":");
                long hours = (long)Int32.Parse(splited[0]);
                long minutes = (long)Int32.Parse(splited[1]);
                long seconds = (long)Int32.Parse(splited[2]);
                if (hours < 0 || minutes < 0 || minutes > 59 || seconds < 0 || seconds > 59)
                {
                    throw new Exception("Hours value must be between 0 and 23, Minutes value must be between 0 and 59, Seconds value must be between 0 and 59");
                }
                this.Seconds = hours * 60 * 60 + minutes * 60 + seconds;
            }
            catch (Exception ex)
            {
                throw new Exception("Provided arguments are not valid for type Time", ex);
            }
        }

        public override string ToString()
        {
            long hours = this.Seconds / 3600;
            long minutes = (this.Seconds - hours * 3600) / 60;
            long seconds = this.Seconds % 60;
            return $"{formatString(hours)}:{formatString(minutes)}:{formatString(seconds)}";
        }

        private string formatString(long chunk)
        {
            int chunkConvertedToInt = Convert.ToInt32(chunk);
            string chunkConvertedToString = Convert.ToString(chunkConvertedToInt);
            if (chunkConvertedToString.Length == 1)
            {
                chunkConvertedToString = "0" + chunkConvertedToString;
            }
            return chunkConvertedToString;
        }
        public int CompareTo(TimePeriod that)
        {
            
            if (this.Seconds > that.Seconds)
            {
                return 1;
            }
            else if (this.Seconds < that.Seconds)
            {
                return -1;
            }
            return 0;
        }

        public static bool operator <(TimePeriod a, TimePeriod b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(TimePeriod a, TimePeriod b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <=(TimePeriod a, TimePeriod b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator >=(TimePeriod a, TimePeriod b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator ==(TimePeriod a, TimePeriod b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(TimePeriod a, TimePeriod b)
        {
            return !(a.Equals(b));
        }

        public static TimePeriod operator +(TimePeriod a, TimePeriod b)
        {
            long seconds = a.Seconds + b.Seconds;

            return new TimePeriod(seconds);
        }

        public TimePeriod Plus(TimePeriod timePeriod)
        {
            long addedSeconds = this.Seconds + timePeriod.Seconds;

            return new TimePeriod(addedSeconds);
        }

        public static TimePeriod Plus(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            long addedSeconds = timePeriod1.Seconds + timePeriod2.Seconds;

            return new TimePeriod(addedSeconds);
        }

        public bool Equals(TimePeriod that)
        {

            if (this.Seconds == that.Seconds)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(Object that)
        {
            if (that == null)
                return false;

            TimePeriod timeObj = (TimePeriod)that;
            return Equals(timeObj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Seconds);
        }
    }
}
