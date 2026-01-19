using UnityEngine;

namespace Pacman
{
    public class LooseState : State<LooseView, LooseViewModel>, IGameState
    {
        private readonly GameInstance Owner;

        public LooseState(GameInstance Owner, LooseView View, LooseViewModel ViewModel) : base(View, ViewModel)
        {
            this.Owner = Owner;
        }

        public void Enter()
        {
            View.Initialize(ViewModel);
            View.gameObject.SetActive(true);

            // To pause the game
            Time.timeScale = 0.0f;
        }

        public void Exit()
        {
            View.gameObject.SetActive(false);
            View.Deinitialize();

            // To resume the game
            Time.timeScale = 1.0f;
        }

        public void Update()
        {
        }
    }
}