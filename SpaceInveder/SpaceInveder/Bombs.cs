using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInveder
{
    public class Bombs: Projectile
    {
        //This will constructor, to initialize the field for creating the bombs.
       public Bombs(Rectangle position, String filename, Graphics buffergraphics, Point direction, Size boundary, Point Down)
            : base(position, filename, buffergraphics, direction, boundary, Down)
            {
            }
    }
}
