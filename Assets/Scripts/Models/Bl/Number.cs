using System;

public class Number
{
    public int Value { get; private set; }

    public Number(int number)
    {
        Value = number;
    }

    public void Pow()
    {
        Value = (int) Math.Pow(Value, 2);
    }

    public void Increment()
    {
        Value++;
    }

    public void Decrement()
    {
        Value--;
    }
}
