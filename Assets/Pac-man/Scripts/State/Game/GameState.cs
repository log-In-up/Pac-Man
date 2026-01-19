namespace Pacman
{
    public class GameState : State<GameView, GameViewModel>, IGameState
    {
        private readonly GameInstance Owner;
        private readonly PointsManager PointsManager;
        private readonly GhostsManager GhostsManager;

        public GameState(GameInstance Owner, GameView View, GameViewModel ViewModel, PointsManager PointsManager, GhostsManager GhostsManager) : base(View, ViewModel)
        {
            this.Owner = Owner;
            this.PointsManager = PointsManager;
            this.GhostsManager = GhostsManager;
        }

        public void Enter()
        {
            View.Initialize(ViewModel);
            ViewModel.Notify += OnPausePressedNotify;
            PointsManager.AllCollectablesTaken += OnAllCollectablesTaken;
            GhostsManager.PlayerTouchNotify += OnGhostPlayerTouch;
            View.gameObject.SetActive(true);
        }

        public void Exit()
        {
            View.gameObject.SetActive(false);
            GhostsManager.PlayerTouchNotify -= OnGhostPlayerTouch;
            ViewModel.Notify -= OnPausePressedNotify;
            PointsManager.AllCollectablesTaken -= OnAllCollectablesTaken;
            View.Deinitialize();
        }

        public void Update()
        {
        }

        private void OnGhostPlayerTouch()
        {
            Owner.SwitchState(GameStates.Loose);
        }

        private void OnAllCollectablesTaken()
        {
            Owner.SwitchState(GameStates.Win);
        }

        private void OnPausePressedNotify()
        {
            Owner.SwitchState(GameStates.Pause);
        }
    }
}