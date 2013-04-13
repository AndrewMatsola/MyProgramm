/*
 * Created by SharpDevelop.
 * User: stud
 * Date: 13.04.2013
 * Time: 10:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Crest
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        /// <summary>
        /// Массив с точками
        /// </summary>
		int [,]PointArea;

        /// <summary>
        /// Признак хода X или O
        /// </summary>
		bool next = true;

        /// <summary>
        /// Статистика ,выигрыш X ,выигрыш O,количество ничьих,все игры
        /// </summary>
		int win1 = 0;
        int win2 = 0;
        int drawgame = 0;
        int allgame = 0;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			PointArea=new int[3,3]{{0,0,0},{0,0,0},{0,0,0}};
		}


        public void ClearStats()
        {
            win1 = 0;
            win2 = 0;
            drawgame = 0;
            allgame = 0;

            label10.Text = allgame + " игр";
            label5.Text = win2 + " раз";
            label8.Text = drawgame + " раз";
            label6.Text = win1 + " раз";
        }
		
		public void Restart()
		{
            // Очистка массива
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PointArea[i,j] = 0;
                }
            }

           

            button1.Text = "";
            button1.Enabled = true;

            button2.Text = "";
            button2.Enabled = true;

            button3.Text = "";
            button3.Enabled = true;

            button4.Text = "";
            button4.Enabled = true;

            button5.Text = "";
            button5.Enabled = true;

            button6.Text = "";
            button6.Enabled = true;

            button7.Text = "";
            button7.Enabled = true;

            button8.Text = "";
            button8.Enabled = true;

            button9.Text = "";
            button9.Enabled = true;

            label10.Text = allgame + " игр";
            label5.Text = win2 + " раз";
            label8.Text = drawgame + " раз";
            label6.Text = win1 + " раз";
		}

  
        public void ClickButton(Button button) 
		{
			if(next) {
				button.Text="X";
				button.Enabled=false;
				next=false;
			} else {
				button.Text="0";
				button.Enabled=false;
				next=true;
			}
		}

       
		public bool CheckWin () 
		{
            // проверка на ничью
            if (PointArea[0, 0] > 0 && PointArea[0, 1] > 0 && PointArea[0, 2] > 0 &&
                PointArea[1, 0] > 0 && PointArea[1, 1] > 0 && PointArea[1, 2] > 0 &&
                PointArea[2, 0] > 0 && PointArea[2, 1] > 0 && PointArea[2, 2] > 0)
            {

                MessageBox.Show("Пользователи завершили игру ничьей");
                drawgame += 1;
                allgame += 1;

                Restart();
                return false;
            }
		
            // проверка на выигрыщ
			if(((PointArea[0,0]==PointArea[0,1] && PointArea[0,1]==PointArea[0,2])
			    && (PointArea[0,0]>0
			    &&  PointArea[0,1]>0
			    &&  PointArea[0,2]>0))
			   ||
			   ((PointArea[1,0]==PointArea[1,1] && PointArea[1,1]==PointArea[1,2])
			    && (PointArea[1,0]>0
			    &&  PointArea[1,1]>0
			    &&  PointArea[1,2]>0))
			   ||
			   ((PointArea[2,0]==PointArea[2,1] && PointArea[2,1]==PointArea[2,2])
			    && (PointArea[2,0]>0
			    &&  PointArea[2,1]>0
			    &&  PointArea[2,2]>0))
					
			   
			   ||
			   
			   ((PointArea[0,0]==PointArea[1,0] && PointArea[1,0]==PointArea[2,0])
			    && (PointArea[0,0]>0
			    &&  PointArea[1,0]>0
			    &&  PointArea[2,0]>0))
			   ||
			   ((PointArea[0,1]==PointArea[1,1] && PointArea[1,1]==PointArea[2,1])
			    && (PointArea[0,1]>0
			    &&  PointArea[1,1]>0
			    &&  PointArea[2,1]>0))
			   ||
			   ((PointArea[0,2]==PointArea[1,2] && PointArea[1,2]==PointArea[2,2])
				&& (PointArea[0,2]>0
			    &&  PointArea[1,2]>0
			    &&  PointArea[2,2]>0))
					
			   
			   ||
			   
			   ((PointArea[0,0]==PointArea[1,1] && PointArea[1,1]==PointArea[2,2])
			    && (PointArea[0,0]>0
			    &&  PointArea[1,1]>0
			    &&  PointArea[2,2]>0))
			   ||
			   ((PointArea[0,2]==PointArea[1,1] && PointArea[1,1]==PointArea[2,0]) 
				&& (PointArea[0,2]>0
			    &&  PointArea[1,1]>0
			    &&  PointArea[2,0]>0)))
			{
                if (next)
                {
                    MessageBox.Show("Выиграл пользователь играющий O");
                    win1 += 1;
                }
                else
                {
                    MessageBox.Show("Выиграл пользователь играющий X");
                    win2 += 1;
                }
                allgame += 1;
				Restart();
			}

            return true;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			ClickButton(button1);

			if(next) 
            {
				PointArea[0,0]=1;
			} 
            else 
            {
			    PointArea[0,0]=2;	
			}

			CheckWin();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			ClickButton(button2);

			if(next) 
            {
			    PointArea[0,1]=1;
			} 
            else 
            {
			    PointArea[0,1]=2;	
			}

			CheckWin();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			ClickButton(button3);

			if(next) 
            {
				PointArea[0,2]=1;
			} 
            else 
            {
				PointArea[0,2]=2;	
			}

			CheckWin();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			ClickButton(button4);

			if(next) 
            {
				PointArea[1,0]=1;
            } 
            else 
            {
				PointArea[1,0]=2;
			}

			CheckWin();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			ClickButton(button5);

			if(next) 
            {
				PointArea[1,1]=1;
            } 
            else 
            {
				PointArea[1,1]=2;
			}

			CheckWin();
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			ClickButton(button6);

			if(next) 
            {
				PointArea[1,2]=1;
			} 
            else 
            {
				PointArea[1,2]=2;
			}

			CheckWin();
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			ClickButton(button7);
			
            if(next) 
            {
				PointArea[2,0]=1;
			} 
            else 
            {
				PointArea[2,0]=2;
			}

			CheckWin();
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			ClickButton(button8);

			if(next) 
            {
				PointArea[2,1]=1;
			} else {
				PointArea[2,1]=2;
			}

			CheckWin();
		}
		
		void Button9Click(object sender, EventArgs e)
		{
			ClickButton(button9);

			if(next) 
            {
				PointArea[2,2]=1;
			} 
            else 
            {
				PointArea[2,2]=2;
			}

			CheckWin();
		}

        // Все игры
        private void label10_Click(object sender, EventArgs e)
        {
            label10.Text = allgame + " игр";
        }

        // Выигрыши X
        private void label5_Click(object sender, EventArgs e)
        {
            label5.Text = win1 + " раз";
        }

        // Ничьи
        private void label8_Click(object sender, EventArgs e)
        {
            label8.Text = drawgame + " раз";
        }

        // Выигрыши Y
        private void label6_Click(object sender, EventArgs e)
        {
            label6.Text = win2 + " раз";
        }


        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void ClearStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearStats();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 About = new AboutBox1();
            About.Show();
        }



	}
}
