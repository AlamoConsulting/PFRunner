using System;
using System.Linq;
using System.Windows.Forms;
using RDotNet;

namespace MyApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            REngine.SetEnvironmentVariables();
            // There are several options to initialize the engine, but by default the following suffice:
            REngine engine = REngine.GetInstance();

            var group2 = engine.Evaluate("source('C:/Desarrollo/AlamoConsulting/PFRunner/R_Example/test.r')");
            var a = engine.GetSymbol("a").AsNumeric();
            var b = engine.GetSymbol("b").AsNumeric();
            messagesBox.Text = string.Format("Secuencia de Entrada: [{0}]", string.Join(", ", a));
            messagesBox.Text += Environment.NewLine + string.Format("Raíz cuadrada: [{0}]", string.Join(", ", b));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // you should always dispose of the REngine properly.
            // After disposing of the engine, you cannot reinitialize nor reuse it
            REngine engine = REngine.GetInstance();
            engine.Dispose();
        }
    }
}
