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
    public class UI
    {   
        public SpriteFont font;

        public UI()
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial24");
        }

        public void Update(World WORLD)
        {

        }

        public void Draw(World WORLD)
        {
            string temp_str = "Num Killed: " + WORLD.num_killed;
            Vector2 str_dims = font.MeasureString(temp_str);

            Globals.sprite_batch.DrawString(font, temp_str, new Vector2(Globals.screen_width/2 - str_dims.X/2, Globals.screen_height - 100), Color.Black);
        }

    }
}


