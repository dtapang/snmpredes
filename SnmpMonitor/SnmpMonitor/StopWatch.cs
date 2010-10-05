/*
    Copyright (c) 2006, Corey Goldberg

    StopWatch.cs is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.
*/
using System;

namespace SnmpMonitor
{
    public class StopWatch
    {

        private DateTime startTime;
        private DateTime stopTime;
        private bool running = false;
        private TimeSpan interval;

        //inicializo el intervalo de disponibilidad en cero
        public StopWatch()
        {
            this.interval = TimeSpan.Zero;
        }
        public bool Running
        {
            get { return this.running; }
        }
        public void Start()
        {
            this.startTime = DateTime.Now;
            this.running = true;
        }


        public void Stop()
        {
            this.stopTime = DateTime.Now;
            this.running = false;
            this.interval = interval + (DateTime.Now - startTime);
        }


        // elaspsed time in milliseconds
        public double GetElapsedTime()
        {
            if (running)
                interval = interval + (DateTime.Now - startTime);
            else
                interval = interval + (stopTime - startTime);

            return interval.TotalMilliseconds;
        }


        // elaspsed time in seconds
        public double GetElapsedTimeSecs()
        {
            if (running)
            {
                interval = interval + (DateTime.Now - startTime);
                startTime = DateTime.Now;
            }
            //else
            //    interval = interval + (stopTime - startTime);

            return interval.TotalSeconds;
        }


        // sample usage
        /*
        public static void Main(String[] args)
        {
            StopWatch s = new StopWatch();
            s.Start();
            // code you want to time goes here
            s.Stop();
            Console.WriteLine("elapsed time in milliseconds: " + s.GetElapsedTime());
        }
         */
    }
}