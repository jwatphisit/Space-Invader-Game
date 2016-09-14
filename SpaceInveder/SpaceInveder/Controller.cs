using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace SpaceInveder
{
    public class Controller
    {
        //Constants
        private const int INVADER_WIDTH = 5;
        private const int INVADER_HIGHT = 35;
        private const int MAX_INVADER_ROW = 4;
        private const int MAX_INVADER_COL = 10;
        private const int IMAGE_HIGHT = 25;
        private const int IMAGE_WIDTH = 25;
        private const int OFFSET = 50;
        private const int TOTALINVADER = 40;

        //Fields
        private MotherShip mothership;
        private Graphics buffergraphics;
        private Point direction;
        private Size boundary;
        private Point Down;
        private Random random;
        private bool mothershipdie;
        private bool noinverderleft;


        private List<Missiles> missiles;
        private List<Invader> invader; 
        private List<Bombs> bombs;

        //This will be a constructor to initialize for the fields for creating the controller.
        public Controller(Graphics buffergraphics)
        {
            this.buffergraphics = buffergraphics;
            this.direction = new Point(5,0);
            this.Down = new Point(0, 10);
            this.boundary = new Size(1105, 747);
            invader = new List<Invader>();
            missiles = new List<Missiles>();
            bombs = new List<Bombs>();
            random = new Random();

            mothership = new MotherShip(new Rectangle(400, 550, 50, 60), "Untitled-4.png", buffergraphics, direction, boundary, Down);

            for (int i = 0; i < MAX_INVADER_COL; i++)
            {
                for (int j = 0; j < MAX_INVADER_ROW; j++)
                {
                    invader.Add(new Invader(new Rectangle(new Point(INVADER_WIDTH + (i * OFFSET), INVADER_HIGHT + (j *OFFSET)), new Size(IMAGE_HIGHT, IMAGE_WIDTH)), "EnemyShip.bmp", buffergraphics, direction, boundary, Down, new Point(i, j)));
                }
                
            }
        }
        //This will using for to run all the method. 
        public void Run()
        {
            buffergraphics.Clear(Color.Black);
            mothership.Draw();

          foreach (Invader item in invader)
	      {
              item.Draw();
          }
        }
        //This is use for moving the mother ship.
        public void Move(int X)
        {
            mothership.Move(X);
        }
        //This is use for moving the invader from side to side.
        public void MoveInvader()
        {
            foreach (Invader item in invader)
            {
                int invaderLeft = item.Position.Left;
                    int invaderRight = item.Position.Right;

                    if ((invaderRight > boundary.Width) || (invaderLeft < 0))
                    {
                        MoveDownInvader();
                    }
            }

            foreach (Invader item in invader)
            {
                item.Move();
            }
        }
        //This is use for moving the invader down, once it hit the wall side of the form.
        public void MoveDownInvader()
        {
            foreach (Invader i in invader)
            {
                i.MoveDown();
                i.SwapDirection();
                i.Move();
            }
            
        }
        //This method is use for calling the missile. 
        public void Fire()
        {
            if (missiles.Count > 14)
            {
                missiles.RemoveAt(0);
            }
            Missiles missile = new Missiles(new Rectangle(mothership.Position.X, mothership.Position.Y, 10, 10),"missile.bmp",buffergraphics,new Point(0, -10),boundary, Down);
            missiles.Add(missile);
        }
        //This method is use for fire the missile and using the mother ship position.
        public void Missilefire()
        {
            foreach (Missiles item in missiles)
            {
                item.Move();
                item.Draw();
            }
        }
        //This method is use for when the missile hit the invader and make the invader disappear. 
        public void KillInvader()
        {
            for (int i = invader.Count -1 ; i >= 0; i--)
            {
                for (int j = missiles.Count - 1; j >= 0; j--)
                {
                    if (invader[i].Position.IntersectsWith(missiles[j].Position))
                    {
                        invader[i].Alive = false;
                        missiles[j].Alive = false;
                    }
                }
            }
            for (int i = invader.Count - 1; i >= 0; i--)
            {
               if (invader[i].Alive == false)
               {
                   invader.RemoveAt(i);
               }
               
            }
            for (int i = missiles.Count - 1; i >= 0; i--)
            {
                if(missiles[i].Alive == false)
                {
                    missiles.RemoveAt(i);
                }
            }
        }
        //This method is use for to drop the bombs from the invader.
        public void DropBombs(Invader invader)
        {
            Bombs bomb = new Bombs(new Rectangle(invader.Position.X, invader.Position.Y, 10, 10), "bomb.bmp", buffergraphics, new Point(0, 10), boundary, Down);
            bombs.Add(bomb);
        }
        //This method is use for firing the bombs from the invader.
        public void Bombsfire()
        {
            foreach (Bombs item in bombs)
            {
                item.Move();
                item.Draw();
            }
        }
        //This method is use for when the bombs have hit the mother ship and make the mother disappear.
        public void KillMothership()
        {
            mothershipdie = false;

            for (int i = 0; i < bombs.Count; i++)
            {
                if (bombs[i].Position.IntersectsWith(mothership.Position))
                {
                    mothershipdie = true;
                }
            }
            
        }
        //This method is use for to check, if the invader is in the front and make the invader to fire the bombs.
        public void Invaderfirebomb()
        {
            for (int i = 0; i < MAX_INVADER_COL; i++)
            {
                Invader bombdrop = null;

                foreach (Invader item in invader)
                {
                    if (item.InvaderFleet1.X == i)
                    {
                        if (bombdrop == null)
                        {
                            bombdrop = item;
                        }
                        else if (item.InvaderFleet1.Y > bombdrop.InvaderFleet1.Y)
                        {
                            bombdrop = item;
                        }
                    }
                }
                if (random.Next(100) == 99 && bombdrop != null)
                {
                    DropBombs(bombdrop);
                }
            }
        }
        //This method is use for to check how many invader have been kill by the mother ship.
        public int NumberOfInvader()
        {
            return TOTALINVADER - invader.Count;
        }
        //This method is use for to check if all of the invader have die.
        public void InverderAllDie()
        {
            noinverderleft = false;

            if (invader.Count == 0)
            {
                noinverderleft = true;
            }
        }
        public bool Mothershipdie
        {
            get { return mothershipdie; }
            set { mothershipdie = value; }
        }
        public bool Noinverderleft
        {
            get { return noinverderleft; }
            set { noinverderleft = value; }
        }
    }
}
