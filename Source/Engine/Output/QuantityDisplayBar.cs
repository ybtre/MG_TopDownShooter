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
    public class QuantityDisplayBar 
    {
        public int border;

        public Basic2d bar, bar_bg;

        public Color color;

        public QuantityDisplayBar(Vector2 DIMS, int BORDER, Color COLOR)
        {
            border = BORDER;
            color = COLOR;

            bar = new Basic2d("2D\\MISC\\solid", Vector2.Zero, new Vector2(DIMS.X - border * 2, DIMS.Y - border * 2));
            bar_bg  = new Basic2d("2D\\MISC\\shade", Vector2.Zero, new Vector2(DIMS.X, DIMS.Y));
        }

        public virtual void Update(float CURRENT, float MAX)
        {
            bar.dims = new Vector2(CURRENT / MAX * (bar_bg.dims.X - border * 2), bar.dims.Y);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            bar_bg.Draw(OFFSET, Vector2.Zero, Color.Black);
            bar.Draw(OFFSET + new Vector2(border, border), Vector2.Zero, color);
        }
    }
}


