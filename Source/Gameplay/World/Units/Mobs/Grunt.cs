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
    public class Grunt : Mob
    {

        public Grunt(Vector2 POS) 
            : base("2D\\Units\\Mobs\\mob_grunt", POS, new Vector2(64, 64))
        {
            speed = 4.0f;
        }

        public override void Update(Vector2 OFFSET, Hero HERO)
        {

            base.Update(OFFSET, HERO);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}


