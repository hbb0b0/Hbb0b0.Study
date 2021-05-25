using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTaskCancelSample
{
    public partial class CalcWinform : Form
    {
        CancellationTokenSource m_cts = new CancellationTokenSource();
        public CalcWinform()
        {
            InitializeComponent();
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            int number = 0;
             long result = 0;
            /*
            if( int.TryParse( tbNumber.Text.Trim(),out number))
            {
               result =    await CalculatorFibnacci.FibAsync(number);

                MessageBox.Show($"Number:{number} Result:{result}");
            }
            */
          
            if (int.TryParse(tbNumber.Text.Trim(), out number))
            {
                try
                {
                    result = await CalculatorFibnacciWithMem.FibAsync(number, m_cts.Token);

                    MessageBox.Show($"Number:{number} Result:{result}");

                    CalculatorFibnacciWithMem.Dump();
                }
                catch (Exception)
                {

                    throw;
                }
              
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_cts.Cancel();
        }
    }
}
