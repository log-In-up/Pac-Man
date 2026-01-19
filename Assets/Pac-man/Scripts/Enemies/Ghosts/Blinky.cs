namespace Pacman
{
    public class Blinky : Ghost
    {
        private void Update()
        {
            Agent.SetDestination(Player.transform.position);
        }
    }
}