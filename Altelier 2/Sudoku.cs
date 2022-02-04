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
        public Sudoku()
        {
            InitializeComponent();
            soduko = new Soduko_Backend(MainTable);
            started = true;
        }

        private void Check_Changes(object sender, EventArgs e)
        {
            if(started)soduko.check_Error((NumericUpDown)sender);
        }

       
    }
}
