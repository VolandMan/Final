using System.Threading;
//using System.Windows.;

namespace PrinceofPersia   // обратный отчет  времени в игре
{
    class Timer
    {
        public int Time = 20;
        public void ReduceTime()
        {
            while (true)
            {
                Time--;
                Thread.Sleep(1000);
            }
        }
    }
}
