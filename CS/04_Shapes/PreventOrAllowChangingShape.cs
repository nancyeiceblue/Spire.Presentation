using System;
using System.Drawing;
using System.Windows.Forms;
using Spire.Presentation;
using Spire.Presentation.Drawing;

namespace PreventOrAllowChangingShape
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //Create an instance of presentation document
            Presentation ppt = new Presentation();

            //Set background image
            string ImageFile = @"..\..\..\..\..\..\Data\bg.png";
            RectangleF rect = new RectangleF(0, 0, ppt.SlideSize.Size.Width, ppt.SlideSize.Size.Height);
            ppt.Slides[0].Shapes.AppendEmbedImage(ShapeType.Rectangle, ImageFile, rect);
            ppt.Slides[0].Shapes[0].Line.FillFormat.SolidFillColor.Color = Color.FloralWhite;

            //Add a rectangle shape to the slide
            IAutoShape shape = ppt.Slides[0].Shapes.AppendShape(ShapeType.Rectangle, new RectangleF(50, 100, 400, 150));

            //Set the shape format
            shape.Fill.FillType = FillFormatType.None;
            shape.ShapeStyle.LineColor.Color = Color.LightBlue;
            shape.TextFrame.Paragraphs[0].Alignment = TextAlignmentType.Justify;
            shape.TextFrame.Text = "Demo for locking shapes:\n    Green/Black stands for editable.\n    Grey stands for non-editable.";
            shape.TextFrame.Paragraphs[0].TextRanges[0].LatinFont = new TextFont("Arial Rounded MT Bold");
            shape.TextFrame.Paragraphs[0].TextRanges[0].Fill.FillType = FillFormatType.Solid;
            shape.TextFrame.Paragraphs[0].TextRanges[0].Fill.SolidColor.Color = Color.Black;

            //The changes of selection and rotation are allowed
            shape.Locking.RotationProtection = false;
            shape.Locking.SelectionProtection = false;
            //The changes of size, position, shape type, aspect ratio, text editing and ajust handles are not allowed 
            shape.Locking.ResizeProtection = true;
            shape.Locking.PositionProtection = true;
            shape.Locking.ShapeTypeProtection = true;
            shape.Locking.AspectRatioProtection = true;
            shape.Locking.TextEditingProtection = true;
            shape.Locking.AdjustHandlesProtection = true;

            //Save the document
            string result = "PreventOrAllowChangingShape.pptx";
            ppt.SaveToFile(result, FileFormat.Pptx2013);
            PresentationDocViewer(result);
		}
	
		private void PresentationDocViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }
    }
}