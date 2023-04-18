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
    public class AIPlayer : Player 
    {
        public AIPlayer() : base()
        {
            spawn_points.Add(new SpawnPoint("2D\\MISC\\spawn_grunts", new Vector2(100, Globals.screen_height - 100), new Vector2(32, 32)));

            spawn_points.Add(new SpawnPoint("2D\\MISC\\spawn_grunts", new Vector2(Globals.screen_width/2, 50), new Vector2(32, 32)));
            spawn_points[spawn_points.Count-1].spawn_timer.AddToTimer(500);

            spawn_points.Add(new SpawnPoint("2D\\MISC\\spawn_grunts", new Vector2(Globals.screen_width - 100, Globals.screen_height / 2), new Vector2(32, 32)));
            spawn_points[spawn_points.Count-1].spawn_timer.AddToTimer(1000);

        }

        public override void Update(Player ENEMY, Vector2 OFFSET)
        {
            base.Update(ENEMY, OFFSET);

        }

        public override void ChangeScore(int SCORE)
        {
            GameGlobals.score += SCORE;
        }
    }
}
