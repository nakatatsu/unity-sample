using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class Presenter : MonoBehaviour
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

    private INumberMediator NumberMediator;

    private void Start()
    {
        // Modelの値の保持 
        NumberMediator = MediatorFactory.Create<NumberMediator>();

        // Modelの監視
        NumberMediator.ReactNum
                      .Skip(1)
                      .Subscribe(number => OutputText.text = "処理結果 " + number.ToString());

        // 値のチェック（とボタンの有効／無効登録３点。）
        var stream = InputForm.OnValueChangedAsObservable().Select(x => Validate(x)).Publish();
        stream.SubscribeToInteractable(PowButton);
        stream.SubscribeToInteractable(IncrementButton);
        stream.SubscribeToInteractable(DecrementButton);
        stream.Connect();


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
