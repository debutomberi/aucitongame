using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPlus : MonoBehaviour
{
    //CPUが商品の金額をあげるスクリプト

    public List<GameObject> CPUs = new List<GameObject>(); //CPUを入れるList
    int UpMoney; // 上乗せする金額
    int UppedMoney; //どれだけ上がったか
    public int UpperLimit; // 上乗せできる表向きの合計金額上限
    int OneUpLimit = 10; //一度に上乗せできる金額の上限 

    bool AuctionStart = true; //オークション開始のフラグ
    bool plusFlag　= true;    //CPUが競りに参加しているかのフラグ

    public int _cpuMoney; //CPUの所持金

    [SerializeField]
    private float Intaval;
    private float tmpTime = 0;
    int Count;
    

    AitemBox aitemBox;
    public int _ItemRate; //商品の初期金額
    AitemType _aitemType;
    AitemType cpuFavorite;　　//お気に入りの商品
    int _ItemCount = 0;

    public SucccesfulBid succcesfulBid;


    private void Start()
    {
        aitemBox = GetComponent<AitemBox>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //競り開始時の商品の値段とアイテムタイプを設定
        if (AuctionStart)
        {
            for (Count = 0; Count != CPUs.Count; Count++)
            {
                _ItemRate = aitemBox.AuctionStartprice(_ItemCount);
                _aitemType = aitemBox.AucitionAitemType(_ItemCount);
                //_cpuMoney = 
                _ItemRate = 100;
                UpperLimit = _ItemRate + 2000 + 10 * Random.Range(50, 200);
                if(UpperLimit > _cpuMoney)
                {
                    UpperLimit = _cpuMoney;
                }
                //Debug.Log(CPUs[Count].name + "の限界は" + UpperLimit);
            }

            AuctionStart = false;
        }
       
        //インターバル毎に行う処理
        tmpTime += Time.deltaTime;
            if (tmpTime >= Intaval)
            {
                Addition();
                tmpTime = 0;

            }
            
            
    }


    //金額の上乗せ処理
    private void Addition()
    {

        // 金額上限でなければ上乗せする

        if (plusFlag && UppedMoney <= UpperLimit)
        {

                UpMoney = 10 * Random.Range(1, OneUpLimit + 1);
                UppedMoney += UpMoney;
                _ItemRate = _ItemRate + UppedMoney;
                //Debug.Log(UppedMoney);
                //Debug.Log("現在の値段は" +_ItemRate +  "円です");
                //Debug.Log(CPUs[Count].name + "が掛け金を上乗せしました");
                Count++;
               
           
                if(Count == CPUs.Count)
                {
                    Count = 0;
                }
             
        } else 

        if(plusFlag && UppedMoney >= UpperLimit && cpuFavorite == _aitemType)
        {
            UpperLimit += 2000;
            Debug.Log(CPUs[Count].name + "の好きな部類の商品です");
        }
        else
        {
            plusFlag = false;
        }

        /*
        if (plusFlag == false)
        {
            succcesfulBid.GetComponent<SucccesfulBid>().Succes();
            AuctionStart = true;
        }
        */
    }
}
