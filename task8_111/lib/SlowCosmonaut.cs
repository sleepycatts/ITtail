using System.Threading;

namespace task8_11
{
    public class SlowCosmonaut : ICosmonaut
    {
        public void GoToOpenCosmos()
        {
            Thread.Sleep(5000);
        }
    }
}
