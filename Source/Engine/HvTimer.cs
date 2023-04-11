using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace MG_TopDownShooter
{
    public class HvTimer
    {
        public bool good_to_go;
        protected int mSec;
        protected TimeSpan timer = new TimeSpan();
        

        public HvTimer(int m)
        {
            good_to_go = false;
            mSec = m;
        }
        public HvTimer(int m, bool STARTLOADED)
        {
            good_to_go = STARTLOADED;
            mSec = m;
        }

        public int MSec
        {
            get { return mSec; }
            set { mSec = value; }
        }
        public int Timer
        {
            get { return (int)timer.TotalMilliseconds; }
        }

        

        public void UpdateTimer()
        {
            timer += Globals.delta_time.ElapsedGameTime;
        }

        public void UpdateTimer(float SPEED)
        {
            timer += TimeSpan.FromTicks((long)(Globals.delta_time.ElapsedGameTime.Ticks * SPEED));
        }

        public virtual void AddToTimer(int MSEC)
        {
            timer += TimeSpan.FromMilliseconds((long)(MSEC));
        }

        public bool Test()
        {
            if(timer.TotalMilliseconds >= mSec || good_to_go)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            timer = timer.Subtract(new TimeSpan(0, 0, mSec/60000, mSec/1000, mSec%1000));
            if(timer.TotalMilliseconds < 0)
            {
                timer = TimeSpan.Zero;
            }
            good_to_go = false;
        }

        public void Reset(int NEWTIMER)
        {
            timer = TimeSpan.Zero;
            MSec = NEWTIMER;
            good_to_go = false;
        }

        public void ResetToZero()
        {
            timer = TimeSpan.Zero;
            good_to_go = false;
        }

        public virtual XElement ReturnXML()
        {
            XElement xml= new XElement("Timer",
                                    new XElement("mSec", mSec),
                                    new XElement("timer", Timer));



            return xml;
        }

        public void SetTimer(TimeSpan TIME)
        {
            timer = TIME;
        }

        public virtual void SetTimer(int MSEC)
        {
            timer = TimeSpan.FromMilliseconds((long)(MSEC));
        }
    }
}

