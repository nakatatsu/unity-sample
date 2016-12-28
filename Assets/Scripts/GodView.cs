using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GodView : MonoBehaviour
{

    public void OnClickPow()
    {
        // in
        var input = GameObject.Find("InputForm").GetComponent<InputField>().text;

        // check
        int number;
        bool canParse = Int32.TryParse(input, out number);
        if (!canParse)
        {
            GameObject.Find("OutputText").GetComponent<Text>().text = "整数のみ入力可";
            return;
        }

        // logic
        var output = Math.Pow(number, 2);
        using (var fileStream = new FileStream(Application.persistentDataPath + "/pow.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.None))
        {
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(output.ToString());
            }
        }

        // out
        GameObject.Find("OutputText").GetComponent<Text>().text = "処理結果 " + output.ToString();
    }

    public void OnClickIncrement()
    {
        // in
        var input = GameObject.Find("InputForm").GetComponent<InputField>().text;

        // check
        int number;
        bool canParse = Int32.TryParse(input, out number);
        if (!canParse)
        {
            GameObject.Find("OutputText").GetComponent<Text>().text = "整数のみ入力可";
            return;
        }

        // logic
        var output = number + 1;
        using (var fileStream = new FileStream(Application.persistentDataPath + "/increment.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.None))
        {
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(output.ToString());
            }
        }

        // out
        GameObject.Find("OutputText").GetComponent<Text>().text = "処理完了" + output.ToString();
    }

    public void OnClickDecrement()
    {
        // in
        var input = GameObject.Find("InputForm").GetComponent<InputField>().text;

        // check
        int number;
        bool canParse = Int32.TryParse(input, out number);
        if (!canParse)
        {
            GameObject.Find("OutputText").GetComponent<Text>().text = "整数のみ入力可";
            return;
        }

        // logic
        var output = number - 1;
        using (var fileStream = new FileStream(Application.persistentDataPath + "/pow.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.None))
        {
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(output.ToString());
            }
        }

        // out
        GameObject.Find("OutputText").GetComponent<Text>().text = "処理完了" + output.ToString();
    }


}
