using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike.GameCore
{
    public class GameLoop
    {
        private readonly Action<double> updateMethod;
        private readonly int targetFps;
        private readonly TimeSpan frameTime;
        private bool running;
        private DateTime lastFrameTime;

        public GameLoop(Action<double> updateMethod, int targetFps)
        {
            this.updateMethod = updateMethod;
            this.targetFps = targetFps;
            frameTime = TimeSpan.FromSeconds(1.0 / targetFps);
        }

        public void Start()
        {
            running = true;
            lastFrameTime = DateTime.Now;
            Run();
        }

        public void Stop()
        {
            running = false;
        }

        private void Run()
        {
            while (running)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan elapsedTime = currentTime - lastFrameTime;

                int remainingMilliseconds = (int)(frameTime.TotalMilliseconds - elapsedTime.TotalMilliseconds);

                if (remainingMilliseconds > 0)
                {
                    Thread.Sleep(remainingMilliseconds);
                }

                lastFrameTime = currentTime;

                double deltaTime = elapsedTime.TotalSeconds / frameTime.TotalSeconds;

                updateMethod(deltaTime);
            }
        }
    }
}
