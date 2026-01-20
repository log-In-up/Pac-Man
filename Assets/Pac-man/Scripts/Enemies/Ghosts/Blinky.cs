namespace Pacman
{
    public class Blinky : Ghost
    {
        private void Update()
        {
            if (Player == null)
            {
                return;
            }

            Agent.SetDestination(Player.transform.position);
        }
    }
}