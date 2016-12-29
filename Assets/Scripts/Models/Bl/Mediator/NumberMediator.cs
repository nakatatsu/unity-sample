using UniRx;

public class NumberMediator : INumberMediator
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

        var dao = NumberDaoFactory.Create("pow");
        dao.Save(Number);

        ReactNum.Value = Number.Value;
    }

    public void Increment(int number)
    {
        var Number = new Number(number);
        Number.Increment();

        var dao = NumberDaoFactory.Create("increment");
        dao.Save(Number);

        ReactNum.Value = Number.Value;
    }

    public void Decrement(int number)
    {
        var Number = new Number(number);
        Number.Decrement();

        var dao = NumberDaoFactory.Create("decrement");
        dao.Save(Number);

        ReactNum.Value = Number.Value;
    }
}