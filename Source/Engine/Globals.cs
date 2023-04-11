#region Includes

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;

#endregion

namespace MG_TopDownShooter
{
    public delegate void PassObject(object obj);
    public delegate object PassObjAndReturn(object obj);
    
    public class Globals
    {
        public static int screen_width = 1920;
        public static int screen_height = 1080;

        public static ContentManager content;
        public static SpriteBatch sprite_batch;

        public static HvKeyboard keyboard;
        public static HvMouseControl mouse;

        public static GameTime delta_time;

        public static float GetDistance(Vector2 pos, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));
        }

        public static float RotateTowards(Vector2 position, Vector2 target)
        {
            if(target.X == position.X && target.Y == position.Y)
            {
                return 0;
            }

            var direction = Vector2.Normalize(target - position);
            var angle = (float)Math.Acos(Vector2.Dot(direction, Vector2.UnitY));

            if(direction.X < 0)
            {
                return (float)Math.PI + angle;
            }
            else
            {
                return (float)Math.PI - angle;
            }
            
        }

    }
}
