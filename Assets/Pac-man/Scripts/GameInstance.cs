using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class GameInstance : MonoBehaviour
    {
        [SerializeField] private PointsView PointsView;
        [SerializeField] private GameView GameView;
        [SerializeField] private PauseView PauseView;
        [SerializeField] private LooseView LooseView;
        [SerializeField] private WinView WinView;
        [SerializeField] private GameObject Player;
        [SerializeField] private List<Ghost> Ghosts;
        [SerializeField] private List<GameObject> Points;

        private IGameState State;
        private Dictionary<GameStates, IGameState> StateMap;

        private PointsManager PointsManager;
        private GhostsManager GhostsManager;

        private void Awake()
        {
            PointsManager = new PointsManager(Points, PointsView, Player);
            GhostsManager = new GhostsManager(Player, Ghosts);

            InitializeGameState();

            PointsManager.Start();
            GhostsManager.Start();
        }

        private void Start()
        {
            SwitchState(GameStates.Start);
        }

        private void Update()
        {
            State.Update();
        }

        private void OnDisable()
        {
            PointsManager.Stop();
            GhostsManager.Stop();
        }

        private void InitializeGameState()
        {
            GameViewModel GameViewModel = new GameViewModel(new GameModel());
            PauseViewModel PauseViewModel = new PauseViewModel(new PauseModel());
            LooseViewModel LooseViewModel = new LooseViewModel(new LooseModel());
            WinViewModel WinViewModel = new WinViewModel(new WinModel());

            StateMap = new Dictionary<GameStates, IGameState>
            {
                { GameStates.Start, new StartState(this) },
                { GameStates.Game, new GameState(this, GameView, GameViewModel, PointsManager, GhostsManager) },
                { GameStates.Pause, new PauseState(this, PauseView, PauseViewModel) },
                { GameStates.Loose, new LooseState(this, LooseView, LooseViewModel) },
                { GameStates.Win, new WinState(this, WinView, WinViewModel) }
            };
        }

        public void SwitchState(GameStates state)
        {
            State?.Exit();

            State = StateMap[state];
            State.Enter();
        }
    }
}