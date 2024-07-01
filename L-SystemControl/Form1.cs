//using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L_SystemControl
{
    public partial class Form1 : Form
    {
        #region Fields
        Plotting controlPlotting;
        LSystemGeneration lSystemGeneration;
        GeometricInterpretation geometricInterpretation;
        ParametersValues parametersValues;
        RewritingRules rewritingRules;
        TextBox textEditAxiom;
        TextBox textEditFunction;
        TextBox textEditCharacter;
        TextBox textEditIterations;
        TextBox textEditAngle;
        TextBox textEditLength;
        Button simpleFakeButton;

        public int panelHeight;

        //Dictionary<char, Func<Tuple<float, float>, Tuple<float, float>, bool, bool, bool, bool, Tuple<float, float>>> stringToCoordInstruction;

        //string lSystemString;
        #endregion

        public Form1()
        {
            InitializeComponent();

            // Initialize supporting Classes
            //
            parametersValues = new ParametersValues();

            //this.axiom = defaultValues.Axiom;
            //this.character = defaultValues.Character;
            //this.function = defaultValues.Function;
            //this.iterations = defaultValues.Iterations;
            //this.segmentLength = defaultValues.SegmentLength;
            //this.rotationAngle = defaultValues.RotationAngle;

            rewritingRules = new RewritingRules();

            // Initializing the L-System generation class
            lSystemGeneration = new LSystemGeneration();

            // Instantiating the object for the geometricInterpretation 
            geometricInterpretation = new GeometricInterpretation(parametersValues);

            InitializePanelsAndTools();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (parametersValues == null)
                return;

            base.OnSizeChanged(e);

            Controls.Clear();
            InitializePanelsAndTools();
        }
        private void InitializePanelsAndTools()
        {
            // Maximizing the dimension of the WinForm
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            // Creating the and adding the controls and the button
            controlPlotting = new Plotting();

            simpleButtonRunLSystem.Dock = DockStyle.Right;
            this.Controls.Add(simpleButtonRunLSystem);
            simpleButtonRunLSystem.Width = 100;
            simpleButtonRunLSystem.Text = "Run the L-System";

            this.textEditAxiom = new TextBox();
            Panel panelCharAndFuncContainer = new Panel();
            this.textEditFunction = new TextBox();
            this.textEditCharacter = new TextBox();
            Button buttonUploadFunctions = new Button();
            Button buttonEmptyDictionary = new Button();
            Panel panelAngleIterLengthContainer = new Panel();
            this.textEditAngle = new TextBox();
            this.textEditIterations = new TextBox();
            this.textEditLength = new TextBox();
            this.simpleFakeButton = new Button();

            panelCharAndFuncContainer.BorderStyle = BorderStyle.None;
            panelAngleIterLengthContainer.BorderStyle = BorderStyle.None;

            textEditAxiom.BringToFront();
            panelCharAndFuncContainer.BringToFront();
            panelAngleIterLengthContainer.BringToFront();

            textEditAxiom.Dock = DockStyle.Top;
            panelCharAndFuncContainer.Dock = DockStyle.Top;
            textEditCharacter.Dock = DockStyle.Left;
            textEditFunction.Dock = DockStyle.Left;
            buttonUploadFunctions.Dock = DockStyle.Left;
            buttonEmptyDictionary.Dock = DockStyle.Left;
            panelAngleIterLengthContainer.Dock = DockStyle.Top;
            textEditAngle.Dock = DockStyle.Left;
            textEditLength.Dock = DockStyle.Left;
            textEditIterations.Dock = DockStyle.Left;
            simpleFakeButton.Dock = DockStyle.Left;

            // Default Values
            textEditAxiom.Text = parametersValues.Axiom;
            textEditCharacter.Text = parametersValues.Character.ToString();
            textEditFunction.Text = parametersValues.Function;
            buttonUploadFunctions.Text = "Upload character and function";
            buttonEmptyDictionary.Text = "Empty Dictionary";
            textEditAngle.Text = parametersValues.RotationAngle.ToString();
            textEditLength.Text = parametersValues.SegmentLength.ToString();
            textEditIterations.Text = parametersValues.Iterations.ToString();
            simpleFakeButton.Text = "Upload Angle, Length and NumberOfIterations";

            panelCharAndFuncContainer.Height = textEditCharacter.Height;
            panelAngleIterLengthContainer.Height = textEditCharacter.Height;

            panelCharAndFuncContainer.Controls.Add(buttonEmptyDictionary);
            panelCharAndFuncContainer.Controls.Add(buttonUploadFunctions);
            panelCharAndFuncContainer.Controls.Add(textEditFunction);
            panelCharAndFuncContainer.Controls.Add(textEditCharacter);

            panelAngleIterLengthContainer.Controls.Add(simpleFakeButton);
            panelAngleIterLengthContainer.Controls.Add(textEditIterations);
            panelAngleIterLengthContainer.Controls.Add(textEditLength);
            panelAngleIterLengthContainer.Controls.Add(textEditAngle);

            this.Controls.Add(panelAngleIterLengthContainer);
            this.Controls.Add(panelCharAndFuncContainer);
            this.Controls.Add(textEditAxiom);

            int totalWidth = this.Size.Width;

            panelCharAndFuncContainer.Width = totalWidth;
            textEditCharacter.Width = (int)(totalWidth / 4);
            textEditFunction.Width = (int)(totalWidth / 4);
            buttonUploadFunctions.Width = (int)(totalWidth / 4);
            buttonEmptyDictionary.Width = (int)(totalWidth / 4 + (totalWidth % 4));

            panelAngleIterLengthContainer.Width = totalWidth;
            textEditAngle.Width = (int)(totalWidth / 4);
            textEditLength.Width = (int)(totalWidth / 4);
            textEditIterations.Width = (int)(totalWidth / 4);
            simpleFakeButton.Width = (int)(totalWidth / 4 + (totalWidth % 4));

            controlPlotting.Dock = DockStyle.Fill;
            this.Controls.Add(controlPlotting);

            this.panelHeight = controlPlotting.Height;

            // Test events on the control to see what they do
            controlPlotting.Paint -= ControlPlotting_Paint;

            //controlPlotting.MouseClick += ControlPlotting_MouseClick;
            simpleButtonRunLSystem.Click -= SimpleButton1_Click;
            simpleButtonRunLSystem.Click += SimpleButton1_Click;

            // Button action when uploading character 
            buttonUploadFunctions.Click -= ButtonUploadFunctions_Click;
            buttonUploadFunctions.Click += ButtonUploadFunctions_Click;

            // Action at empty dictionary button click 
            buttonEmptyDictionary.Click -= ButtonEmptyDictionary_Click;
            buttonEmptyDictionary.Click += ButtonEmptyDictionary_Click;
        }
        private void ButtonEmptyDictionary_Click(object sender, EventArgs e)
        {
            rewritingRules.EmptyDictionary();
            textEditCharacter.Text = "";
            textEditFunction.Text = "";
        }
        private void ButtonUploadFunctions_Click(object sender, EventArgs e)
        {
            rewritingRules.AddToDictionary(char.Parse(textEditCharacter.Text), textEditFunction.Text);
        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            rewritingRules.AddToDictionary(char.Parse(textEditCharacter.Text), textEditFunction.Text);

            // Retrieving new parameters
            parametersValues.Iterations = Int32.Parse(textEditIterations.Text);
            parametersValues.Axiom = textEditAxiom.Text;
            parametersValues.RotationAngle = Int32.Parse(textEditAngle.Text);
            parametersValues.SegmentLength = Int32.Parse(textEditLength.Text);

            lSystemGeneration.AxiomSystemGeneration(parametersValues.Axiom, parametersValues.Iterations, rewritingRules.RewritingRulesDict);

            controlPlotting.Paint += ControlPlotting_Paint;
            controlPlotting.Refresh();
            controlPlotting.Paint -= ControlPlotting_Paint;
        }
        private void ControlPlotting_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, (float)0.5);
            Pen pTransparent = new Pen(Color.Red, (float)0.5);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            // Defining the center of the control plot
            Tuple<float, float> controlCenter = new Tuple<float, float>(controlPlotting.Width / 2, controlPlotting.Height / 2);

            // Computing the new coordinates to plot
            List<Tuple<float, float>> newCoordsToPlot = CoordinateComputation.CoordConstruction(controlCenter, lSystemGeneration.LSystemString, geometricInterpretation, this.panelHeight);

            List<Tuple<float, float>> centeredCoordsToPlot = ImageCentering(newCoordsToPlot, newCoordsToPlot[0]);

            // Center of the Plot, first coordinate to be plotted
            Tuple<float, float> previousCoords = centeredCoordsToPlot[0];

            int i = 0;
            foreach (Tuple<float, float> currCoordsToPlot in centeredCoordsToPlot)
            {
                if (currCoordsToPlot.Item1 == -1 || currCoordsToPlot.Item1 == -2 || previousCoords.Item1 == -1 || previousCoords.Item1 == -2)
                {
                    e.Graphics.DrawLine(p, Point.Empty, Point.Empty);
                    previousCoords = currCoordsToPlot;
                    continue;
                }
                else
                {
                    e.Graphics.DrawLine(p, previousCoords.Item1, panelHeight - previousCoords.Item2, currCoordsToPlot.Item1, panelHeight - currCoordsToPlot.Item2);
                }

                previousCoords = currCoordsToPlot;
            }
        }
        private List<Tuple<float, float>> ImageCentering(List<Tuple<float, float>> plotCoords, Tuple<float, float> originCoords)
        {
            List<Tuple<float, float>> translatedCoords = new List<Tuple<float, float>>();

            // Finding the extreme 4 coordinates of the image
            double xMax = double.MinValue;
            double xMin = double.MaxValue;
            double yMax = double.MinValue;
            double yMin = double.MaxValue;
            Tuple<float, float> xMaxCoords = null;
            Tuple<float, float> xMinCoords = null;
            Tuple<float, float> yMaxCoords = null;
            Tuple<float, float> yMinCoords = null;

            foreach (Tuple<float, float> currentCoord in plotCoords)
            {
                if (currentCoord.Item1 == -1)
                {
                    continue;
                }
                if (currentCoord.Item1 == -2)
                {
                    continue;
                }
                if (currentCoord.Item1 > xMax)
                {
                    xMax = currentCoord.Item1;
                    xMaxCoords = new Tuple<float, float>(currentCoord.Item1, currentCoord.Item2);
                }
                if (currentCoord.Item1 < xMin)
                {
                    xMin = currentCoord.Item1;
                    xMinCoords = new Tuple<float, float>(currentCoord.Item1, currentCoord.Item2);
                }
                if (currentCoord.Item2 > yMax)
                {
                    yMax = currentCoord.Item2;
                    yMaxCoords = new Tuple<float, float>(currentCoord.Item1, currentCoord.Item2);
                }
                if (currentCoord.Item2 < yMin)
                {
                    yMin = currentCoord.Item2;
                    yMinCoords = new Tuple<float, float>(currentCoord.Item1, currentCoord.Item2);
                }
            }

            // Finding the center of mass of these points
            float xCenterOfMass = (xMaxCoords.Item1 + xMinCoords.Item1 + yMaxCoords.Item1 + yMinCoords.Item1) / 4;
            float yCenterOfMass = (xMaxCoords.Item2 + xMinCoords.Item2 + yMaxCoords.Item2 + yMinCoords.Item2) / 4;

            float xTranform = xCenterOfMass - originCoords.Item1;
            float yTranform = yCenterOfMass - originCoords.Item2;

            foreach (Tuple<float, float> currentCoord in plotCoords)
            {
                if (currentCoord.Item1 == -1)
                {
                    translatedCoords.Add(new Tuple<float, float>(currentCoord.Item1, currentCoord.Item2));
                }
                else if (currentCoord.Item1 == -2)
                {
                    translatedCoords.Add(new Tuple<float, float>(currentCoord.Item1, currentCoord.Item2));
                }
                else
                {
                    translatedCoords.Add(new Tuple<float, float>(currentCoord.Item1 - xTranform, currentCoord.Item2 - yTranform));
                }
            }

            return translatedCoords;
        }
    }
}
