using System.Threading;

namespace Model.PetModule.Attribute
{

    public class LifeTimer
    {

        private static System.Threading.Timer _timer;

        public LifeTimer()
        {
            if (!(_timer is null)) _timer.Dispose();
            _timer=new Timer(Invoke,null,0,2000);
        }

        private void Invoke(object o)
        {
            TimePassed?.Invoke();

        }
        public delegate void TimeEvent();
        public static event TimeEvent TimePassed;
    }
}
