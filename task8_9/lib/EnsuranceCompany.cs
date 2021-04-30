using System.Threading;

namespace task8_11
{
    public class EnsuranceCompany : Entity
    {
        protected override void Work()
        {
            Interlocked.Add(ref this.work, -1);
        }

        internal void RequestPayment()
        {
            Interlocked.Add(ref this.work, 100);
        }
    }
}
