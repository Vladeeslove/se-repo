using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Threading;
using System.Management;
using System.Timers;

class GetProcessesByNameClass
{
    public static void Main(string[] args)
    {
        bool cl=false;
        Thread timer = new Thread(new ThreadStart(new Action(() => FirstTypeMonitoring(cl))));
        Thread timer1 = new Thread(new ThreadStart(new Action(() => SecondTypeMonitoring(cl))));
        Thread timer2 = new Thread(TwoMonitoring);


        Console.Clear();
        Console.WriteLine("1.FirstTypeMonitoring\n2.SecondTypeMonitoring\n3.Both types(firt and second)\n Pick:");
        int sw = Convert.ToInt32(Console.ReadLine());

            switch (sw)
            {

                case 1: { cl = false; timer.Start(); break; }
                case 2: { cl = false; timer1.Start(); break; }
                case 3: { timer2.Start(); break; }
                default: { Environment.Exit(0); break; }
            }


        Console.ReadKey();
    }
   public static void FirstTypeMonitoring(bool _cl)//Отображение в виде таблицы
        {
      if(_cl==false)  for (; ; )
        {
           if(_cl==false)Console.Clear();
            int i = 0; double test = 0; double test1 = 0;
            Process[] processes = Process.GetProcesses();
            Console.WriteLine("{0,-25}||{1,-11}||{2,-11}||{3,-11}||", "Name", "PID", "RAM_Ussage", "CPU_ussage");
            Console.WriteLine("________________________________________________________________________________________________");
            // UIElement.Uid();
            foreach (Process p in processes)
            {//выводит все запущенные процессы
                test1 += p.PagedSystemMemorySize64 / 1000000;
                i++; test += p.WorkingSet64 / 1000000;
                Console.WriteLine("{0,-25}||{1,-11}||{2,-11}||{3,-11}||", p.ProcessName, p.Id, p.PagedSystemMemorySize64 / 1000000, p.PagedMemorySize64 / 1000000);
            }
            Console.WriteLine("\n------------------------------------------\n" + "\n" + test1 + " Resultate: Count process: " +/*Environment.ProcessorCount*/i + "\nCount public CPU: " + test + "\nMachineName: " + Environment.MachineName);//Вывод имени компьютера
           if(_cl==false) Thread.Sleep(13000);                                                                                                                                                                                                                       //  Console.ReadKey();
        }
        else
        {
            int i = 0; double test = 0; double test1 = 0;
            Process[] processes = Process.GetProcesses();
            Console.WriteLine("{0,-25}||{1,-11}||{2,-11}||{3,-11}||", "Name", "PID", "RAM_Ussage", "CPU_ussage");
            Console.WriteLine("________________________________________________________________________________________________");
            // UIElement.Uid();
            foreach (Process p in processes)
            {//выводит все запущенные процессы
                test1 += p.PagedSystemMemorySize64 / 1000000;
                i++; test += p.WorkingSet64 / 1000000;
                Console.WriteLine("{0,-25}||{1,-11}||{2,-11}||{3,-11}||", p.ProcessName, p.Id, p.PagedSystemMemorySize64 / 1000000, p.PagedMemorySize64 / 1000000);
            }
            Console.WriteLine("\n------------------------------------------\n" + "\n" + test1 + " Resultate: Count process: " +/*Environment.ProcessorCount*/i + "\nCount public CPU: " + test + "\nMachineName: " + Environment.MachineName);//Вывод имени компьютера
        }
        }

    public static void SecondTypeMonitoring(bool _cl)//отображение загруженности Цп и ОЗУ
    {
        Console.WriteLine("_______________________________________________________\nPlease wait resultat from processor and memory...");
      if(_cl==false)  for (; ; )
        {
          if(_cl==false)  Console.Clear();
                int b;
                PerformanceCounter ob1 = new PerformanceCounter("Процессор", "% загруженности процессора", "_Total");
                PerformanceCounter ob2 = new PerformanceCounter("Память", "% использования выделенной памяти");
                Console.WriteLine("Processor downloaded on {0}% ", ob1.NextValue());
                Console.WriteLine("Memory downloaded on {0}% ", ob2.NextValue());
                Console.Write("Downloaded... [");
                for (int i = 0; i < 100; i++)
                {
                    if (i < (int)ob2.NextValue())
                        Console.Write("|");
                    else
                        Console.Write(".");
                }
                Console.Write("]");
                if (_cl==false) Thread.Sleep(10000);
        }
        else
        {
            int b;
            PerformanceCounter ob1 = new PerformanceCounter("Процессор", "% загруженности процессора", "_Total");
            PerformanceCounter ob2 = new PerformanceCounter("Память", "% использования выделенной памяти");
            Console.WriteLine("Processor downloaded on {0}% ", ob1.NextValue());
            Console.WriteLine("Memory downloaded on {0}% ", ob2.NextValue());
            Console.Write("Downloaded... [");
            for (int i = 0; i < 100; i++)
            {
                if (i < (int)ob2.NextValue())
                    Console.Write("|");
                else
                    Console.Write(".");
            }
            Console.Write("]");
        }
    }
    public static void TwoMonitoring()
    {
        bool c = true;
        for(; ; )
        {
            Console.Clear();
            FirstTypeMonitoring(c);
            SecondTypeMonitoring(c);
            Thread.Sleep(12000);
        }
    }
}
