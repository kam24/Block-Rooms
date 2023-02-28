public class PauseController
{
    public bool IsPaused { get; private set; }

    public PauseController()
    {
        IsPaused = false;
    }

    public void Continue()
    {
        IsPaused = false;
    }

    public void Pause()
    {
        IsPaused = true;
    }
}
