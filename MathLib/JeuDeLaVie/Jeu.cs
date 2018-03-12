using MathLib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.JeuDeLaVie
{
    public class Jeu
    {
        public bool[,] State { get; set; }

        public Jeu(int n, int m)
        {
            State = new bool[m, n];
        }

        public void Update()
        {
            bool[,] newState = new bool[State.GetLength(0), State.GetLength(1)];
            newState.Parcourir((i, j) => {
                int nb = NombreVoisinesVivantes(i, j);

                if(nb == 3)
                {
                    newState[i, j] = true;
                }

                if(nb == 2)
                {
                    newState[i, j] = State[i, j];
                }

                if(nb < 2 || nb > 3)
                {
                    newState[i, j] = false;
                }
            });

            State = newState;
        }

        public int NombreVoisinesVivantes(int _i, int _j)
        {
            int nb = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if( i != 0 || j != 0)
                    {
                        int x = _j + j;
                        int y = _i + i;

                        if( x > 0 && x < State.GetLength(1)
                            && y > 0 && y < State.GetLength(0))
                        {
                            if (State[y, x])
                            {
                                nb++;
                            }
                        }
                    }
                }
            }
            return nb;
        }

        public bool AjouterFigure(Figure figure)
        {
            if( figure.GetLocationX() < 0 || figure.GetLocationY() < 0
                || figure.GetLocationX() + figure.GetWidth() >= State.GetLength(1)
                || figure.GetLocationX() + figure.GetWidth() < 0
                || figure.GetLocationY() + figure.GetHeight() >= State.GetLength(0)
                || figure.GetLocationY() + figure.GetHeight() < 0)
            {
                return false;
            }
            
            figure.Matrice.Parcourir((i, j) =>
            {
                int x = j + figure.GetLocationX();
                int y = i + figure.GetLocationY();

                State[y, x] = figure.Matrice[i, j];
            });
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            State.Parcourir((i, j) =>
            {

                // ■ => U+25A0 ; □ => U+25A1
                // ⬛ => U+2B1B ; ⬜ => U+2B1C
                builder.Append(string.Format(" {0}", State[i, j] ? '■' : '□'));

                if (j == State.GetLength(1) - 1)
                {
                    builder.Append('\n');
                }
            });

            return builder.ToString();
        }
    }
}
