using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class Counter : MonoBehaviour 
{
    public int CounterAmount = 0;
    public string CounterText = "Coins:";

    public static int Amount = 0;
    public static string TextString = "";
    public Text tCounterText;
    public Text tCounterAmount;

    public static void SetCounter(int _Amount)
    {
        Amount = _Amount;
    }
    public static void SetCounterText(string _Text)
    {
        TextString = _Text;
    }

    public static void DecreaseAmount( int _DecreaseBy)
    {
        Amount -= _DecreaseBy;
    }

    public static void IncreaseAmount(int _IncreaseBy)
    {
        Amount += _IncreaseBy;
        Debug.Log(Amount);    }
    
    void Update()
    {
        CounterAmount = Amount;
        TextString = CounterText;

        SetCounter(Amount);
        SetCounterText(TextString);

        tCounterAmount.text = Amount.ToString();
        tCounterText.text = TextString.ToString();
    }



}
