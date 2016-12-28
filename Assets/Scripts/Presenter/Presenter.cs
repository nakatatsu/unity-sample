using System;

public class Presenter
{
    private int view;

    public int OnClickPow(int number)
    {
        var num = new Number(number);
        num.Pow();

        return num.Value;
    }

    public int OnClickIncrement(int number)
    {
        var num = new Number(number);
        num.Pow();
        return num.Value;
    }

    public int OnClickDecrement(int number)
    {
        var num = new Number(number);
        num.Pow();
        return num.Value;
    }
}
