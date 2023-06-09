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

        public QuantityDisplayBar health_bar;

        public UI()
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial24");

            health_bar = new QuantityDisplayBar(new Vector2(204, 36), 2, Color.Red);
        }

        public void Update(World WORLD)
        {
            health_bar.Update(WORLD.user.hero.health, WORLD.user.hero.health_max);
        }

        public void Draw(World WORLD)
        {
            string temp_str = "Score: " + GameGlobals.score;
            Vector2 str_dims = font.MeasureString(temp_str);

            Globals.sprite_batch.DrawString(font, temp_str, new Vector2(Globals.screen_width/2 - str_dims.X/2, Globals.screen_height - 100), Color.Black);

            health_bar.Draw(new Vector2(20, Globals.screen_height - 60));
        
            if(!WORLD.user.hero.is_alive)
            {
                temp_str = "Press ENTER to Restart";
                str_dims = font.MeasureString(temp_str);
                
                Globals.sprite_batch.DrawString(font, temp_str, new Vector2(Globals.screen_width/2 - str_dims.X/2, Globals.screen_height / 2), Color.Black);
            }
        }

    }
}


