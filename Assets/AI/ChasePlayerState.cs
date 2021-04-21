public class ChasePlayerState : IAiState
{
    bool active;

    public ChasePlayerState()
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
