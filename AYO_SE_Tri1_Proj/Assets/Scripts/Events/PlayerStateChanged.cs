public struct PlayerStateChanged
{
    // THIS NEEDS TO BE FIXED TO ACCOUNT FOR ALL STATES CHANGING
    public SpeedPlayerState State;

    public PlayerStateChanged(SpeedPlayerState state)
    {
        State = state;
    }
}