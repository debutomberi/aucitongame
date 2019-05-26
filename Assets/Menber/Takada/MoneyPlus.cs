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

    [SerializeField]
    private float Intaval;
    private float tmpTime = 0;
    int Count;
    

    AitemBox aitemBox;
    public int _ItemRate; //商品の初期金額
    AitemType _aitemType;
    AitemType Favorite;　　//お気に入りの商品
    int _ItemCount = 0;


    private void Start()
    {
        aitemBox = GetComponent<AitemBox>();
        
    }

    // Update is called once per frame
    void Update()
    {
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
        _ItemRate = aitemBox.AuctionStartprice(_ItemCount);
        _aitemType = aitemBox.AucitionAitemType(_ItemCount);
        UpperLimit = _ItemRate + 2000 + Random.Range(500, 2000);

        // 金額上限でなければ上乗せする

        if (UppedMoney <= UpperLimit)
            {

                UpMoney = 10 * Random.Range(1, OneUpLimit + 1);
                UppedMoney += UpMoney;
                _ItemRate = _ItemRate + UppedMoney;
                Debug.Log(UppedMoney);
                Debug.Log(_ItemRate);
                Debug.Log(CPUs[Count].name + "が掛け金を上乗せしました");
                Count++;
               
           
                if(Count == CPUs.Count)
                {
                    Count = 0;
                }
             
            }

        if(UppedMoney >= UpperLimit && Favorite == _aitemType)
        {
            UpperLimit += 2000;
        }


    }
}
