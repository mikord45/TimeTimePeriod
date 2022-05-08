using System;
using System.Collections.Generic;
using System.Text;

namespace TimeAndTimePeriod
{
    public struct Time : IComparable<Time>, IEquatable<Time>
    {
        public byte Hours { get; }

        public byte Minutes { get; }

        public byte Seconds { get; }

        public Time(byte Hours, byte Minutes, byte Seconds)
        {
            try
            {
                if (Hours < 0 || Hours > 23 || Minutes < 0 || Minutes > 59 || Seconds < 0 || Seconds > 59)
                {
                    throw new Exception("Hours value must be between 0 and 23, Minutes value must be between 0 and 59, Seconds value must be between 0 and 59");
                }
                this.Hours = Hours;
                this.Minutes = Minutes;
                this.Seconds = Seconds;
            }
            catch (Exception ex)
            {
                throw new Exception("Provided arguments are not valid for type Time", ex);
            }

        }
        public Time(byte Hours, byte Minutes)
        {
            try
            {
                if (Hours < 0 || Hours > 23 || Minutes < 0 || Minutes > 59)
                {
                    throw new Exception("Hours value must be between 0 and 23, Minutes value must be between 0 and 59");
                }
                this.Hours = Hours;
                this.Minutes = Minutes;
                this.Seconds = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Provided arguments are not valid for type Time", ex);
            }
        }

        public Time(byte Hours)
        {
            try
            {
                if (Hours < 0 || Hours > 23)
                {
                    throw new Exception("Hours value must be between 0 and 23");
                }
                this.Hours = Hours;
                this.Minutes = 0;
                this.Seconds = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Provided arguments are not valid for type Time", ex);
            }
        }

        public Time(string timeString)
        {
            try
            {
                var splited = timeString.Split(":");
                
                byte hours = (byte)Int32.Parse(splited[0]);
                byte minutes = (byte)Int32.Parse(splited[1]);
                byte seconds = (byte)Int32.Parse(splited[2]);
                if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59 || seconds < 0 || seconds > 59)
                {
                    throw new Exception("Hours value must be between 0 and 23, Minutes value must be between 0 and 59, Seconds value must be between 0 and 59");
                }
                this.Hours = hours;
                this.Minutes = minutes;
                this.Seconds = seconds;
            }
            catch (Exception ex)
            {
                throw new Exception("Provided arguments are not valid for type Time", ex);
            }
        }
        public override string ToString()
        {
            return $"{formatString(this.Hours)}:{formatString(this.Minutes)}:{formatString(this.Seconds)}";
        }

        private string formatString(byte chunk)
        {
            int chunkConvertedToInt = Convert.ToInt32(chunk);
            string chunkConvertedToString = Convert.ToString(chunkConvertedToInt);
            if (chunkConvertedToString.Length == 1)
            {
                chunkConvertedToString = "0" + chunkConvertedToString;
            }
            return chunkConvertedToString;
        }

        public int CompareTo(Time that)
        {
            if (this.Hours > that.Hours)
            {
                return 1;
            }
            else if (this.Hours < that.Hours)
            {
                return -1;
            }
            else if (this.Minutes > that.Minutes)
            {
                return 1;
            }
            else if (this.Minutes < that.Minutes)
            {
                return -1;
            }
            else if (this.Seconds > that.Seconds)
            {
                return 1;
            }
            else if (this.Seconds < that.Seconds)
            {
                return -1;
            }
            return 0;
        }

        public static bool operator <(Time a, Time b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >(Time a, Time b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <=(Time a, Time b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator >=(Time a, Time b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator ==(Time a, Time b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Time a, Time b)
        {
            return !(a.Equals(b));
        }


        public static Time operator +(Time a, Time b)
        {
            int seconds = ((int)a.Seconds + (int)b.Seconds) % 60;
            int additionalMinutes = ((int)a.Seconds + (int)b.Seconds) / 60;
            int minutes = ((int)a.Minutes + (int)b.Minutes + additionalMinutes) % 60;
            int additionalHours = ((int)a.Minutes + (int)b.Minutes + additionalMinutes) / 60;
            int hours = ((int)a.Hours + (int)b.Hours + additionalHours) % 24;

            return new Time((byte)hours, (byte)minutes, (byte)seconds);
        }
        public static Time operator -(Time a, Time b)
        {
            int aSeconds = a.Hours * 3600 + a.Minutes * 60 + a.Seconds;
            int bSeconds = b.Hours * 3600 + b.Minutes * 60 + b.Seconds;

            int resultSeconds = aSeconds - bSeconds;

            if(resultSeconds <= 0)
            {
                return new Time(0, 0, 0);
            }
            long hours = resultSeconds / 3600;
            long minutes = (resultSeconds - hours * 3600) / 60;
            long seconds = resultSeconds % 60;

            return new Time((byte)hours, (byte)minutes, (byte)seconds);
        }


        public Time Plus(TimePeriod timePeriod)
        {
            long currentSeconds = this.Hours * 60 * 60 + this.Minutes * 60 + this.Seconds;
            long addedSeconds = currentSeconds + timePeriod.Seconds;
            long hours = (addedSeconds / 3600) % 24;
            long minutes = (addedSeconds - ((addedSeconds / 3600) * 3600)) / 60;
            long seconds = addedSeconds % 60;

            return new Time((byte)hours, (byte)minutes, (byte)seconds);
        }

        public static Time Plus(Time time, TimePeriod timePeriod)
        {
            long currentSeconds = time.Hours * 60 * 60 + time.Minutes * 60 + time.Seconds;
            long addedSeconds = currentSeconds + timePeriod.Seconds;
            long hours = (addedSeconds / 3600) % 24;
            long minutes = (addedSeconds - ((addedSeconds / 3600) * 3600)) / 60;
            long seconds = addedSeconds % 60;

            return new Time((byte)hours, (byte)minutes, (byte)seconds);
        }

        public bool Equals(Time that)
        {

            if (this.Hours == that.Hours && this.Minutes == that.Minutes && this.Seconds == that.Seconds)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(Object that)
        {
            if (that == null)
                return false;

            Time timeObj = (Time)that;
            return Equals(timeObj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }
    }
}
