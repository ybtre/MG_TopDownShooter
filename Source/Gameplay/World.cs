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
        public int num_killed;

        public Vector2 offset = Vector2.Zero;

        public Hero hero;

        public UI ui;
           
        public List<Projectile> projectiles = new List<Projectile>();
        public List<Mob> mobs = new List<Mob>();
        public List<SpawnPoint> spawn_points = new List<SpawnPoint>();

        public World()
        {
            num_killed = 0;

            hero = new Hero("2D\\Characters\\player_ship", new Vector2(Globals.screen_width / 2, Globals.screen_height / 2), new Vector2(64, 64));

            GameGlobals.OnPassProjectile = AddProjectile;
            GameGlobals.OnPassMob = AddMob;
            GameGlobals.OnCheckScroll = CheckScroll;

            spawn_points.Add(new SpawnPoint("2D\\MISC\\spawn_grunts", new Vector2(100, Globals.screen_height - 100), new Vector2(32, 32)));

            spawn_points.Add(new SpawnPoint("2D\\MISC\\spawn_grunts", new Vector2(Globals.screen_width/2, 50), new Vector2(32, 32)));
            spawn_points[spawn_points.Count-1].spawn_timer.AddToTimer(500);

            spawn_points.Add(new SpawnPoint("2D\\MISC\\spawn_grunts", new Vector2(Globals.screen_width - 100, Globals.screen_height / 2), new Vector2(32, 32)));
            spawn_points[spawn_points.Count-1].spawn_timer.AddToTimer(1000);

            ui = new UI();
        }

        public virtual void Update()
        {
            hero.Update(offset);

            for(int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, mobs.ToList<Unit>());

                if(!projectiles[i].is_alive)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }

            for(int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Update(offset, hero);

                if(!mobs[i].is_alive)
                {
                    num_killed++;
                    mobs.RemoveAt(i);
                    i--;
                }
            }

            for(int i = 0; i < spawn_points.Count; i++)
            {
                spawn_points[i].Update(offset);
            }
            
            ui.Update(this);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(offset);
            
            for(int i = 0; i < spawn_points.Count; i++)
            {
                spawn_points[i].Draw(offset);
            }

            for(int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Draw(offset);
            }

            for(int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

            ui.Draw(this);
        }

        public virtual void AddMob(object INFO)
        {
            mobs.Add((Mob)INFO);
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
                offset = new Vector2(offset.X + hero.speed *1, offset.Y);
            }
            if(temp_pos.X > -offset.X + (Globals.screen_width * .6f))
            {
                offset = new Vector2(offset.X - hero.speed *1, offset.Y);
            }

            if(temp_pos.Y < -offset.Y + (Globals.screen_height * .4f))
            {
                offset = new Vector2(offset.X, offset.Y + hero.speed * 1);
            }
            if(temp_pos.Y > -offset.Y + (Globals.screen_height * .6f))
            {
                offset = new Vector2(offset.X, offset.Y - hero.speed * 1);
            }

        }
    }
}
