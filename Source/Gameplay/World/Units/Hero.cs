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
    public class Hero : Unit
    {

        public Hero(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            health = 5;
            health_max = health;

            speed = 3.0f;
        }

        public override void Update(Vector2 OFFSET)
        {
            bool check_scroll = false;

            if(Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - speed,  pos.Y);
                check_scroll = true;
            } 
            
            if(Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + speed, pos.Y);
                check_scroll = true;
            }
            
            if(Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y - speed);
                check_scroll = true;
            }
            
            if(Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y + speed);
                check_scroll = true;
            }

            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - OFFSET);

            if(Globals.mouse.LeftClick())
            {
                GameGlobals.OnPassProjectile(new Missile(pos, this, Globals.mouse.newMousePos - OFFSET));
            }

            if(check_scroll)
            {
                GameGlobals.OnCheckScroll(pos);
            }

            base.Update(OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
