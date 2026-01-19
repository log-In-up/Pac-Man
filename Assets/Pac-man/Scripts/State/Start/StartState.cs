using UnityEngine;

namespace Pacman
{
    public class StartState : IGameState
    {
        private readonly GameInstance Owner;

        public StartState(GameInstance Owner)
        {
            this.Owner = Owner;
        }

        public void Enter()
        {
            // To resume the game
            Time.timeScale = 1.0f;
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Owner.SwitchState(GameStates.Game);
        }
    }
}