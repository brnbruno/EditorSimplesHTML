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
using System.Text.RegularExpressions;
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
     		
   			}
		}
	
			
		
		
		void Button1Click(object sender, EventArgs e)
		{
			
		}
		
		void RichTextBox1KeyPress(object sender, KeyPressEventArgs e)
		{
			webBrowser1.DocumentText = richTextBox1.Text;
			
		}
		public Regex Brackets = new Regex("<|>");
		
		
		void RichTextBox1TextChanged(object sender, EventArgs e)
		{
		  
			int SelectionPostion = richTextBox1.SelectionStart;
			richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;
			 richTextBox1.SelectionStart = SelectionPostion;
			//Estrutura
			string Estrutura = @"(<html|</html>|<head|</head>|<body|</body>|<div|</div>|<span|</span>)";
            MatchCollection EstruturaMatches = Regex.Matches(richTextBox1.Text, Estrutura);
			
            // getting types/classes from the text 
            string types = @"(<p|</p>|<h1|</h1>|<h2|</h2>|<h3|</h3>|<h4|</h4>|<h5|</h5>|<h6|</h6>|strong|/strong|em|/em|abbr|/abbr|acronym|/acronym|addres|/addres|bdo|/bdo|blockquote|/blockquote|cite|/cite|q|/q|code|/code|ins|/ins|del|/del|dnf|/dnf|kbd|/kbd|pre|/pre|samp|/samp|var|/var|br|/br)";
            MatchCollection typeMatches = Regex.Matches(richTextBox1.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\<\!\-\-.+?\-\-\>)";   
            MatchCollection commentMatches = Regex.Matches(richTextBox1.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(richTextBox1.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = richTextBox1.SelectionStart;
            int originalLength = richTextBox1.SelectionLength;
            Color originalColor = Color.Black;

            // MANDATORY - focuses a label before highlighting (avoids blinking)
            //titleLabel.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionColor = originalColor;

            // scanning...
            foreach (Match m in EstruturaMatches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Blue;
            }

            foreach (Match m in typeMatches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in commentMatches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.Brown;
            }
             foreach (Match keyWordMatch in Brackets.Matches(richTextBox1.Text)) 
                {
                    if (richTextBox1.Text.Contains(keyWordMatch.ToString()))
                    {
                        richTextBox1.Select(keyWordMatch.Index, keyWordMatch.Length);
                        richTextBox1.SelectionColor = ColorTranslator.FromHtml("#27ae60");
                        richTextBox1.SelectionStart = SelectionPostion;
                        richTextBox1.SelectionLength = 0;
                        richTextBox1.SelectionColor = Color.Black;
                    }
                }

            // restoring the original colors, for further writing
            richTextBox1.SelectionStart = originalIndex;
            richTextBox1.SelectionLength = originalLength;
            richTextBox1.SelectionColor = originalColor;
           
            // giving back the focus
            richTextBox1.Focus();
        
		}
	}
}

