using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInveder
{
    public abstract class Craft
    {
        //Fields
        protected Rectangle position;
        protected Bitmap image;
        protected Graphics buffergraphics;
        protected Point direction;
        protected Size boundary;
        protected Point Down;
        protected bool alive;

        //This will constructor, to initialize the field for creating the craft. 
        public Craft(Rectangle position, String filename, Graphics buffergraphics, Point direction, Size boundary, Point Down)
        {
            this.position = position;
            image = new Bitmap(filename);
            this.buffergraphics = buffergraphics;
            this.direction = direction;
            this.boundary = boundary;
            this.Down = Down;
            alive = true;
        }
        //This is the draw method, its use for to draw the mother ship, invader, missiles and bombs.
        public void Draw()
        {
            buffergraphics.DrawImage(image, position);
        }
        //This move method is use for to move the mother ship, invader, missiles and bombs around the form.
        public void Move()
        {
            position.Offset(direction);
        }
        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }
        public Point Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }
    }
}
