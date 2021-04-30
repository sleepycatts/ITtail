using System;
using System.Threading;

namespace task8_11
{
    public abstract class Entity : AbstractActor
    {
        protected long work = 0;
        private object owner;
        public int Progress { get { return (int)Math.Max(0, 100 - work); } }
        public event Action<object> ProgressEvent; 

        public Entity() : base("", 100) { }

        protected override void Start()
        {
            if (Interlocked.Read(ref this.work) != 0)
            {
                this.Work();
                this.ProgressEvent?.Invoke(owner);
            }
        }

        protected void Request(object owner)
        {
            this.owner = owner;
        }
        protected abstract void Work();
    }
}
