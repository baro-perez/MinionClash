using UnityEngine;

namespace AlvaroPerez.MinionClash.Main
{
    public abstract class GameModeController : MonoBehaviour
    {
        public bool IsRunning { get; protected set; }

        public void StartGame()
        {
            StartGameImpl();
            IsRunning = true;
        }

        public void Update()
        {
            if (IsRunning)
            {
                TickImpl(Time.deltaTime);
            }
        }

        protected abstract void StartGameImpl();
        protected abstract void TickImpl(float deltaTime);
    }
}