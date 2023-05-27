namespace LR1NN
{
    public interface IRecurringEvent : IEvent
    {
        public void SetFrequency(string frequency);
        public string GetFrequency();
    }
}
