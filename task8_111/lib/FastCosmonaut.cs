using System.Threading;

namespace task8_11
{
    public class FastCosmonaut : ICosmonaut
    {
        public void GoToOpenCosmos()
        {
            Thread.Sleep(1000);
        }
    }
}
