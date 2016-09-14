using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInveder
{
    public class Invader : Craft
    {
        //Fields
        private Point InvaderFleet;

        //This will constructor, to initialize the field for creating the invader.
        public Invader(Rectangle position, String filename, Graphics buffergraphics, Point direction, Size boundary, Point Down, Point InvaderFleet)
            :base(position, filename, buffergraphics, direction, boundary, Down)
        {
            this.InvaderFleet = InvaderFleet;
        }
        //This method to move down in the direction that have been set in the controller class.
        internal void MoveDown()
        {
            position.Offset(Down);
        }
        //This method for the invader to move to another direction, once it’s have been move down.
        internal void SwapDirection()
        {
            direction = new Point(direction.X * -1, direction.Y * -1);
        }
        public Point InvaderFleet1
        {
            get { return InvaderFleet; }
            set { InvaderFleet = value; }
        }
    }
}
