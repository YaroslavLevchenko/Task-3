using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Task_3
{
    interface ICount
    {
        string Str { get; set; }
        void CountingSymbols();
    }
    class Task1 : ICount
    {
        private string str { get; set; }

        public string Str
        {
            get => str;
            set => str = value;
        }
        public void InitializationStr()
        {
            Console.WriteLine("Type the number of symbols");
            Str = Console.ReadLine();
        }

        public void CountingSymbols()
        {

            var number = from x in Str
                           where (x == 'a') || (x == 'o') || (x == 'i') || (x == 'e')
                           select x;
            int result = number.Count();
            Console.WriteLine("The number of the desired symbols is:" + " " + $"{result}");
        }

        // Думав "додатково" створити метод який буде виводити конкретну літеру(із списку) і кількість її у строці, але:
        // Вийшла дурня хоч и працююча, не можу знайти якогось певного алгоритму.. нижче той метод) 
        public void CountingEachSymbol() 
        {
            int a = Str.ToCharArray().Count(c => c == 'a');
            int o = Str.ToCharArray().Count(c => c == 'o');
            int i = Str.ToCharArray().Count(c => c == 'i');
            int e = Str.ToCharArray().Count(c => c == 'e');
            Console.WriteLine("The number of a: " + $"{a}" + "\n" 
                + "The number of o: " + $"{o}" +"\n"
                + "The number of i: " + $"{i}" + "\n"
                + "The number of e: " + $"{e}");
        }
    }

    //Task 2
    class Task2
    {
        private int numberOfMonth { get; set; }

        public int NumberOfMounth
        {
            get => numberOfMonth;
            set => numberOfMonth = value;
        }
        public void InitializationNumber()
        {
            Console.WriteLine("Please, type the number of month:");
            NumberOfMounth = int.Parse(Console.ReadLine());
        }
            
        public void NumberOfDays()
        {
            int numberOfDays = DateTime.DaysInMonth(2023, NumberOfMounth);
            Console.WriteLine("The number of days in the current month is: " + $"{numberOfDays}");
        }
    }

    //Task 3
    interface ITask3
    {
        void Initialization();
        void Calculating();
    }
    class Task3:ITask3
    {
        int[] array;
        public void Initialization()
        {
            array = new int[10];
            Console.WriteLine("Type 10 numbers: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
        }

       // Calculating the first 5 elements of Array if they are positive and the last 5 ones if we have a negative number.
        public void Calculating()
        {
            int n = array.Length;
            int firstSum = 0, secondSum = 0;
            int i = 0;
            if (array[i] >= 0)
            {
                for(i = 0; i<n/2;i++)
                {
                    firstSum += array[i];
                }
                Console.WriteLine("Sum of the first half elements is " + firstSum);
            }
            else
            {
                for(i = 0; i<n/2;i++)
                {
                    secondSum += array[i + n / 2];
                }
                Console.WriteLine("Sum of the second half elements is " + secondSum);

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            Task1 task1 = new Task1();
            task1.InitializationStr();
            task1.CountingSymbols();
            task1.CountingEachSymbol();

            //Task 2
            Task2 task2 = new Task2();
            task2.InitializationNumber();
            task2.NumberOfDays();

            //Task 3
            Task3 task3 = new Task3();
            task3.Initialization();
            task3.Calculating();
            Console.ReadKey();
        }
    }
}
