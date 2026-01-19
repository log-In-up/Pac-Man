using UnityEngine;

namespace Pacman
{
    public class PauseState : State<PauseView, PauseViewModel>, IGameState
    {
        private readonly GameInstance Owner;

        public PauseState(GameInstance Owner, PauseView View, PauseViewModel ViewModel) : base(View, ViewModel)
        {
            this.Owner = Owner;
        }

        public void Enter()
        {
            View.Initialize(ViewModel);
            ViewModel.Notify += OnPausePressedNotify;
            View.gameObject.SetActive(true);

            // To pause the game
            Time.timeScale = 0.0f;
        }

        public void Exit()
        {
            View.gameObject.SetActive(false);
            ViewModel.Notify -= OnPausePressedNotify;
            View.Deinitialize();

            // To resume the game
            Time.timeScale = 1.0f;
        }

        public void Update()
        {
        }

        private void OnPausePressedNotify()
        {
            Owner.SwitchState(GameStates.Game);
        }
    }
}