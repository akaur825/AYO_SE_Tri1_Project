public struct PlayerStateChanged
{
    // THIS NEEDS TO BE FIXED TO ACCOUNT FOR ALL STATES CHANGING
    public SpeedyPlayerSpeedState State;

    public PlayerStateChanged(SpeedyPlayerSpeedState state)
    {
        State = state;
    }
}