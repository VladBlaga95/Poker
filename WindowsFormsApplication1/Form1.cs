using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Opp()
        {
            for (int i = 0; i < 5; i++)
            {
                EngineApp.B[i].culoare = EngineApp.Pic[i + 5].culoare;
                EngineApp.B[i].valoare = EngineApp.Pic[i + 5].valoare;
                EngineApp.B[i].BackgroundImage = Properties.Resources.BackCard;
            }
        }
        public void Hands()
        { Hand(0, 5);
        Opp();

       
        }
        public void Hand(int k,int l)
        {
            for (int i = k; i < l; i++)
            {
                EngineApp.Pic[i].Parent = panel1;
                EngineApp.B[i].Parent = panel1;
            }
        }
        public void PicGenerate(List<Cards> Deck)
        {
                      for (int i = 0; i < 52; i++)
                      {
                
                EngineApp.Pic[i].valoare = Deck[i].valori;
                EngineApp.Pic[i].culoare = Deck[i].culori;
                
              
            }
           
        }
        
     public  void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            EngineApp.Generate_deck();
            EngineApp.CardPic(this);
            button2.Enabled = false;
            button1.Enabled = false;

         
        }
     

     private void pictureBox2_Click(object sender, EventArgs e)
     {

        
         EngineApp.shuffle(EngineApp.Pic);
         Hands();
         button2.Enabled = true;
         button1.Enabled = true;
        

     }

     private void button1_Click(object sender, EventArgs e)
     {
        
         for (int i = 0; i < 5; i++)
         {
           
             EngineApp.B[i].BackgroundImage =EngineApp.Pic[i+5].BackgroundImage;
           
            
         }
         int d = EngineApp.Verify(EngineApp.Pic);
         int z=EngineApp.Verify(EngineApp.B);
         if (d > z)
             MessageBox.Show("You win");
         else
             if (d < z)
                 MessageBox.Show("You lose ");
             else
                if(EngineApp.sumcarti(EngineApp.Pic)>EngineApp.sumcarti(EngineApp.B))
                    MessageBox.Show("You win");
                else
                    if(EngineApp.sumcarti(EngineApp.Pic)<EngineApp.sumcarti(EngineApp.B))
                        MessageBox.Show("You lose");
                    else
                            MessageBox.Show("Draw");
         
             
     }

     private void button2_Click(object sender, EventArgs e)
     {
         EngineApp.Ondraw(EngineApp.Pic);
         Hands();
         button2.Enabled = false;
     }
    

   
            
           
        
    }
}

