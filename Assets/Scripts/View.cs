using System;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    private string Input()
    {
        var input = GameObject.Find("InputForm").GetComponent<InputField>().text;
        return input;
    }

    private void Output(string message)
    {
        GameObject.Find("OutputText").GetComponent<Text>().text = message;
    }


    public void OnClickPow()
    {
        // in
        var input = Input();

        // check
        var logic = new Logic();
        if (! logic.Check(input))
        {
            Output("整数のみ入力可");
            return;
        }

        // logic
        var output = logic.Pow(Int32.Parse(input));

        // out
        Output("処理結果 " + output.ToString());
    }

    public void OnClickIncrement()
    {
        // in
        var input = Input();

        // check
        var logic = new Logic();
        if (!logic.Check(input))
        {
            Output("整数のみ入力可");
            return;
        }

        // logic
        var output = logic.Increment(Int32.Parse(input));

        // out
        Output("処理結果 " + output.ToString());
    }

    public void OnClickDecrement()
    {
        // in
        var input = Input();

        // check
        var logic = new Logic();
        if (!logic.Check(input))
        {
            Output("整数のみ入力可");
            return;
        }

        // logic
        var output = logic.Decrement(Int32.Parse(input));

        // out
        Output("処理結果 " + output.ToString());
    }


}
