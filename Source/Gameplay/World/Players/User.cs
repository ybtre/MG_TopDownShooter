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
    public class User : Player 
    {
        public User() : base()
        {
            hero = new Hero("2D\\Characters\\player_ship", new Vector2(Globals.screen_width / 2, Globals.screen_height / 2), new Vector2(64, 64));
        }

        public override void Update(Player ENEMY, Vector2 OFFSET)
        {
            base.Update(ENEMY, OFFSET);
        }
    }
}
