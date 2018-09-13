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
using System.Drawing;

class GetProcessesByNameClass
{

    static public System.Timers.Timer tmr = new System.Timers.Timer();
    static public System.Timers.Timer tmr1 = new System.Timers.Timer();
    public static void Main(string[] args)
    {
        tmr.Elapsed += new System.Timers.ElapsedEventHandler(FirstTypeMonitoring);
        tmr.Interval = 13000;
        tmr1.Elapsed += new System.Timers.ElapsedEventHandler(SecondTypeMonitoring);
        tmr1.Interval = 5000;

        switch (Convert.ToInt32(args.First()))//Метод который возращает первый элемент массива
            {

                case 1: { tmr.Enabled = true; break; }
                case 2: { tmr1.Enabled = true; break; }
                default: { Environment.Exit(0); break; }
            }

        Thread.Sleep(10000);
        Console.ReadKey();
    }
    /// <summary>
 
   public static void FirstTypeMonitoring(object sender, ElapsedEventArgs e)//Отображение в виде таблицы
        {

        Console.Clear();
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
            Console.WriteLine("\n------------------------------------------\n" + "\n" + test1 + " Resultate:\n Count process: " +/*Environment.ProcessorCount*/i + "\nCount public CPU: " + test + "\nMachineName: " + Environment.MachineName);//Вывод имени компьютера
        
        }

 public static void SecondTypeMonitoring(object sender, ElapsedEventArgs e)//отображение загруженности Цп и ОЗУ
    {
        Console.Clear();
        Console.WriteLine("_____________________________" + DateTime.Now + "__________________________\nPlease wait resultat from processor and memory...");

        
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
                Console.Write("]\n__________________________________________________________________________\n");
     
    }
}
