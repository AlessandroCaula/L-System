using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_SystemControl
{
    public class ParametersValues
    {
        #region Fields
        string axiom;
        char character;
        string function;
        int iterations;
        int segmentLength;
        int rotationAngle;
        //Dictionary<char, string> rewritingRule;
        #endregion

        #region Constructor
        public ParametersValues()
        {
            // Default values
            axiom = "F";
            character = 'F';
            function = "FF+[+F-F-F]-[-F+F+F]";
            iterations = 4;
            segmentLength = 10;
            rotationAngle = 22;
        }
        #endregion

        #region Properties
        public string Axiom
        {
            get { return axiom; }
            set
            {
                axiom = value;
            }
        }

        public char Character
        {
            get { return character; }
            set
            {
                character = value;
            }
        }

        public string Function
        {
            get { return function; }
            set
            {
                function = value;
            }
        }

        public int Iterations
        {
            get { return iterations; }
            set
            {
                iterations = value;
            }
        }

        public int SegmentLength
        {
            get { return segmentLength; }
            set
            {
                segmentLength = value;
            }
        }

        public int RotationAngle
        {
            get { return rotationAngle; }
            set
            {
                rotationAngle = value;
            }
        }
        #endregion

    }
}
