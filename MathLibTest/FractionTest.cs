using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib;

namespace MathLibTest
{
    [TestClass]
    public class FractionTest
    {
        [TestMethod]
        public void TestFractionSimplifier()
        {
            Fraction f = new Fraction(2, 4);
            Assert.AreEqual(1, f.Numerator);
            Assert.AreEqual(2, f.Denominator);

            f = new Fraction(3, 10);
            Assert.AreEqual(3, f.Numerator);
            Assert.AreEqual(10, f.Denominator);
        }

        [TestMethod]
        public void TestFractionAjouterSimplifié()
        {
            Fraction f = new Fraction(3, 10);
            f.Ajouter(new Fraction(2, 10));
            f.Simplifier();
            Assert.AreEqual(1, f.Numerator);
            Assert.AreEqual(2, f.Denominator);

            f = new Fraction(3, 10);
            f.Ajouter(new Fraction(1, 5));
            f.Simplifier();
            Assert.AreEqual(1, f.Numerator);
            Assert.AreEqual(2, f.Denominator);
        }

        [TestMethod]
        public void TestFractionAjouterNonSimplifié()
        {
            Fraction f = new Fraction(1, 2);
            f.Ajouter(f);
            Assert.AreNotEqual(2, f.Numerator);
            Assert.AreNotEqual(2, f.Denominator);

            f = new Fraction(3, 10);
            f.Ajouter(new Fraction(1, 5));
            Assert.AreEqual(25, f.Numerator);
            Assert.AreEqual(50, f.Denominator);
        }

        [TestMethod]
        public void TestFractionWithDenominateur0()
        {
            try
            {
                Fraction f = new Fraction(1, 0);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(FractionInitException));
            }
        }
        [TestMethod]
        public void TestFractionFromStringKoFormat()
        {
            try
            {
                Fraction f = new Fraction("fjiejoz");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(FractionInitException));
            }
        }
        [TestMethod]
        public void TestFractionFromStringKoValue()
        {
            try
            {
                Fraction f = new Fraction("5/0");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(FractionInitException));
            }
        }

        [TestMethod]
        public void TestFractionFromString()
        {
            Fraction f = new Fraction("1/2");
            Assert.AreEqual(1, f.Numerator);
            Assert.AreEqual(2, f.Denominator);
        }



        [TestMethod]
        public void TestFractionMultiplier()
        {
            Fraction f = new Fraction(1, 2);
            f.Multiplier(5);

            Assert.AreEqual(5, f.Numerator);
            Assert.AreEqual(2, f.Denominator);
        }

        [TestMethod]
        public void TestFractionMultiplierSimplifier()
        {
            Fraction f = new Fraction(1, 10);
            f.Multiplier(10);
            f.Simplifier();
            Assert.AreEqual(1, f.Numerator);
            Assert.AreEqual(1, f.Denominator);
        }

    }
}
