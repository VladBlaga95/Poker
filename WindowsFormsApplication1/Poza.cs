using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace WindowsFormsApplication1
{
    public class Poza:PictureBox
    {
       public int valoare;
       public string culoare;
       public bool IsSelected = true;
       
        public Poza(int valoare,string culoare):base()
       {
           this.valoare = valoare;
           this.culoare = culoare;
          this.Click+=Poza_Click;
       }

        private void Poza_Click(object sender, EventArgs e)
        {
            if (IsSelected)
            {
                this.BackColor = Color.Transparent;
                IsSelected = false;
                if (EngineApp.selectnr > 0)
                    EngineApp.selectnr--;
            }
            else
                if (!IsSelected&&EngineApp.selectnr<3)
                {
                    
                    this.BackColor = Color.Orange;
                    IsSelected = true;
                    if (EngineApp.selectnr < 3)
                        EngineApp.selectnr++;
                    
                }
               
        }
    }
}
