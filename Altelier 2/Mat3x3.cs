using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altelier_2
{
    class Mat3x3
    {
        private TableLayoutPanel Panel;
        private NumericUpDown[,] Values = new NumericUpDown[3, 3];
        public Mat3x3(TableLayoutPanel panel)
        {
            Panel = panel;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Values[i, j] = (NumericUpDown)Panel.GetControlFromPosition(i, j);
                }
            }
        }

        public void Init_Row(string st,int Row)
        {
            Random Sq = new Random((int)DateTime.Now.ToBinary());
            Random random = new Random((int)DateTime.Now.ToBinary());
           
            for (int i = 0; i < 3; i++)
            {
                int nWq = Sq.Next(10000);
                if (nWq < 8000)
                {
                    string Mini = st.Substring(i, 1);
                    if (Mini!="0")
                    {
                       Values[i, Row].Value = int.Parse(Mini);
                       Values[i, Row].Enabled = false;
                    }
                }
               
            }
        }
        public bool contains(NumericUpDown upDown, out int X,out int Y)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Values[i, j] == upDown)
                    {
                        X = i;
                        Y = j;
                        return true;
                    }
                }
            }
            X = -1;
            Y = -1;
            return false;
        }
        public NumericUpDown this[int x,int y]
        {
            get => Values[x, y];
        }
        public bool Check_Values()
        {
            List<int> vs = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Values[i, j].Value!=0)
                    {
                        vs.Add((int)Values[i, j].Value);
                    }
                }
            }
            foreach (int item in vs)
            {
                if (vs.Count(i => i == item) > 1) return false;
            }
            return true;
        }
        public bool check_Row(int Row,NumericUpDown Value)
        {
            for (int i = 0; i < 3; i++)
            {
                int va = (int)Values[Row, i].Value;
                if (va != 0)
                    if(Value!=Values[Row,i])
                    if (va == Value.Value) return false;
            }
            return true;
        }
        public bool check_Collom(int collom, NumericUpDown Value)
        {
            for (int i = 0; i < 3; i++)
            {
                int va = (int)Values[i, collom].Value;
                if (va != 0)
                    if (Value != Values[i, collom])
                        if (va == Value.Value) return false;
            }
            return true;
        }
        public bool check_filled()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Values[i, j].Value == 0) return false;
                }
            }
            return true;
        }
    }
}
