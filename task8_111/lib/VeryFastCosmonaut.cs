using System.Threading;

namespace task8_11
{
    public class VeryFastCosmonaut : ICosmonaut
    {
        public void GoToOpenCosmos()
        {
            Thread.Sleep(100);
        }
    }
}
