using System;
using System.ServiceProcess;


namespace SvcLoginTrackerClient
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer m_mainTimer;
        private int interval = 10 * 1000; //How often to run in milliseconds (seconds * 1000)

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //Create the Main timer
            m_mainTimer = new System.Timers.Timer
            {
                //Set the timer interval
                Interval = interval
            };

            //Dictate what to do when the event fires
            m_mainTimer.Elapsed += m_mainTimer_Elapsed;

            //Something to do with something, I forgot since it's been a while
            m_mainTimer.AutoReset = true;

#if DEBUG
#else
            m_mainTimer.Start(); //Start timer only in Release
#endif
            //Run 1st Tick Manually
            Routine();
        }

        public void OnDebug()
        {
            //Manually kick off the service when debugging
            OnStart(null);
        }

        protected override void OnStop()
        {
        }

        void m_mainTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Routine();
        }

        private void Routine()
        {
            Console.Beep();
        }
    }
}
