#region Includes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

#endregion

namespace MG_TopDownShooter
{
    public class Missile : Projectile
    {

        public Missile(Vector2 POS,Unit OWNER, Vector2 TARGET) 
            : base("2D\\Projectiles\\missile_projectile", POS, new Vector2(32, 32), OWNER, TARGET)
        {


        }

        public override void Update(Vector2 OFFSET, List<Unit> UNITS)
        {

            base.Update(OFFSET, UNITS);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}

