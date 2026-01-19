namespace Pacman
{
    public abstract class State<TView, TViewModel> where TView : class where TViewModel : class
    {
        protected TView View;
        protected TViewModel ViewModel;

        public State(TView View, TViewModel ViewModel)
        {
            this.View = View;
            this.ViewModel = ViewModel;
        }
    }
}