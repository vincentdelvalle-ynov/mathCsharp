﻿using MathLib;
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
            System.Console.WriteLine("Bonjour.");

            Fraction f1 = SaisirFraction("Saisir une fraction (A/B):");
            Fraction f2 = SaisirFraction("Saisir une autre fraction:");

            System.Console.Write("Résultat: {0} + {1} = ", f1, f2);
            f1.Ajouter(f2);
            f1.Simplifier();
            System.Console.WriteLine("{0}", f1);

            System.Console.ReadLine();
        }


        public static Fraction SaisirFraction(string message)
        {
            Fraction f = null;
            while (f == null)
            {
                System.Console.WriteLine(message);
                string input = System.Console.ReadLine();
                try
                {
                    f = new Fraction(input);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Erreur: {0}", ex.Message);
                }
            }
            return f;
        }
    }
}