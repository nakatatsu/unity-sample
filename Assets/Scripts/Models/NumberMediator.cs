using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class NumberMediator
{
    public int Pow(int number)
    {
        var num = new Number(number);
        num.Pow();

        INumberDao dao = new PowNumberFile();
        dao.Save(num);

        return num.Value;
    }

    public int Increment(int number)
    {
        var num = new Number(number);
        num.Pow();

        INumberDao dao = new IncrementNumberFile();
        dao.Save(num);

        return num.Value;
    }

    public int Decrement(int number)
    {
        var num = new Number(number);
        num.Pow();

        INumberDao dao = new DecrementNumberFile();
        dao.Save(num);

        return num.Value;
    }
}
