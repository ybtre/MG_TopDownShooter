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
    public class Unit : Basic2d
    {
        public bool is_alive;

        public float health, health_max;

        public float speed;

        public float hit_dist;


        public Unit(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            is_alive = true;

            health = 1;

            health_max = health;

            speed = 2.0f;

            hit_dist = 35.0f;
        }

        public virtual void Update(Vector2 OFFSET, Player ENEMY)
        {
            base.Update(OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

        public virtual void GetHit(float DAMAGE)
        {
            health -= DAMAGE;

            if(health <= 0)
            {
                is_alive = false;
            }
        }
    }
}

