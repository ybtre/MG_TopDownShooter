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
    public class Player
    {

        public Hero hero;
        public List<Unit> units = new List<Unit>();
        public List<SpawnPoint> spawn_points = new List<SpawnPoint>();

        public Player()
        {
        }

        public virtual void Update(Player ENEMY, Vector2 OFFSET)
        {
            if(hero != null)
            {
                hero.Update(OFFSET);
            }

            for(int i = 0; i < units.Count; i++)
            {
                units[i].Update(OFFSET, ENEMY);

                if(!units[i].is_alive)
                {
                    ChangeScore(1);
                    units.RemoveAt(i);
                    i--;
                }
            }

            for(int i = 0; i < spawn_points.Count; i++)
            {
                spawn_points[i].Update(OFFSET);
            }


        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if(hero != null)
            {
                hero.Draw(OFFSET);
            }

            for(int i = 0; i < units.Count; i++)
            {
                units[i].Draw(OFFSET);
            }

            for(int i = 0; i < spawn_points.Count; i++)
            {
                spawn_points[i].Draw(OFFSET);
            }


        }

        public virtual void AddUnit(object INFO)
        {
            units.Add((Unit)INFO);
        }

        public virtual void ChangeScore(int SCORE)
        {

        }
    }
}
