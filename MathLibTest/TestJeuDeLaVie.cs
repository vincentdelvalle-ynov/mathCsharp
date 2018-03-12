using MathLib.Helpers;
using MathLib.JeuDeLaVie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibTest
{
    [TestClass]
    public class TestJeuDeLaVie
    {


        [TestMethod]
        public void TestJeuFigureCarreAjoutOK()
        {
            Jeu jeu = new Jeu(5, 5);
            FigureCarre carre = new FigureCarre(1, 1);

            // ajout de la figure
            Assert.IsTrue(jeu.AjouterFigure(carre));

            // présence du carré
            Assert.IsTrue(jeu.State[1, 1]);
            Assert.IsTrue(jeu.State[1, 2]);
            Assert.IsTrue(jeu.State[2, 1]);
            Assert.IsTrue(jeu.State[2, 2]);

            // absence du carré
            Assert.IsFalse(jeu.State[0, 0]);
            Assert.IsFalse(jeu.State[0, 1]);
            Assert.IsFalse(jeu.State[1, 0]);
        }

        [TestMethod]
        public void TestJeuFigureCarreAjoutKO()
        {
            Jeu jeu = new Jeu(5, 5);
            FigureCarre carre = new FigureCarre(4, 4);

            // ajout de la figure
            Assert.IsFalse(jeu.AjouterFigure(carre));

            // absence du carré dans tout le jeu
            jeu.State.Parcourir((i, j) => Assert.IsFalse(jeu.State[i, j]));
        }

        [TestMethod]
        public void TestJeuFigureClignotantAjoutOK()
        {
            Jeu jeu = new Jeu(5, 5);
            FigureClignotant clignotant = new FigureClignotant(1, 1);

            // ajout de la figure
            Assert.IsTrue(jeu.AjouterFigure(clignotant));

            // présence du clignotant
            Assert.IsTrue(jeu.State[1, 2]);
            Assert.IsTrue(jeu.State[2, 2]);
            Assert.IsTrue(jeu.State[3, 2]);

            // absence du clignotant
            Assert.IsFalse(jeu.State[0, 1]);
            Assert.IsFalse(jeu.State[0, 2]);
            Assert.IsFalse(jeu.State[0, 3]);
            Assert.IsFalse(jeu.State[2, 1]);
            Assert.IsFalse(jeu.State[2, 3]);
            Assert.IsFalse(jeu.State[4, 2]);
        }

        [TestMethod]
        public void TestJeuFigureClignotantAjoutKO()
        {
            Jeu jeu = new Jeu(5, 5);
            FigureClignotant clignotant = new FigureClignotant(4, 4);

            // ajout de la figure
            Assert.IsFalse(jeu.AjouterFigure(clignotant));

            // absence du clignotant
            jeu.State.Parcourir((i, j) => Assert.IsFalse(jeu.State[i, j]));
        }

        [TestMethod]
        public void TestJeuUpdate()
        {
            Jeu jeu = new Jeu(5, 5);
            jeu.AjouterFigure(new FigureClignotant(1, 1));

            Assert.IsTrue(jeu.State[1, 2]);
            Assert.IsTrue(jeu.State[2, 2]);
            Assert.IsTrue(jeu.State[3, 2]);

            jeu.Update();

            Assert.IsTrue(jeu.State[2, 1]);
            Assert.IsTrue(jeu.State[2, 2]);
            Assert.IsTrue(jeu.State[2, 3]);
        }



    }
}
