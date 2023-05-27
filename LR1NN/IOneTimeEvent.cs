namespace LR1NN
{
    public interface IOneTimeEvent : IEvent
    {
        public void SetDuration(int duration);
        public int GetDuration();
    }
}
