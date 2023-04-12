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
    public class SpawnPoint : Basic2d
    {
        public bool is_alive;

        public float hit_dist;
    
        public HvTimer spawn_timer = new HvTimer(2200);

        public SpawnPoint(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            is_alive = true;

            hit_dist = 35.0f;
        }

        public override void Update(Vector2 OFFSET)
        {
            spawn_timer.UpdateTimer();
            if(spawn_timer.Test())
            {
                SpawnMob();

                spawn_timer.ResetToZero();
            }

            base.Update(OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

        public virtual void GetHit()
        {
            is_alive = false;
        }

        public virtual void SpawnMob()
        {
            GameGlobals.OnPassMob(new Grunt(pos));
        }
    }
}


