namespace LR1NN
{
    public interface IEvent : IComparable<IEvent>
    {
        public void SetName(string name);
        public void SetPlace(string place);
        public void SetDate(string date);
        public string GetName();
        public string GetPlace();
        public string GetDate();
        public void Show();
    }
}
