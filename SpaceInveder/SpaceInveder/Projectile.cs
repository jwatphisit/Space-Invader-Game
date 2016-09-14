using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInveder
{
    public abstract class Projectile : Craft
    {
        //This will constructor, to initialize the field for creating the projectile.
        public Projectile(Rectangle position, String filename, Graphics buffergraphics, Point direction, Size boundary, Point Down)
            :base(position, filename, buffergraphics, direction, boundary, Down)
        {
        }



    }
}
