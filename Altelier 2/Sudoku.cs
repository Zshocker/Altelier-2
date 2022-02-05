using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altelier_2
{
    public partial class Sudoku : Form
    {
        Soduko_Backend soduko;
        bool started = false;
        List<NumericUpDown> Errors = new List<NumericUpDown>();
        public Sudoku()
        {
           
            InitializeComponent();
            soduko = new Soduko_Backend(MainTable);
            started = true;
        }

        private void Check_Changes(object sender, EventArgs e)
        {
            if (started) { 
                bool s=soduko.check_Error((NumericUpDown)sender);
                if (s)
                {
                    Errors.Remove((NumericUpDown)sender);
                    if (Errors.Count == 0)
                    {
                        if (soduko.check_Filled())
                        {
                            MessageBox.Show("You Won!");
                            soduko = new Soduko_Backend(MainTable);
                        }
                    }
                }
                else
                {
                    if(!Errors.Contains((NumericUpDown)sender))
                    Errors.Add((NumericUpDown)sender);
                }
            }
        }

       
    }
}
