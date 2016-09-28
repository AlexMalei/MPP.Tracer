﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TracerAPI;
using System.Diagnostics;

namespace TestTraceProgram
{
    class Program
    {
        static void Main(string[] args)
        {           
            for (int i = 0, y = 0; i < 5; i++)
            {
                y++;
            }
            Thread thread = new Thread(new ThreadStart(Method1));
            thread.Start();

            Method1();
            thread.Join();
            TraceResult result = Tracer.Instance.GetTraceResult();
            XMLFormatter f1 = new XMLFormatter();
            ConsoleFormatter f2 = new ConsoleFormatter(); 
            f1.Format(result);
            f2.Format(result);
            Console.ReadLine();
        }

        public static void Method1()
        {
            Tracer.Instance.StartTrace();

            Thread.Sleep(200);
            Method2();
            Method3();
            Tracer.Instance.StopTrace();           
        }

        public static void Method2()
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);
            Method4(4);
            Tracer.Instance.StopTrace();            
        }

        public static void Method3()
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);
            Method5(4,3);
            Tracer.Instance.StopTrace();
        }

        public static void Method4(int a)
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);
            Tracer.Instance.StopTrace();
        }

        public static void Method5(int a, int b)
        {
            Tracer.Instance.StartTrace();
            Thread.Sleep(200);
            Tracer.Instance.StopTrace();
        }
    }
}
