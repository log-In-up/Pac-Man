namespace Pacman
{
    public class Chasing : IState
    {
        private readonly Inky Owner;

        public Chasing(Inky Owner)
        {
            this.Owner = Owner;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Update()
        {
            Owner.Agent.SetDestination(Owner.Player.transform.position);

            if (!Owner.PlayerDetected())
            {
                Owner.SwitchState(States.Patrolling);
            }
        }
    }
}