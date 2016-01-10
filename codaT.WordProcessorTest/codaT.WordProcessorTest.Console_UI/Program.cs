using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codaT.WordProcessorTest.Console_UI
{
    class Program
    {
        static void Main(string[] args)
        {

            string currentCommand = "";

            do
            {
                DisplaySelection();

                currentCommand = Console.ReadLine();

                MakeSelection(args, currentCommand);
            }
            while (currentCommand != "q");

        }


        public static void MakeSelection(string[] args, string command)
        {
            int choice;

            if (!int.TryParse(command, out choice))
                return;

            switch (choice)
            {
                case 1:
                    {
                        Test_WordCount(args);
                        break;
                    }
                case 2:
                    {
                        break;
                    }
            }
        }

        public static void DisplaySelection()
        {
            Console.WriteLine();
            Console.WriteLine("01: Test_WordCount");
            Console.WriteLine("02: ");
            Console.WriteLine("");


            Console.WriteLine(" q: Quit");


        }


        public static void Test_WordCount(string[] args)
        {
            Console.WriteLine("Please enter data to split:\n");

            var data = Console.ReadLine();

            Dictionary<string, int> sorted = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            string[] words = data.RemovePunctuation().Split(new char[] { ' ' });

            foreach (var word in words)
                if (word.Trim() != string.Empty)
                    sorted.AddOrIncrement(word.Trim());

            foreach (var entry in sorted)
                Console.WriteLine("{0} - {1}", entry.Key, entry.Value);

        }
    }
}
