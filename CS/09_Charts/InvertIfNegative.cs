using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Spire.Presentation;
using Spire.Presentation.Charts;
using Spire.Presentation.Collections;
using Spire.Presentation.Drawing;

namespace InvertIfNegative
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void btnRun_Click(object sender, EventArgs e)
        { 
            //Create PPT document and load file
            Presentation ppt = new Presentation();
            ppt.LoadFromFile(@"..\..\..\..\..\..\Data\ColumnChart.pptx");

            //Get chart on the first slide
            IChart Chart = ppt.Slides[0].Shapes[0] as IChart;

            //Set invert if negative
            Chart.Series[0].InvertIfNegative = true;
            
            //Chart.Series[0].DataPoints[0].InvertIfNegative = true;

            String result = "InvertIfNegative_result.pptx";
            //Save the document
            ppt.SaveToFile(result, FileFormat.Pptx2010);

            //Launch the result file
            PPTDocViewer(result);

        }

        private void PPTDocViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }        
        }
    }
}