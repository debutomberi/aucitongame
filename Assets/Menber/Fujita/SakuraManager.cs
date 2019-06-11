using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SakuraManager : MonoBehaviour
{
    [SerializeField]
    public Text Count;
    public Text BidCount;

    public Text PlayerCount;
    public Text AI1;
    public Text AI2;
    public Text AI3;
    public Text AI4;
    public int count;
    //public float Timecount = 5;

    public MoneyPlus moneyPlus;
    //public int SakuraMoney;


    void Start()
    {
        //bidcount = 0;
        moneyPlus = GetComponent<MoneyPlus>();
        UpdateLabel();
    }

    public void Update()
    {
       // Timecount -= Time.deltaTime;
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


        //if (count >= 0 || Timecount == 0)
        //{
        //    Timecount = 5;
        //    count = 0;
        //}
    }

    public void UpdateLabel()
    {
        //count(入札金額の表示)
        Count.text = "入札する金額\n" + count + "円";
        //PlayerCount(プレイヤーの宣言)
        PlayerCount.text = moneyPlus._ItemRate + count + "";
        //bidcount(合計金額の表示)
        BidCount.text = "現在の金額" + moneyPlus._ItemRate + "円";
    }
}