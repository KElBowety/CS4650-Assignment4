public class ChaseObjectState : IAiState
{
    bool active;

    public ChaseObjectState()
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
