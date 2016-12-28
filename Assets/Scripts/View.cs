using System;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    private InputField InputForm;
    private Text OutputText;
    private Logic logic;

    private void Start()
    {
        logic = new Logic();
        InputForm = GameObject.Find("InputForm").GetComponent<InputField>();
        OutputText = GameObject.Find("OutputText").GetComponent<Text>();
        logic.Calculated += new Logic.NumberChangedEventHandler((int sender) => OutputText.text = "処理結果 " + sender.ToString());
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

        // logic
        logic.Pow(Int32.Parse(InputForm.text));
    }

    public void OnClickIncrement()
    {
        // check
        if (!Check(InputForm.text))
            return;

        // logic
        logic.Increment(Int32.Parse(InputForm.text));
    }

    public void OnClickDecrement()
    {
        // check
        if (!Check(InputForm.text))
            return;

        // logic
        logic.Decrement(Int32.Parse(InputForm.text));
    }
}
