namespace Helpers.EventBus
{
    public sealed class BusValue<T> : BusEvent<T>
    {
        private T _curentValue;

        public T Value
        {
            get => _curentValue;
            set
            {
                _curentValue = value;
                _handlers?.Invoke(_curentValue);
            }
        }

        public void SetSilence(T value)
        {
            _curentValue = value;
        }

        public override void Publish(T value)
        {
            base.Publish(value);
            _curentValue = value;
        }
    }
}
