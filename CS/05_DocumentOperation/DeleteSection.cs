using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Spire.Presentation;
using Spire.Presentation.Drawing;

namespace DeleteSection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //Create a PPT document
            Presentation ppt = new Presentation();

            //Load the document from disk
            ppt.LoadFromFile(@"..\..\..\..\..\..\Data\AddSection.pptx");

            ////remove the specified section
            //ppt.SectionList.RemoveAt(3);
            //remove all sections
            ppt.SectionList.RemoveAll();

            //Save the document
            String result = "DeleteOneSelection.pptx";
            ppt.SaveToFile(result, Spire.Presentation.FileFormat.Pptx2013);
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