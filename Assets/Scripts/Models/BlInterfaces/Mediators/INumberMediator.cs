using UniRx;

interface INumberMediator
{
    ReactiveProperty<int> ReactNum { get; }

    void Decrement(int number);
    void Increment(int number);
    void Pow(int number);
}