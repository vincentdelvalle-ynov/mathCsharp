using MathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bonjour.");

            //ExempleFractions();
            ExempleMatrice();

            Console.ReadLine();
        }


        public static void ExempleMatrice()
        {
            Matrice A = SaisirMatrice();
            Matrice B = SaisirMatrice();

            Matrice R = A.Multiplie(B);

        }


        public static Matrice SaisirMatrice()
        {
            Matrice m = null;

            List<int[]> build = new List<int[]>();
            while (SaisirMatriceLigne(build))
            {

            }

            return m;
        }

        public static bool SaisirMatriceLigne(List<int[]> build)
        {
            string input = Console.ReadLine();



            return string.IsNullOrWhiteSpace(input);
        }












        public static void ExempleFractions()
        {
            Fraction f1 = SaisirFraction("Saisir une fraction (A/B):");
            Fraction f2 = SaisirFraction("Saisir une autre fraction:");

            Console.Write("Résultat: {0} + {1} = ", f1, f2);
            f1.Ajouter(f2);
            f1.Simplifier();
            Console.WriteLine("{0}", f1);
        }


        public static Fraction SaisirFraction(string message)
        {
            Fraction f = null;
            while (f == null)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                try
                {
                    f = new Fraction(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur: {0}", ex.Message);
                }
            }
            return f;
        }
    }
}
