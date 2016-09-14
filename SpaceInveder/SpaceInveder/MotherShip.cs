using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInveder
{
    public class MotherShip : Craft
    {
        //This will constructor, to initialize the field for creating the mother ship.
        public MotherShip(Rectangle position, String filename, Graphics buffergraphics, Point direction, Size boundary, Point Down)
            :base (position, filename, buffergraphics, direction, boundary, Down)
        {
        }
        //This method is use for moving the mother ship in the x direction. 
        public void Move(int X)
        {
            position.X = X;
        }
    }
}
