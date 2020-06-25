using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sreader = new StreamReader("fileF.txt");

            string[] readFile = sreader.ReadLine().Split(' ');

            sreader.Close();

            string[] EveryLine = File.ReadAllLines("fileF.txt", System.Text.Encoding.Default);
            string[] WordsInString = new string[readFile.Length];

            StreamWriter swriter = new StreamWriter("fileG.txt");

            string[] arrayMarka = new string[EveryLine.Length];

            for (int i = 0; i < EveryLine.Length; i++)
            {
                WordsInString = EveryLine[i].Split(' ');
                arrayMarka[i] = WordsInString[0]; 
            }

            Console.WriteLine("Количество разных марок:");

            Dictionary<string, int> Brands = new Dictionary<string, int>(); 
                                                                                                         
            for (int i = 1; i < arrayMarka.Length; i++)                                                 
            {                                                                                            
                if (Brands.ContainsKey(arrayMarka[i]))                                                   
                    Brands[arrayMarka[i]]++;                                                             
                else                                                                                     
                    Brands.Add(arrayMarka[i], 1);                                                        
            }                                                                                            
                                                                                                         
            foreach (KeyValuePair<string, int> OneBrand in Brands)                                       
            {                                                                                            
                Console.Write("\nКоличество марок {0} - {1} ", OneBrand.Key, OneBrand.Value);            
                swriter.WriteLine("\nКоличество марок {0} - {1} ", OneBrand.Key, OneBrand.Value);        
            }

            Console.Write("\n\nВведите искомую марку с большой буквы : ");
            string Marka = Console.ReadLine();

            for (int i = 0; i < EveryLine.Length; i++)
            {
                WordsInString = EveryLine[i].Split(' ');

                for (int j = 0; j < WordsInString.Length; j++)
                {
                    if (WordsInString[j] == Marka)
                    {
                        swriter.WriteLine("\nВладелец: " + WordsInString[WordsInString.Length - 1] + "\tНомер автомобиля: " + WordsInString[WordsInString.Length - 2]);
                        Console.WriteLine("\nВладелец: " + WordsInString[WordsInString.Length - 1] + "\tНомер автомобиля: " + WordsInString[WordsInString.Length - 2]);
                    }
                }
            }

            swriter.Close();
            Console.ReadKey();
        }
    }
}
