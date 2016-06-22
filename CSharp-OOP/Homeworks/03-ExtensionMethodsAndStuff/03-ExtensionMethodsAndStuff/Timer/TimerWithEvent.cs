namespace _03_ExtensionMethodsAndStuff.Timer
{
    using System;
    using System.Threading;
    public class TimerWithEvent
    {
        public event EventHandler<EventArgs> Tick;

        public void SetInterval(int t)
        {
            while ( true )
            {
                Thread.Sleep(t * 1000);
                OnTick(EventArgs.Empty);
            }
        }

        protected virtual void OnTick(EventArgs e)
        {
            EventHandler<EventArgs> handler = Tick;
            if ( handler != null )
            {
                handler(this, e);
            }
        }
    }
}
