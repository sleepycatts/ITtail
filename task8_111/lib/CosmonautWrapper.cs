using System;
using System.Collections.Generic;
using System.Threading;

namespace task8_11
{
    public class CosmonautWrapper : Entity
    {
        private static readonly List<CosmonautWrapper> instances = new List<CosmonautWrapper>();
        private readonly ICosmonaut cosmonauts; 
        private readonly SemaphoreSlim sem;

        public CosmonautWrapper(ICosmonaut loader)
        {
            this.cosmonauts = loader;
            this.sem = new SemaphoreSlim(1);
            instances.Add(this);
        }

        public static CosmonautWrapper GetCosmonaut()
        {
            if (instances.Count == 0)
            {
                return null;
            }
            return instances[new Random().Next(0, instances.Count)];
        }

        protected override void Work()
        {
            this.timer.Stop();
            this.RaiseEvent("Вышел в открытый космос.");
            this.cosmonauts.GoToOpenCosmos();
            Interlocked.Add(ref this.work, -100);
            this.RaiseEvent("Летит в ракете.");
            this.timer.Start();
            this.sem.Release();
        }

        internal void RequestOpenCosmos(Rocket rocket)
        {
            this.sem.Wait();
            this.Request(rocket);
            Interlocked.Add(ref this.work, 100);
        }
    }
}
