using UniRx;

class NumberMediator
{
    public ReactiveProperty<int> ReactNum { get; private set; }

    public NumberMediator ()
    {
        ReactNum = new ReactiveProperty<int>();
    }

    public void Pow(int number)
    {
        var Number = new Number(number);
        Number.Pow();

        var dao = new NumberFile("pow");
        dao.Save(Number);

        ReactNum.Value = Number.Value;
    }

    public void Increment(int number)
    {
        var Number = new Number(number);
        Number.Increment();

        var dao = new NumberFile("increment");
        dao.Save(Number);

        ReactNum.Value = Number.Value;
    }

    public void Decrement(int number)
    {
        var Number = new Number(number);
        Number.Decrement();

        var dao = new NumberFile("decrement");
        dao.Save(Number);

        ReactNum.Value = Number.Value;
    }
}