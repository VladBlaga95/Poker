using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{   
    static public class EngineApp
    {
        static public Poza[] B = new Poza[5];
        static public Size sz = new Size(138, 193);
        static public Poza []Pic=new Poza [52];
        static public Random Rand=new Random();
        static public List<Cards> Deck = new List<Cards>();
        static public string[] culori = { "pica", "trefla", "inima", "romb" };
        static public int selectnr=0;


        public static void Generate_deck()
        {
            for (int i = 2; i < 15; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    EngineApp.Deck.Add(new Cards(EngineApp.culori[j], i));
                    

                }
            }
        }
        public static void Init()
        {
            for (int i = 0; i < Pic.Length; i++)
            {
                Pic[i] = new Poza(Deck[i].valori,Deck[i].culori);
                
                
            }
        }
        public static void shuffle(Poza[] P)
        {
            int x;
            int y;
            Poza Aux = new Poza(0, string.Empty);
            for (int i = 0; i < 100; i++)
            {
                x = Rand.Next(0, P.Length);
                y = Rand.Next(0, P.Length);

                Aux.valoare = P[x].valoare;
                Aux.culoare = P[x].culoare;
                Aux.BackgroundImage = P[x].BackgroundImage;
                P[x].valoare = P[y].valoare;
                P[x].culoare = P[y].culoare;
                P[x].BackgroundImage = P[y].BackgroundImage;
                P[y].valoare = Aux.valoare;
                P[y].culoare = Aux.culoare;
                P[y].BackgroundImage = Aux.BackgroundImage;
            }

            for (int i = 0; i < 5; i++)
            {
                P[i].IsSelected = false;
                P[i].BackColor = Color.Transparent;
            }
            selectnr = 0;
               

        }


        public static void Ondraw(Poza[] P)
        {
            int x;
            int y;
            Poza Aux = new Poza(0, string.Empty);

            for (int i = 0; i < 100; i++)
              {
                 x = Rand.Next(0, P.Length);
                 y = Rand.Next(0, P.Length);
                if (P[x].IsSelected && P[y].IsSelected)
                    {
                        Aux.valoare = P[x].valoare;
                        Aux.culoare = P[x].culoare;
                        Aux.BackgroundImage = P[x].BackgroundImage;
                        P[x].valoare = P[y].valoare;
                        P[x].culoare = P[y].culoare;
                        P[x].BackgroundImage = P[y].BackgroundImage;
                        P[y].valoare = Aux.valoare;
                        P[y].culoare = Aux.culoare;
                        P[y].BackgroundImage = Aux.BackgroundImage;
                    }

                }
               
           
        }

        public static void CardPic(Form1 form)
            {
                Init();
                for (int i = 0; i<Pic.Length; i++)
                {
                    Pic[i].Size = sz;
                    Pic[i].Location = new Point(form.pictureBox1.Width+150*i, form.pictureBox1.Height+400);
                    Pic[i].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("_" + (i + 1));
                    Pic[i].BackgroundImageLayout = ImageLayout.Stretch;
                      }
                for (int i = 0; i < 5; i++)
                {
                    EngineApp.B[i] = new Poza(EngineApp.Pic[i + 5].valoare, EngineApp.Pic[i + 5].culoare);
                    EngineApp.B[i].Size = EngineApp.sz;
                    EngineApp.B[i].BackgroundImage = Properties.Resources.BackCard;
                    EngineApp.B[i].BackgroundImageLayout = ImageLayout.Stretch;
                    EngineApp.B[i].Location = new Point(form.pictureBox1.Width + 150 * i, form.pictureBox1.Height - 160);
                    
                }
            }
        public static int Verify(Poza[] D)
        {
            int[] v = new int[15];
            int[] val=new int[5];
            int fl3 = 0, fl2 = 0;
            bool isculoare = true;
            bool iskinta=true;
            for (int i = 0; i < 15; i++)
            {
                v[i] = 0;
                
            }
            for (int i = 0; i <4; i++)
            {
                if (D[i].culoare != D[i + 1].culoare)
                    isculoare = false; 

            }
            for (int i = 0; i < 5; i++)
            {
                val[i]=D[i].valoare;
                for (int j = 2; j < 15; j++)
                    if (D[i].valoare == j)  
                        v[j]++;
            }
            int nr = 0;
            for (int i = 2; i < 15; i++)
                if (v[i] == 2)
                {
                    nr += 2;
                    fl2 = i;
                }
                  
                else
                    if (v[i] == 3)
                    {
                        nr = 3;
                        fl3 = i;
                    }
                     
                    else

                        if (v[i] == 4)
                            nr = 4;
            bool ok = true;
            do
            {
                ok = true;
                for (int i = 0; i < 4; i++)
                {
                    if (val[i] > val[i + 1])
                    {
                        int aux = val[i];
                        val[i] = val[i + 1];
                        val[i + 1] = aux;
                        ok = false;
                    }
                }
           }while(!ok);

            for (int i = 0; i < 4;i++)
            {
                if ((val[i + 1] - val[i]) != 1)
                    iskinta = false;
            }
            if (iskinta && isculoare)
                return 8;
            if (iskinta)
                return 7;

                if (isculoare)
                    return 6;
            if (fl3 != 0 && fl2 != 0 && fl3 != fl2)
                return 5;
            switch (nr)
            {
                case 1: return 1; 
                case 2: return 2;
                case 3: return 3;
                case 4: return 4;
                default: return 0;
            }

            
        }

        public static int sumcarti(Poza[] d)
        {
            int minecraftcuAVg = 0;
            for(int i=0;i<5;i++)
                minecraftcuAVg += d[i].valoare;
            return minecraftcuAVg;
        
        }

      
       
    }
}