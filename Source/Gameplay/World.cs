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
    public class World
    {
        PassObject OnResetWorld;

        public Vector2 offset = Vector2.Zero;

        public UI ui;

        public User user;
        public AIPlayer ai_player;
           
        public List<Projectile> projectiles = new List<Projectile>();

        public World(PassObject RESETWORLD)
        {
            OnResetWorld = RESETWORLD;

            GameGlobals.OnPassProjectile = AddProjectile;
            GameGlobals.OnPassMob = AddMob;
            GameGlobals.OnCheckScroll = CheckScroll;

            user = new User();
            ai_player = new AIPlayer();

            ui = new UI();
        }

        public virtual void Update()
        {
            if(user.hero.is_alive)
            {
                user.Update(ai_player, offset);
                
                ai_player.Update(user, offset);


                for(int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Update(offset, ai_player.units.ToList<Unit>());

                    if(!projectiles[i].is_alive)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                if(Globals.keyboard.GetPress("Enter"))
                {
                    OnResetWorld(null);
                }
            }

            ui.Update(this);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            user.Draw(offset);
            ai_player.Draw(offset);

            for(int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }


            ui.Draw(this);
        }

        public virtual void AddMob(object INFO)
        {
            ai_player.AddUnit((Mob)INFO);
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile)INFO);
        }

        public virtual void CheckScroll(object INFO)
        {
            Vector2 temp_pos = (Vector2)INFO;

            if(temp_pos.X < -offset.X + (Globals.screen_width * .4f))
            {
                offset = new Vector2(offset.X + user.hero.speed *1, offset.Y);
            }
            if(temp_pos.X > -offset.X + (Globals.screen_width * .6f))
            {
                offset = new Vector2(offset.X - user.hero.speed *1, offset.Y);
            }

            if(temp_pos.Y < -offset.Y + (Globals.screen_height * .4f))
            {
                offset = new Vector2(offset.X, offset.Y + user.hero.speed * 1);
            }
            if(temp_pos.Y > -offset.Y + (Globals.screen_height * .6f))
            {
                offset = new Vector2(offset.X, offset.Y - user.hero.speed * 1);
            }

        }
    }
}
