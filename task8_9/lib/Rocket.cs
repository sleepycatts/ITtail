using System;

namespace task8_11
{
    public class Rocket : AbstractActor
    {
        private static readonly Random random = new Random();
        private bool running = true;
        private readonly EnsuranceCompany insurance;

        public Rocket(string rocketName) : base(rocketName, 100)
        {
            this.insurance = new EnsuranceCompany();
            this.insurance.ProgressEvent += (owner) => {
                this.RaiseEvent($"Произошла авария. Космонавты чинят ракету, страховая выплачивает компенсацию.");
                if (insurance.Progress == 100)
                {
                    this.running = true;
                }
            };
        }

        protected override void Start()
        {
            if (!this.running)
            {
                return;
            }

            var roll = random.NextDouble();
            if (roll < 0.0019d)
            {
                this.running = false;
                if (roll < 0.00094d)
                {
                    var cosmonauts = CosmonautWrapper.GetCosmonaut();
                    this.RaiseEvent($"Космонавты выходят в открытый космос...");
                    cosmonauts.ProgressEvent += (owner) =>
                    {
                        if (owner == this)
                        {
                            this.running = true;
                        }
                    };
                    cosmonauts.RequestOpenCosmos(this);
                } else
                {
                    insurance.RequestPayment();
                }
            }

            if (this.running)
            {
                this.RaiseEvent("Летит...");
                return;
            }
        }
    }
}
