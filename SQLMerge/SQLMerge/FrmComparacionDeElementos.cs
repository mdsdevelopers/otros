using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DiffMatchPatch;

namespace SQLMerge
{
    public partial class FrmComparacionDeElementos : Form
    {
        
        public struct Chunk
        {
            public int startpos;
            public int length;
            public Color BackColor;
        }

        diff_match_patch DIFF = new diff_match_patch();
        // these are the diffs
        List<Diff> diffs;

        // chunks for formatting the two RTBs:
        List<Chunk> chunklist1;
        List<Chunk> chunklist2;

        // two color lists:
        Color[] colors1 = new Color[3] { Color.LightGreen, Color.LightSalmon, Color.White, };
        Color[] colors2 = new Color[3] { Color.LightSalmon, Color.LightGreen, Color.White };





        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.ToUpper().IndexOf(search.ToUpper());
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }





        public void MostrarElementos(string elemento1, string elemento2)
        {
            textBox1.ShortcutsEnabled = true;
            textBox2.ShortcutsEnabled = true;

            string first1 = new string(elemento1.TakeWhile(c => c != '\n').ToArray());


            if (elemento1.ToUpper().Contains("CREATE TABLE"))
            {
                textBox1.Text = elemento1;
            }
            else
            {
                string texto1 = ReplaceFirst(elemento1, "CREATE", "ALTER");
                textBox1.Text = texto1;
             
            }

            if (elemento2.ToUpper().Contains("CREATE TABLE"))
            {
                textBox2.Text = elemento2;
            }
            else
            {
                string texto2 = ReplaceFirst(elemento2, "CREATE", "ALTER");
                textBox2.Text = texto2;

            }

         
            //string texto2 = ReplaceFirst(elemento2, "CREATE", "ALTER");
            //textBox2.Text = texto2;
          
            lbl_longitud_elemento_1.Text = elemento1.Length.ToString();
          
            lbl_longitud_elemento_2.Text = elemento2.Length.ToString();

           

        }


        public void BuscarDiferencias()
        {
            diffs = DIFF.diff_main(textBox1.Text, textBox2.Text);
            DIFF.diff_cleanupSemanticLossless(diffs);      // <--- see note !

            chunklist1 = collectChunks(textBox1);
            chunklist2 = collectChunks(textBox2);

            paintChunks(textBox1, chunklist1);
            paintChunks(textBox2, chunklist2);

            textBox1.SelectionLength = 0;
            textBox2.SelectionLength = 0;

         }



        List<Chunk> collectChunks(RichTextBox RTB)
        {
            RTB.Text = "";
            List<Chunk> chunkList = new List<Chunk>();
            foreach (Diff d in diffs)
            {
                if (RTB == textBox2 && d.operation == Operation.DELETE) continue;  // **
                if (RTB == textBox1 && d.operation == Operation.INSERT) continue;  // **

                Chunk ch = new Chunk();
                int length = RTB.TextLength;
                RTB.AppendText(d.text);
                ch.startpos = length;
                ch.length = d.text.Length;
                ch.BackColor = RTB == textBox1 ? colors1[(int)d.operation] : colors2[(int)d.operation];
                chunkList.Add(ch);
            }
            return chunkList;

        }

        void paintChunks(RichTextBox RTB, List<Chunk> theChunks)
        {
            foreach (Chunk ch in theChunks)
            {
                RTB.Select(ch.startpos, ch.length);
                RTB.SelectionBackColor = ch.BackColor;
            }

        }




        public FrmComparacionDeElementos()
        {
            InitializeComponent();
         
        }

        private void FrmComparacionDeElementos_Load(object sender, EventArgs e)
        {
            BuscarDiferencias();
        }

      

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
                textBox1.SelectAll();

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
                textBox2.SelectAll();
        }
        



    }
}
