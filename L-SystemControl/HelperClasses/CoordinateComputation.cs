using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_SystemControl
{
    public static class CoordinateComputation
    {
        public static List<Tuple<float, float>> CoordConstruction(Tuple<float, float> controlCenter, string lSystemString, GeometricInterpretation stringToCoordInstruction, int panelHeight) //, out List<Tuple<float, float>> newCoordsToPlot
        {
            List<Tuple<float, float>> newCoordsToPlot = new List<Tuple<float, float>>();

            // Adding the starting point (the center of the control) to the final list of coords that will be plotted
            newCoordsToPlot.Add(controlCenter);

            // Stack initialization
            Stack<List<Tuple<float, float>>> myStack = new Stack<List<Tuple<float, float>>>();

            // Converting the lSystemString to the new Coords
            Tuple<float, float> previousCoords = controlCenter;

            // Initializing the direction of the move
            bool increasingOnXPositive = false;
            bool increasingOnXNegative = false;
            bool increasingOnYPositive = false;
            bool increasingOnYNegative = false;

            bool firstAddedtoStack = false;

            Tuple<float, float> newCoord = controlCenter;
            Tuple<float, float> tempNewCoord = null;

            int iter = 0;
            foreach (char c in lSystemString)
            {
                if (c != 'F' && c != '[' && c != ']' && !stringToCoordInstruction.StringToCoordInstruction.ContainsKey(c))
                {
                    continue;
                }

                if (iter == 0)
                {
                    increasingOnXPositive = false;
                    increasingOnXNegative = false;
                    increasingOnYPositive = true;
                    increasingOnYNegative = false;

                    tempNewCoord = stringToCoordInstruction.StringToCoordInstruction['!'].Invoke(previousCoords, tempNewCoord, increasingOnXPositive, increasingOnXNegative, increasingOnYPositive, increasingOnYNegative);
                }

                if (tempNewCoord == null)
                {
                    tempNewCoord = MoveForward(previousCoords, newCoord);
                }

                if (c == 'F')
                {
                    // Adding the new coords to the list to print
                    newCoordsToPlot.Add(tempNewCoord);

                    previousCoords = newCoord;

                    newCoord = tempNewCoord;

                    tempNewCoord = null;
                }

                // Push current state to stack
                //
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                // Each time that a push or a pop (still needs to evaluate which one of the two) is perfomed, re-save the previous coordinate to the list of coordinates, other than the (-1, -1)
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                else if (c == '[')
                {
                    List<Tuple<float, float>> listToPutInStack = new List<Tuple<float, float>>();

                    listToPutInStack.Add(previousCoords);
                    listToPutInStack.Add(newCoord);
                    listToPutInStack.Add(tempNewCoord);

                    myStack.Push(listToPutInStack);

                    if (!firstAddedtoStack)
                    {
                        Tuple<float, float> interruption = new Tuple<float, float>(-1, -1);
                        // Adding a null value to the points to plot
                        newCoordsToPlot.Add(interruption);
                        newCoordsToPlot.Add(newCoord);
                        firstAddedtoStack = true;
                    }
                }
                // Pop current state to stack
                else if (c == ']')
                {
                    List<Tuple<float, float>> listPoppedFromTheStack = myStack.Pop();

                    previousCoords = listPoppedFromTheStack[0];
                    newCoord = listPoppedFromTheStack[1];
                    tempNewCoord = listPoppedFromTheStack[2];


                    Tuple<float, float> interruption = new Tuple<float, float>(-2, -2);
                    //Adding a null value to the points to plot
                    newCoordsToPlot.Add(interruption);
                    newCoordsToPlot.Add(newCoord);


                }
                else
                {
                    tempNewCoord = stringToCoordInstruction.StringToCoordInstruction[c].Invoke(newCoord, tempNewCoord, increasingOnXPositive, increasingOnXNegative, increasingOnYPositive, increasingOnYNegative);
                }

                iter++;
            }

            return newCoordsToPlot;
        }



        public static Tuple<float, float> MoveForward(Tuple<float, float> pointToRotate, Tuple<float, float> pivotPoint)
        {
            double rotationAngleGrad = (180 * Math.PI / 180);

            // Changing direction anticlockwise
            double newX = ((pointToRotate.Item1 - pivotPoint.Item1) * Math.Cos(rotationAngleGrad)) - ((pointToRotate.Item2 - pivotPoint.Item2) * Math.Sin(rotationAngleGrad)) + pivotPoint.Item1;
            double newY = ((pointToRotate.Item1 - pivotPoint.Item1) * Math.Sin(rotationAngleGrad)) + ((pointToRotate.Item2 - pivotPoint.Item2) * Math.Cos(rotationAngleGrad)) + pivotPoint.Item2;

            Tuple<float, float> newMovePoint = new Tuple<float, float>((float)newX, (float)newY);

            return newMovePoint;
        }
    }
}
