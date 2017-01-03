/*
 * Criado por SharpDevelop.
 * Usuário: Valdelis
 * Data: 03/01/2017
 * Hora: 07:39
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EditorSimplesHTML
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			if (splitContainer1.Orientation == Orientation.Horizontal) {
				splitContainer1.Orientation = Orientation.Vertical;
			}else
			{
				splitContainer1.Orientation = Orientation.Horizontal;
			}
		}
		
		void RichTextBox1KeyUp(object sender, KeyEventArgs e)
		{
			webBrowser1.DocumentText = richTextBox1.Text;
			if(e.KeyValue == 190){
				Class1.AddColouredText(richTextBox1.Text,richTextBox1);
				
			}			
			
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			if (fontDialog1.ShowDialog() == DialogResult.OK)
        	{
            	//if (richTextBox1.SelectedText != "") Texto Selecionado
            	//{
					richTextBox1.Font = fontDialog1.Font;
            	//}
			}
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			// Create a SaveFileDialog to request a path and file name to save to.
   		SaveFileDialog saveFile1 = new SaveFileDialog();

   // Initialize the SaveFileDialog to specify the RTF extension for the file.
   		saveFile1.DefaultExt = "*.html";
   		saveFile1.Filter = "HTML Files|*.html";

   // Determine if the user selected a file name from the saveFileDialog.
  		if(saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
   		   saveFile1.FileName.Length > 0) 
   		{
      // Save the contents of the RichTextBox into the file.
     	 richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
  		 }
		}
		
		
		
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			OpenFileDialog openFile1 = new OpenFileDialog();

   			// Initialize the OpenFileDialog to look for RTF files.
   			openFile1.DefaultExt = "*.html";
   			openFile1.Filter = "HTML Files|*.html";

   			// Determine whether the user selected a file from the OpenFileDialog.
  			if(openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
      		openFile1.FileName.Length > 0) 
   			{
     		// Load the contents of the file into the RichTextBox.
     		richTextBox1.LoadFile(openFile1.FileName,RichTextBoxStreamType.PlainText);
     		webBrowser1.DocumentText = richTextBox1.Text;
     		Class1.AddColouredText(richTextBox1.Text,richTextBox1);
   			}
		}
		
		void RichTextBox1TextChanged(object sender, EventArgs e)
		{
			
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			
		}
		
		void RichTextBox1KeyPress(object sender, KeyPressEventArgs e)
		{
			//if (char.IsWhiteSpace(e.KeyChar)) {
			
			
		}
	}
}
