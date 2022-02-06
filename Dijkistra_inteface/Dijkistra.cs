using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkistra_inteface
{
    public partial class Dijkistra : Form
    {
        Gest_Ghraph gest;
        int dep=-1;
        int arr=-1;
        public Dijkistra()
        {
            InitializeComponent();
        }

        private void Set_Dep_Arr(object sender, EventArgs e)
        {
            CheckBox check = ((CheckBox)sender);
            
            if (!check.Checked)
            {
                int a = int.Parse(check.Text);
                if (arr == a)
                {
                    arr = -1;
                    End.Text = "";
                }else if (dep==a)
                {
                    dep = -1;
                    Start.Text = "";
                }
            }else if (dep!=-1 && arr!=-1)
            {
                check.Checked = false;
                return;
            }
            else if(dep == -1)
            {
                dep = int.Parse(check.Text);
                Start.Text = "Depart Node : " +dep;
            }else if (arr == -1)
            {
                arr = int.Parse(check.Text);
                End.Text = "End Node : " + arr;
                DoIT();
            }
        }
        private void DoIT()
        {
           gest= new Gest_Ghraph();
           gest.Add_Vertex(P1_2, 1, 2,(int) V1_2.Value);
           gest.Add_Vertex(P1_3, 1, 3,(int) V1_3.Value);
           gest.Add_Vertex(P1_4, 1, 4,(int) V1_4.Value);
           gest.Add_Vertex(P5_9, 5, 9,(int) V5_9.Value);
           gest.Add_Vertex(P2_5, 2, 5,(int) V2_5.Value);
           gest.Add_Vertex(P3_5, 3, 5,(int) V3_5.Value);
           gest.Add_Vertex(P5_8, 5, 8,(int) V5_8.Value);
           gest.Add_Vertex(P4_7, 4, 7,(int) V4_7.Value);
           gest.Add_Vertex(P4_6, 4, 6,(int) V4_6.Value);
           gest.Add_Vertex(P7_12, 7, 12,(int) V7_12.Value);
           gest.Add_Vertex(P12_14, 12, 14,(int) V12_14.Value);
           gest.Add_Vertex(P14_13, 14, 13,(int) V14_13.Value);
           gest.Add_Vertex(P6_13, 6, 13,(int) V6_13.Value);
           gest.do_Dijk(dep,arr);
        }
      
    }
}
