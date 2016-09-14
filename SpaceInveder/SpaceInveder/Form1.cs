/* Program name: 		SpaceInvader 
   Project file name:   SpaceInveder
   Author:			    Jay Watphisit
   Date:	            12 June 2015
   Language:		    C#
   Platform:		    Microsoft Visual Studio 2013.
   Purpose:		        This SpaceInvader game, the user need to move the mothership by using mouse and click the mouse to fire the missile.
   Description:		    The mothership will fire the missile to try to kill the invader, while the mothership diong that the invader is droping the bombs and try to kill the mothership.
   Known Bugs:		    No Bugs, as far as I know.
   Additional Features:  The Start screen before the game start, the music at the start page. the mothership firing the missile sound.
*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SpaceInveder
{
    public partial class Form1 : Form
    {
        //Fields
        private Bitmap bufferImage;
        private Controller controller;
        private Graphics graphics;
        private Graphics buffergraphics;
        private SoundPlayer player;
        private SoundPlayer player1;
        private Color backgroundcolor;

        //This will constructor, to initialize the field for creating the form.
        public Form1()
        {
            InitializeComponent();

            bufferImage = new Bitmap(Width, Height);
            buffergraphics = Graphics.FromImage(bufferImage);
            graphics = CreateGraphics();
            controller = new Controller(buffergraphics);
            player = new SoundPlayer();
            player1 = new SoundPlayer();
            player.SoundLocation = "Player One - Space Invaders _1980.wav";
            player1.SoundLocation = "shoot.wav";
            player.Play();
        }

        //Every tick of the time will refreshes the form, also its will run the controller class.
        private void timer1_Tick(object sender, EventArgs e)
        {

            buffergraphics.FillRectangle(Brushes.Crimson, 0, 0, Width, Height);
            controller.KillInvader();
            controller.Run();
            controller.MoveInvader();
            controller.Missilefire();
            controller.Invaderfirebomb();
            controller.Bombsfire();
            controller.KillMothership();
            controller.InverderAllDie();
            graphics.DrawImage(bufferImage, 0, 0);
            
            if (controller.Mothershipdie)
            {
                timer1.Enabled = false;
                MessageBox.Show ("Your Mothership got hit by the bombs");
                MessageBox.Show ("Game over");
            }
            
            label2.Text = controller.NumberOfInvader().ToString();
            if (controller.Noinverderleft)
            {
                timer1.Enabled = false;
                MessageBox.Show ("You have kill all of the Invader");
                MessageBox.Show ("You have won this game");
            }

        }

        //The mouse move is use for to move the mother ship from one side of the form to the other the side of the form.
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            controller.Move(e.X);
        }

        //This button is for exit the game.
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //This button is for start the game.
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            player.Stop();
            pictureBox1.Visible = false;

        }
        //The mouse click is use for to fire the missiles from the mother ship try to kill the invader. 
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            controller.Fire();
            player1.Play();
        }
        //This button is for pause the game.
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        //This menu strip is for click to start the game.
        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            pictureBox1.Visible = false;
        }
        //This menu strip is for click to pause the game.
        private void pauseGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        //This menu strip id for click to exit the game.
        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //This menu strip is for to change the background colour to blue.
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundcolor = System.Drawing.Color.Blue;
        }
        //This menu strip is for to change the background colour to red.
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundcolor = System.Drawing.Color.Red;
        }
        //This menu strip is for to change the background colour to black.
        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundcolor = System.Drawing.Color.Black;
        }
        //This menu strip is for to change the background colour to yellow.
        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundcolor = System.Drawing.Color.Yellow;
        }
        //This menu strip is for to change the background colour to green.
        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Green;
        }
        //This button is for restart the game.
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

    }
}
