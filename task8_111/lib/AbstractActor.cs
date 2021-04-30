using System;
using System.Timers;

namespace task8_11
{
    public abstract class AbstractActor
    {
        protected readonly Timer timer = new Timer();
        public string Name { get; }
        public event Action<string> ActorEvent;

        protected AbstractActor(string name, uint ms)
        {
            this.Name = name;
            this.timer.Interval = ms;
            this.timer.AutoReset = true;
            this.timer.Elapsed += (object sender, ElapsedEventArgs e) => this.Start();
            this.timer.Start();
        }

        protected abstract void Start();

        protected void RaiseEvent(string eventDesc)
        {
            ActorEvent?.Invoke(eventDesc);
        }
    }
}
