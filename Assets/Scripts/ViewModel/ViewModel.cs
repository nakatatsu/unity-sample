using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ViewModel : MonoBehaviour
{
    [SerializeField]
    private InputField InputForm;

    [SerializeField]
    private Text OutputText;

    [SerializeField]
    private Button PowButton;

    [SerializeField]
    private Button IncrementButton;

    [SerializeField]
    private Button DecrementButton;

    private NumberMediator NumberMediator;

    private void Start()
    {
        // NumberMediatorの監視登録
        NumberMediator = new NumberMediator();

        NumberMediator.Calculated += new NumberMediator.NumberChangedEventHandler((int sender) => OutputText.text = "処理結果 " + sender.ToString());

        // 値のチェック（とボタンの有効／無効登録３点。）
        InputForm.OnValueChangedAsObservable()
                 .Select(x => Validate(x))
                 .SubscribeToInteractable(PowButton);

        InputForm.OnValueChangedAsObservable()
                 .Select(x => Validate(x))
                 .SubscribeToInteractable(IncrementButton);

        InputForm.OnValueChangedAsObservable()
                 .Select(x => Validate(x))
                 .SubscribeToInteractable(DecrementButton);

        // ユーザーアクションとロジックの紐づけ
        PowButton.OnClickAsObservable()
                 .Select(_ => Validate(InputForm.text))
                 .Subscribe(_ => NumberMediator.Pow(Int32.Parse(InputForm.text)));

        IncrementButton.OnClickAsObservable()
                 .Select(_ => Validate(InputForm.text))
                 .Subscribe(_ => NumberMediator.Increment(Int32.Parse(InputForm.text)));

        DecrementButton.OnClickAsObservable()
                 .Select(_ => Validate(InputForm.text))
                 .Subscribe(_ => NumberMediator.Decrement(Int32.Parse(InputForm.text)));
    }

    private bool Validate(string input)
    {
        int tmp;
        if (!Int32.TryParse(input, out tmp)) return false;

        return true;
    }
}