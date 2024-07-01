using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_SystemControl
{
    public class GeometricInterpretation
    {
        #region Fields
        ParametersValues parametersValues;

        Dictionary<char, Func<Tuple<float, float>, Tuple<float, float>, bool, bool, bool, bool, Tuple<float, float>>> stringToCoordInstruction;
        #endregion

        #region Properties
        public Dictionary<char, Func<Tuple<float, float>, Tuple<float, float>, bool, bool, bool, bool, Tuple<float, float>>> StringToCoordInstruction
        {
            get { return stringToCoordInstruction; }
        }
        #endregion


        #region Constructor
        public GeometricInterpretation(ParametersValues parametersValues)
        {
            this.parametersValues = parametersValues;

            StringToCoordsDictInstantiation();
        }
        #endregion

        #region Methods
        void StringToCoordsDictInstantiation()
        {
            stringToCoordInstruction = new Dictionary<char, Func<Tuple<float, float>, Tuple<float, float>, bool, bool, bool, bool, Tuple<float, float>>>()
            {
                { '!', Initializer },
                { '+', PlusTransformer },
                { '-', MinusTransformer },
                { '|', ReverseDirection }
            };
        }
        #endregion

        #region Functions
        public Tuple<float, float> Initializer(Tuple<float, float> oldCoords, Tuple<float, float> newTempCoords, bool isIncreasingOnXPositive, bool isIncreasingOnXNegative, bool isIncreasingOnYPositive, bool isIncreasingOnYNegative)
        {
            Tuple<float, float> newCoords = null;

            // If isIncreasingOnXPositive we will move to the right on the X axis;
            if (isIncreasingOnXPositive && !isIncreasingOnXNegative && !isIncreasingOnYPositive && !isIncreasingOnYNegative)
            {
                newCoords = new Tuple<float, float>(oldCoords.Item1 + parametersValues.SegmentLength, oldCoords.Item2);
            }
            // If isIncreasingOnXNegative we will move to the Left on the X axis;
            else if (isIncreasingOnXNegative && !isIncreasingOnXPositive && !isIncreasingOnYPositive && !isIncreasingOnYNegative)
            {
                newCoords = new Tuple<float, float>(oldCoords.Item1 - parametersValues.SegmentLength, oldCoords.Item2);
            }
            // If isIncreasingOnYPositive we will move to the top on the X axis;
            else if (isIncreasingOnYPositive && !isIncreasingOnXPositive && !isIncreasingOnXNegative && !isIncreasingOnYNegative)
            {
                newCoords = new Tuple<float, float>(oldCoords.Item1, oldCoords.Item2 + parametersValues.SegmentLength);
            }
            // If isIncreasingOnYNegative we will move to the bottom on the X axis;
            else if (isIncreasingOnYNegative && !isIncreasingOnXPositive && !isIncreasingOnXNegative && !isIncreasingOnYPositive)
            {
                newCoords = new Tuple<float, float>(oldCoords.Item1, oldCoords.Item2 - parametersValues.SegmentLength);
            }
            return newCoords;
        }

        /// Turn Left by a certain angle
        public Tuple<float, float> PlusTransformer(Tuple<float, float> oldCoords, Tuple<float, float> newTempCoords, bool isIncreasingOnXPositive, bool isIncreasingOnXNegative, bool isIncreasingOnYPositive, bool isIncreasingOnYNegative)
        {
            // Computing the angle in degree
            double rotationAngleGrad = parametersValues.RotationAngle * (Math.PI / 180.0);

            // Changing direction anticlockwise
            double newX = ((newTempCoords.Item1 - oldCoords.Item1) * Math.Cos(rotationAngleGrad)) - ((newTempCoords.Item2 - oldCoords.Item2) * Math.Sin(rotationAngleGrad)) + oldCoords.Item1;
            double newY = ((newTempCoords.Item1 - oldCoords.Item1) * Math.Sin(rotationAngleGrad)) + ((newTempCoords.Item2 - oldCoords.Item2) * Math.Cos(rotationAngleGrad)) + oldCoords.Item2;
        
            Tuple<float, float> newCoords = new Tuple<float, float>((float)newX, (float)newY);

            return newCoords;
        }

        /// Turn Rigth by a certain angle
        public Tuple<float, float> MinusTransformer(Tuple<float, float> oldCoords, Tuple<float, float> newTempCoords, bool isIncreasingOnXPositive, bool isIncreasingOnXNegative, bool isIncreasingOnYPositive, bool isIncreasingOnYNegative)
        {
            // Computing the angle in degree
            double rotationAngleGrad = -(parametersValues.RotationAngle * (Math.PI / 180.0));

            // Changing direction anticlockwise
            double newX = ((newTempCoords.Item1 - oldCoords.Item1) * Math.Cos(rotationAngleGrad)) - ((newTempCoords.Item2 - oldCoords.Item2) * Math.Sin(rotationAngleGrad)) + oldCoords.Item1;
            double newY = ((newTempCoords.Item1 - oldCoords.Item1) * Math.Sin(rotationAngleGrad)) + ((newTempCoords.Item2 - oldCoords.Item2) * Math.Cos(rotationAngleGrad)) + oldCoords.Item2;

            Tuple<float, float> newCoords = new Tuple<float, float>((float)newX, (float)newY);

            return newCoords;
        }

        /// Turn Left by a certain angle
        public Tuple<float, float> ReverseDirection(Tuple<float, float> oldCoords, Tuple<float, float> newTempCoords, bool isIncreasingOnXPositive, bool isIncreasingOnXNegative, bool isIncreasingOnYPositive, bool isIncreasingOnYNegative)
        {
            // Computing the angle in degree
            double rotationAngleGrad = -(180 * (Math.PI / 180.0));

            // Changing direction anticlockwise
            double newX = ((newTempCoords.Item1 - oldCoords.Item1) * Math.Cos(rotationAngleGrad)) - ((newTempCoords.Item2 - oldCoords.Item2) * Math.Sin(rotationAngleGrad)) + oldCoords.Item1;
            double newY = ((newTempCoords.Item1 - oldCoords.Item1) * Math.Sin(rotationAngleGrad)) + ((newTempCoords.Item2 - oldCoords.Item2) * Math.Cos(rotationAngleGrad)) + oldCoords.Item2;

            Tuple<float, float> newCoords = new Tuple<float, float>((float)newX, (float)newY);

            return newCoords;
        }
        #endregion
    }
}
