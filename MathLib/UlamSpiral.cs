using MathLib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public class UlamSpiral
    {
        public int[,] Matrix { get; set; }
        public int MaxCycle { get; set; }
        public int TargetValue { get; set; }
        public int[] CurrentLocation { get; set; }
        public int currentValue { get; set; }

        public UlamSpiral(int targetValue)
        {
            this.TargetValue = targetValue;

            // target => cycle (max)
            MaxCycle = GetCycleNumberFromValue(targetValue);
            
            // MaxCycle => SpiralSize
            int size = GetSpiralSize(MaxCycle);

            // init
            Matrix = new int[size, size];

        }

        public int Resolve()
        {
            Cycle(MaxCycle, true);

            int[] origin = GetCenterLocation();
            int distance = 0;

            distance += Math.Abs(origin[0] - CurrentLocation[0]);
            distance += Math.Abs(origin[1] - CurrentLocation[1]);

            return distance;
        }

        public void Cycle(int cycleNumber, bool stopIfTargetFounded = false)
        {
            int size = GetSpiralSize(cycleNumber);
            currentValue = GetMinValue(cycleNumber) - 1;
            CurrentLocation = GetStartLocation(cycleNumber);
            
            // vers le haut : location[1] -> location[1] - size + 1
            // sur Y en arrière
            if(stepGoTop(size, stopIfTargetFounded)) return;

            // vers la gauche : location[0] - 1 -> location[0] - size
            // sur X en arrière
            if(stepGoLeft(size, stopIfTargetFounded)) return;

            // vers le bas : location[1] + 1 -> location[1] + size
            // sur Y en avant
            if(stepGoBottom(size, stopIfTargetFounded)) return;

            // vers la droite : location[0] + 1 -> location[0] + size
            // sur X vers l'avant
            if(stepGoRight(size, stopIfTargetFounded)) return;
        }

        bool stepGoRight(int size, bool stopIfTargetFounded)
        {
            return stepGo(CurrentLocation[0] + 1, CurrentLocation[0] + size,
                x => {
                    CurrentLocation[0] = x;
                    return stepMethod(stopIfTargetFounded);
                }
            );
        }

        bool stepGoBottom(int size, bool stopIfTargetFounded)
        {
            return stepGo(CurrentLocation[1] + 1, CurrentLocation[1] + size,
                y => {
                    CurrentLocation[1] = y;
                    return stepMethod(stopIfTargetFounded);
                });
        }

        bool stepGoLeft(int size, bool stopIfTargetFounded)
        {
            return stepGo(CurrentLocation[0] - 1, CurrentLocation[0] - size,
                x =>{
                    CurrentLocation[0] = x;
                    return stepMethod(stopIfTargetFounded);
                });
        }

        bool stepGoTop(int size, bool stopIfTargetFounded)
        {
            return stepGo(CurrentLocation[1], CurrentLocation[1] - size + 1,
                y => {
                    CurrentLocation[1] = y;
                    return stepMethod(stopIfTargetFounded);
                });
        }

        bool stepGo(int start, int end, Func<int, bool> nextIteration)
        {
            return UlamSpiralHelper.DIciVersLa(start, end, nextIteration);
        }

        bool stepMethod(bool stopIfTargetFounded)
        {
            Matrix[CurrentLocation[1], CurrentLocation[0]] = ++currentValue;

            return stopIfTargetFounded && currentValue == TargetValue;
        }



        public int GetCycleNumberFromValue(int target)
        {
            int cycleNumber = -1;
            int maxValueCycle = 0;
            
            do
            {
                maxValueCycle = GetMaxValue(++cycleNumber);
            }
            while (maxValueCycle < target);
            
            return cycleNumber;
        }

        public int GetSpiralSize(int cycleNumber)
        {
            // 0 => 2 x 0 + 1 = 1
            // 1 => 2 x 1 + 1 = 3

            // f(x) = 2x + 1
            return 2 * cycleNumber + 1;
        }

        public int GetMaxValue(int cycleNumber)
        {

            // 0 => 1  (1x1)
            // 1 => 9  (3x3)
            // 2 => 25 (5x5)
            // 3 => 49 (7x7)
            // 4 => 81 (9x9)
            
            // f(x) = (2x + 1)²
            return Convert.ToInt32(Math.Pow(GetSpiralSize(cycleNumber), 2));
        }

        public int GetMinValue(int cycleNumber)
        {
            return GetMaxValue(cycleNumber - 1) + 1; // f(x) = f'(x-1) + 1
        }

        public int[] GetStartLocation(int cycleNumber)
        {
            // 0 => centre
            int[] location = GetCenterLocation();
            if(cycleNumber > 0)
            {
                // 1 => x++
                location[0]++;

                // 2 => x++ & y++;
                if(cycleNumber > 1)
                {
                    location[0] += cycleNumber - 1;
                    location[1] += cycleNumber - 1;
                }
            }

            return location;
        }

        public int[] GetCenterLocation()
        {
            return new int[]
            {
                (Matrix.GetLength(1) - 1) / 2, // x
                (Matrix.GetLength(0) - 1) / 2  // y
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            Matrix.Parcourir((i, j) =>
            {
                if (j == 0)
                {
                    builder.Append('(');
                }

                builder.Append(string.Format(" {0,3}", Matrix[i, j]));

                if (j == Matrix.GetLength(1) - 1)
                {
                    builder.Append(" )\n");
                }
            });

            return builder.ToString();
        }
    }
}
