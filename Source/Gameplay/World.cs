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
        public Hero hero;
           

        public World()
        {
            hero = new Hero("2D\\Characters\\green_character", new Vector2(300, 300), new Vector2(64, 64)); 
        }

        public virtual void Update()
        {
            hero.Update();
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(OFFSET);
        }
    }
}
