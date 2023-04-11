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
        public Vector2 offset = Vector2.Zero;

        public Hero hero;
           
        public List<Projectile> projectiles = new List<Projectile>();

        public World()
        {
            hero = new Hero("2D\\Characters\\player_ship", new Vector2(300, 300), new Vector2(64, 64));

            GameGlobals.PassProjectile = AddProjectile;
        }

        public virtual void Update()
        {
            hero.Update();

            for(int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, null);

                if(!projectiles[i].is_alive)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(OFFSET);

            for(int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile)INFO);
        }
    }
}
