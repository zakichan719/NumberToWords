using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DemoNumberToWords
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
          //  List<Translation> results = new List<Translation>();
           // int[] values = Enumerable.Range(0, 10001).ToArray();
           // foreach (int v in values)
          //  {
                Translation t = new Translation();
                
                t.English = Converter.ConvertNumberToWords(92520.25, Language.English);
                t.French= Converter.ConvertNumberToWords(92520.25, Language.French);
                //results.Add(t);
            // }
            MessageBox.Show(t.French.ToString());
            //dataGridView1.DataSource = results;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class Translation
    {
        public int Value { get; set; }
        public string English { get; set; }
        public string French { get; set; }
    }

}
