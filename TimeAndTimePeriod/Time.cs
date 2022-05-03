﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimeAndTimePeriod
{
    public class Time
    {
        private byte Hours { get; }

        private byte Minutes { get; }

        private byte Seconds { get; }

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
                
                this.Hours = (byte)Int32.Parse(splited[0]);
                this.Minutes = (byte)Int32.Parse(splited[1]);
                this.Seconds = (byte)Int32.Parse(splited[2]);
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
            if(chunkConvertedToString.Length == 1)
            {
                chunkConvertedToString = "0" + chunkConvertedToString;
            }
            return chunkConvertedToString;
        }
    }
}