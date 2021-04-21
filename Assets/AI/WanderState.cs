public class WanderState : IAiState
{
    bool active;

    public WanderState()
    {
        active = false;
    }

    public void EnterState()
    {
        active = true;
    }

    public void ExitState()
    {
        active = false;
    }

    public bool IsActive()
    {
        return active;
    }
}
