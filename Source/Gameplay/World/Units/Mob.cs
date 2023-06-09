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
    public class Mob : Unit
    {

        public Mob(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 4.0f;
        }

        public override void Update(Vector2 OFFSET, Player ENEMY)
        {
            AI(ENEMY.hero);

            base.Update(OFFSET);
        }

        public virtual void AI(Hero HERO)
        {
            pos += Globals.RadialMovement(HERO.pos, pos, speed);
            rot = Globals.RotateTowards(pos, HERO.pos);

            if(Globals.GetDistance(pos, HERO.pos) < 32.0f)
            {
                HERO.GetHit(1);
                is_alive = false;
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}

