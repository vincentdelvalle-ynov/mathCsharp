﻿using MathLib;
using MathLib.JeuDeLaVie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MathConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MathCSharp");
            Console.WriteLine("==========");
            Console.WriteLine("");

            //ExempleFractions();
            //ExempleMatrice();
            //ExempleJeuDeLaVie();
            ExempleSpiral();
            
            Console.ReadLine();
        }
        
        public static void ExempleSpiral()
        {

            UlamSpiral spiral = new UlamSpiral(189);
            System.Diagnostics.Stopwatch watch;

            //
            watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i <= spiral.MaxCycle; i++)
            {
                spiral.Cycle(i);
            }
            watch.Stop();
            Console.WriteLine("{0} ticks pour les cycles", watch.ElapsedTicks);
            /**/

            watch = System.Diagnostics.Stopwatch.StartNew();
            int distance = spiral.Resolve();
            watch.Stop();


            Console.WriteLine("{0} ticks pour la résolution", watch.ElapsedTicks);
            Console.WriteLine("{0} est à une distance de {1} du centre.", spiral.TargetValue, distance);
            Console.WriteLine(spiral);
        }

        public static void ExempleJeuDeLaVie()
        {
            Console.OutputEncoding = Encoding.Unicode; // UTF-16
            // Note: UTF-32 n'est pas supporté pour la Console...
            
            Console.CursorVisible = false;

            Jeu jeu = new Jeu(25, 15);
            //jeu.AjouterFigure(new FigureCarre(1, 1));
            //jeu.AjouterFigure(new FigureClignotant(5, 6));
            //jeu.AjouterFigure(new FigureRandom(10, 2, 10, 10));
            jeu.AjouterFigure(new FigureRandom(0, 0, 24, 14));

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(jeu);
                jeu.Update();

                Thread.Sleep(300);
            }

        }
        




        public static void ExempleMatrice()
        {
            Console.WriteLine("Exemple de produit matriciel : ");

            Console.WriteLine("Saisissez une matrice A :");
            Matrice A = SaisirMatrice();

            Console.WriteLine("Saisissez une matrice B :");
            Matrice B = SaisirMatrice();

            Console.WriteLine("A x B =");

            try
            {
                Console.Write(A.Multiplie(B));
            }
            catch (MatriceException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public static Matrice SaisirMatrice()
        {
            Matrice m = null;
            List<int[]> build = new List<int[]>();

            int[] previousLine = null;
            while (SaisirMatriceLigne(build, previousLine))
            {
                if(build.Count > 0)
                    previousLine = build.Last();
            }

            int[,] matrice = new int[build.Count, build.First().Length];
            matrice.Parcourir((i, j) =>
            {
                matrice[i, j] = build[i][j];
            });

            m = new Matrice(matrice);
            Console.WriteLine("Vous avez saisie la matrice suivante :");
            Console.WriteLine(m);
            return m;
        }
        
        public static bool SaisirMatriceLigne(List<int[]> build, int[] previousLine)
        {
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                if(previousLine == null)
                {
                    Console.WriteLine("Vous devez saisir au moins une ligne");
                    return true;
                }
                return false; // fin de la saisie
            }
            
            Regex regex = new Regex(@"-?[0-9]+ ?");

            if (regex.IsMatch(input))
            {
                string[] tabString = input.Split(' ');
                IEnumerable<int> request = tabString.Select(item => Convert.ToInt32(item));
                int[] tab = request.ToArray();

                if(previousLine != null && tab.Length != previousLine.Length)
                {
                    Console.WriteLine("La ligne doit faire une taille de {0}", previousLine.Length);
                    return true; // try again
                }

                build.Add(tab);
                return true;
            }
            else
            {
                Console.WriteLine("Saisie incorrecte");
                return true;
            }
            
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
