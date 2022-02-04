using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altelier_2
{
    class Soduko_Backend
    {
        private TableLayoutPanel Table;
        private Mat3x3[,] Values=new Mat3x3[3,3];

        public Soduko_Backend(TableLayoutPanel table)
        {
            Table = table;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
 
                    TableLayoutPanel tableLayout = (TableLayoutPanel)Table.GetControlFromPosition(i,j);
                    if (tableLayout != null)Values[i, j] = new Mat3x3(tableLayout);
                }
            }
        }
        public bool check_Error(NumericUpDown numeric)
        {
            Mat3x3 Var=determine_TableLay(numeric,out int X,out int Y);
            if (!Var.Check_Values())
            {
                DoBad(numeric);
                return false;
            }
            //cheking rows
            int se = X / 3;
            int Row = X % 3;
            for (int i = 0; i < 3; i++)
            {
                if(!Values[se, i].check_Row(Row, numeric))
                {
                    DoBad(numeric);
                    return false;
                }
            }
            //checking colloms
            int sa = Y / 3;
            int col = Y % 3;
            for (int i = 0; i < 3; i++)
            {
               if( !Values[i, sa].check_Collom(col, numeric))
               {
                    DoBad(numeric);
                    return false;
               }
            }
            DoGood(numeric);
            return true;
        }
        private void DoBad(NumericUpDown numeric)
        {
            numeric.BackColor = System.Drawing.Color.MediumVioletRed;
        }
        private void DoGood(NumericUpDown numeric)
        {
            numeric.BackColor = System.Drawing.Color.LightGreen;
        }
        private Mat3x3 determine_TableLay(NumericUpDown numericUp,out int X,out int Y)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if(Values[i, k].contains(numericUp,out X,out Y))
                    {
                        X = X + 3 * i;
                        Y = Y + 3 * k;
                        return Values[i, k];
                    }
                }
            }
            X = -1;
            Y = -1;
            return null;
        }
       
    }
}
