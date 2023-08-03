public abstract class StateController
{
    public AIStateMachine aiStateMachine;
    public Enemy enemy;
    
    public abstract void EnterState();
    public abstract void PerformState();
    public abstract void ExitState();
}
