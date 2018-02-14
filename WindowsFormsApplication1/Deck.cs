using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public class Cards
    {
        public string culori;
        public int valori;
       public Cards(string culori,int valori)
        {
            this.culori = culori;
            this.valori = valori;
        }


        public override string ToString()
        {
            return (valori +" "+ culori).ToString();

        }
      
    }
}
