#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

#endregion

namespace MG_TopDownShooter
{
    public class Hero : Basic2d
    {
        public Hero(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {

        }

        public override Update()
        {
            base.Update();
        }

        public override Draw()
        {
            base.Draw();
        }
    }
}
