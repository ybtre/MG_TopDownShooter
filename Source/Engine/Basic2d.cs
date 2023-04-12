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

        private Rectangle dest_rect; 

        private Vector2 origin;
    
        public Basic2d(string PATH, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;

            sprite = Globals.content.Load<Texture2D>(PATH);

            dest_rect = new Rectangle(0,0,0,0);
            origin = new Vector2(sprite.Bounds.Width/2, sprite.Bounds.Height/2);
        }

        public virtual void Update(Vector2 OFFSET)
        {

        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if(sprite != null)
            {
                Update_Destination_Rectangle(OFFSET);

                Globals.sprite_batch.Draw(
                        texture: sprite,
                        destinationRectangle: dest_rect,
                        sourceRectangle: null,
                        color: Color.White,
                        rotation: rot,
                        origin: origin,
                        effects: new SpriteEffects(),
                        layerDepth: 0);
            }
        }

        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN)
        {
            if(sprite != null)
            {
                Update_Destination_Rectangle(OFFSET);
                Update_Origin(ORIGIN);

                Globals.sprite_batch.Draw(
                        texture: sprite,
                        destinationRectangle: dest_rect,
                        sourceRectangle: null,
                        color: Color.White,
                        rotation: rot,
                        origin: origin,
                        effects: new SpriteEffects(),
                        layerDepth: 0);
            }
        }

        private void Update_Destination_Rectangle(Vector2 OFFSET)
        {
            dest_rect.X = (int)(pos.X + OFFSET.X);
            dest_rect.Y = (int)(pos.Y + OFFSET.Y);
            dest_rect.Width = (int)dims.X;
            dest_rect.Height = (int)dims.Y;
        }

        private void Update_Origin(Vector2 ORIGIN)
        {
            origin = ORIGIN;
        }

    }
}
