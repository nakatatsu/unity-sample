class NumberMediator
{
    public delegate void NumberChangedEventHandler(int sender);
    public event NumberChangedEventHandler Calculated;
    Number Number;

    public void Pow(int number)
    {
        Number = new Number(number);
        Number.Pow();

        var dao = new NumberFile("pow");
        dao.Save(Number);

        Calculated(Number.Value);
    }

    public void Increment(int number)
    {
        Number = new Number(number);
        Number.Increment();

        var dao = new NumberFile("increment");
        dao.Save(Number);

        Calculated(Number.Value);
    }

    public void Decrement(int number)
    {
        Number = new Number(number);
        Number.Decrement();

        var dao = new NumberFile("decrement");
        dao.Save(Number);

        Calculated(Number.Value);
    }
}
