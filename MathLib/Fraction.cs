using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MathLib
{
    public class Fraction
    {
        public const string FRACTION_PATTERN = @"([0-9]+)\/([0-9]+)";

        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(string input)
        {
            Regex r = new Regex(FRACTION_PATTERN);
            Match m = r.Match(input);
            if (m.Success)
            {
                int num = Convert.ToInt32(m.Groups[1].Value);
                int den = Convert.ToInt32(m.Groups[2].Value);
                Init(num, den);
            }
            else
            {
                throw new FractionInitException("Format de fraction invalide.");
            }
        }

        public Fraction(int num, int den)
        {
            Init(num, den);
        }

        private void Init(int num, int den)
        {
            if (den == 0)
            {
                throw new FractionInitException("Le dénominateur ne peut pas être à 0.");
            }
            Numerator = num;
            Denominator = den;
            Simplifier();
        }

        public float Value()
        {
            return Numerator / Convert.ToSingle(Denominator);
        }

        public void Simplifier()
        {
            int PGCD; // plus grand dénominateur commun
            int nb1 = Numerator;
            int nb2 = Denominator;
            while (nb1 > 0)
            {
                PGCD = nb1;
                nb1 = nb2 % nb1;
                nb2 = PGCD;
            }
            Numerator /= nb2;
            Denominator /= nb2;
        }

        public void Multiplier(int x)
        {
            this.Numerator *= x;
            this.Denominator *= 1;
        }

        public void Ajouter(Fraction f)
        {
            // this = this + f
            // A/B = A/B + C/D

            // ex: 3/10 + 1/5   

            int denominateurCommun = this.Denominator * f.Denominator;
            // 10 * 5 = 50

            int a = this.Numerator * f.Denominator; // 3 * 5  = 15
            int b = f.Numerator * this.Denominator; // 1 * 10 = 10

            this.Numerator = a + b;
            // 25

            this.Denominator = denominateurCommun;
            // 50
        }

        public void Ajouter(int x)
        {
            Ajouter(new Fraction(x, 1));
        }



        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerator, Denominator);
        }

    }
}
