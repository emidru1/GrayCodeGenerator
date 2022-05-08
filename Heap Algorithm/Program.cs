using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Heap_Algorithm
{
    class Program
    {
        public static void Main()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Įveskite aibės elementų skaičių: ");
            int elemSk = int.Parse(Console.ReadLine());
            if(elemSk == 0)
            {
                Console.WriteLine("Aibėje elementų nėra!");
                return;
            }
            string[] A = new string[elemSk];
            Console.WriteLine("");

            Console.WriteLine("Įveskite aibės elementus, atskirtus tarpo simboliu: ");
            string ivestiDuomenys = Console.ReadLine();
            string[] skiriklis = ivestiDuomenys.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if(skiriklis.Length > elemSk)
            {
                Console.WriteLine("Įvedėte per daug aibės elementų!");
                return;
            }
            for (int i = 0; i < skiriklis.Length; i++)
            {
                A[i] = skiriklis[i];
            }
            Console.WriteLine("Jūsų įvesta aibė: ");
            Console.Write("{ ");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine("}");

            //Poaibių generavimas
            Console.WriteLine("Sugeneruoti poaibiai pirmuoju grėjaus kodo algoritmu");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //Generavimo poaibis. Metodo veikimo laikas matuojamas.
            printSubset(A);

            sw.Stop();
            Console.WriteLine("Metodo veikimo laikas:={0}", sw.Elapsed);


        }

        /// <summary>
        /// Poaibių generavimo ir spausdinimo funkcija
        /// </summary>
        /// <param name="fullSet">Pradinė aibė</param>
        /// <param name="grayCode">Ar versti į Grejaus kodą?</param>
        static void printSubset(string[] fullSet)
        {
            int n = fullSet.Length;
            
                for (int i = 0; i < (1 << n); i++)
                {
                    Console.Write("{ ");

                    for (int j = 0; j < n; j++)
                    {
                        //(1<<n) yra 2^n atitikmuo
                        if ((i & (1 << j)) > 0)
                        {
                            int characterToNumber = int.Parse(fullSet[j].ToString());
                            Console.Write(GrayCode(characterToNumber) + " ");
                        }
                    }
                    Console.Write("}");

                    Console.WriteLine();
                }
        }
        
        /// <summary>
        /// Vertimas į Grėjaus kodą naudojant pirmąjį Grėjaus kodo generavimo metodą.
        /// </summary>
        /// <param name="number">Skaičius, kurį versime į Grėjaus kodą</param>
        /// <returns>Skaičių paverstą į Grėjaus kodą simbolių eilutės pavidalu</returns>
        public static string GrayCode(int number)
        {
            int grayCode = number ^ (number >> 1);
            string result = Convert.ToString(grayCode, 2);
          
            return result;
        }
    }
}
