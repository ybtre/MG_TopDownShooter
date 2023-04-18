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
    public class Gameplay
    {

        int play_state;

        World world;

        public Gameplay()
        {
            play_state = 0;
        
            ResetWorld(null);
        }

        public virtual void Update()
        {
            if(play_state == 0)
            {
                world.Update();
            }

        }

        public virtual void Draw()
        {
            if(play_state == 0)
            {
                world.Draw(Vector2.Zero);
            }

        }

        public virtual void ResetWorld(object INFO)
        {
            world = new World(ResetWorld);

        }
    }
}
