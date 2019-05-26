using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SakuraManager : MonoBehaviour
{
    [SerializeField]
    public Text label;
    public Text aaa;
    [SerializeField]
    public int count;
    //[SerializeField]
    //public int bidcount;

    public MoneyPlus moneyPlus;
    //public int SakuraMoney;


    void Start()
    {
        //bidcount = 0;
        moneyPlus = GetComponent<MoneyPlus>();
        count = 0;
        UpdateLabel();
    }

    public void Update()
    {
        UpdateLabel();
    }


    //クリック時金額を上げる
    public void UpClick()
    {
        count = count + 100;
        UpdateLabel();
    }

    //クリック時金額が0を下回らないように下げる
    public void DownClic()
    {
        if (count == 0)
        {
            count = count + 100;
        }

        count = count - 100;
        UpdateLabel();
    }

    //入札時元々の金額に足されるようにする
    public void bidClick()
    {
        //bidcount = bidcount + count;
        moneyPlus._ItemRate = moneyPlus._ItemRate + count;
        //bidcount(合計金額の表示)
        aaa.text = moneyPlus._ItemRate + "円";
    }

    public void UpdateLabel()
    {
        label.text = count + "円";
        aaa.text = moneyPlus._ItemRate + "円";
    }
}