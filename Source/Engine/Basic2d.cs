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
    public class Basic2d
    {

        public Vector2 pos, dims;

        public float rot;

        public Texture2D sprite;
    
        public Basic2d(string PATH, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;

            sprite = Globals.content.Load<Texture2D>(PATH);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if(sprite != null)
            {
                Globals.sprite_batch.Draw(
                        texture: sprite,
                        destinationRectangle: new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y),
                        sourceRectangle: null,
                        color: Color.White,
                        rotation: rot,
                        origin: new Vector2(sprite.Bounds.Width/2, sprite.Bounds.Height/2),
                        effects: new SpriteEffects(),
                        layerDepth: 0);
            }
        }
        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN)
        {
            if(sprite != null)
            {
                Globals.sprite_batch.Draw(
                        texture: sprite,
                        destinationRectangle: new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y),
                        sourceRectangle: null,
                        color: Color.White,
                        rotation: rot,
                        origin: new Vector2(ORIGIN.X, ORIGIN.Y),
                        effects: new SpriteEffects(),
                        layerDepth: 0);
            }
        }
    }
}
