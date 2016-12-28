using System;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    private InputField InputForm;
    private Text OutputText;
    private NumberMediator NumberMediator;

    private void Start()
    {
        NumberMediator = new NumberMediator();
        InputForm = GameObject.Find("InputForm").GetComponent<InputField>();
        OutputText = GameObject.Find("OutputText").GetComponent<Text>();
        NumberMediator.Calculated += new NumberMediator.NumberChangedEventHandler((int sender) => OutputText.text = "処理結果 " + sender.ToString());
    }

    private bool Check(string input)
    {
        bool valid = true;

        int tmp;
        if (!Int32.TryParse(input, out tmp))
        {
            OutputText.text = "整数のみ入力可";
            valid = false;
        }

        return valid;
    }

    public void OnClickPow()
    {
        // check
        if (!Check(InputForm.text))
            return;

        // NumberMediator
        NumberMediator.Pow(Int32.Parse(InputForm.text));
    }

    public void OnClickIncrement()
    {
        // check
        if (!Check(InputForm.text))
            return;

        // NumberMediator
        NumberMediator.Increment(Int32.Parse(InputForm.text));
    }

    public void OnClickDecrement()
    {
        // check
        if (!Check(InputForm.text))
            return;

        // NumberMediator
        NumberMediator.Decrement(Int32.Parse(InputForm.text));
    }
}
