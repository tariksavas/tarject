namespace Tarject.Samples.Scripts.Runtime.Signal
{
    public readonly struct UserDataReceivedSignal
    {
        public readonly string UserId;

        public UserDataReceivedSignal(string userId)
        {
            UserId = userId;
        }
    }
}