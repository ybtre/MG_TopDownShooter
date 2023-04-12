#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

#endregion

namespace MG_TopDownShooter
{
    public class Projectile : Basic2d
    {
        public bool is_alive;

        public float speed;

        public Vector2 dir;

        public Unit owner;

        public HvTimer timer;

        public Projectile(string PATH, Vector2 POS, Vector2 DIMS, Unit OWNER, Vector2 TARGET) : base(PATH, POS, DIMS)
        {
            is_alive = true;

            speed = 5.0f;

            owner = OWNER;

            dir = TARGET - owner.pos;
            dir.Normalize();

            rot = Globals.RotateTowards(pos, TARGET);

            timer = new HvTimer(1200); //1.2s
        }

        public virtual void Update(Vector2 OFFSET, List<Unit> UNITS)
        {
            pos += dir * speed;

            timer.UpdateTimer();
            // timer.Test() returns false while running and true when stopped
            if (timer.Test())
            {
                is_alive = false;
            }
            else
            {
                is_alive = true;
            }

            if (HitSomething(UNITS))
            {
                is_alive = false;
            }
        }

        public virtual bool HitSomething(List<Unit> UNITS)
        {
            for (int i = 0; i < UNITS.Count; i++)
            {
                if (Globals.GetDistance(pos, UNITS[i].pos) < UNITS[i].hit_dist)
                {
                    UNITS[i].GetHit();
                    // we have a hit
                    return true;
                }
            }

            return false;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}