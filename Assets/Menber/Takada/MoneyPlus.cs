using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyPlus : MonoBehaviour
{
    //CPUが商品の金額をあげるスクリプト

    //AitemBox aitemBox;
    //UserBox userBox;
    public SucccesfulBid succcesfulBid;
    //OriginSceneManager originSceneManager;

    public List<GameObject> CPUs = new List<GameObject>(); //CPUを入れるList
    int UpMoney; // 上乗せする金額
    int UppedMoney; //どれだけ上がったか
    int UpperLimit; // 上乗せできる表向きの合計金額上限
    int OneUpLimit = 10; //一度に上乗せできる金額の上限 

    bool AuctionStart = true; //オークション開始のフラグ
    bool plusFlag　= true;    //CPUが競りに参加しているかのフラグ

    public int _cpuMoney; //CPUの所持金

    [SerializeField]
    private float Intaval;　　//どれだけ遅延させるか
    private float tmpTime = 0;
    int cpuCount;

    public int _ItemRate;     //商品の初期金額
    AitemType _aitemType;     //商品の部類
    AitemType cpuFavorite;　　//お気に入りの商品
    int _ItemCount = 0;




    private void Start()
    {
        //aitemBox = GetComponent<AitemBox>();
        //userBox = GetComponent<UserBox>();
        //originSceneManager = GetComponent<OriginSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (AitemBox.Instance.AucitonStart())
        {
            //競り開始時の商品の値段とアイテムタイプとユーザーの加算上限額を設定
            if (AuctionStart)
            {
                _ItemRate = AitemBox.Instance.AuctionStartprice(_ItemCount);
                _aitemType = AitemBox.Instance.AucitionAitemType(_ItemCount);

                for (cpuCount = 0; cpuCount != CPUs.Count; cpuCount++)
                {
                    _cpuMoney = UserBox.Instance.UserMoneyCheck(cpuCount);
                    _ItemRate = 100;
                    UpperLimit = _ItemRate + 2000 + 10 * Random.Range(50, 200);
                    if (UpperLimit > _cpuMoney)
                    {
                        UpperLimit = _cpuMoney;
                    }
                    Debug.Log(CPUs[cpuCount].name + "の限界は" + UpperLimit);
                }

                AuctionStart = false;
            }

            //インターバル毎に行う処理
            tmpTime += Time.deltaTime;
            Debug.Log(tmpTime);
            if (tmpTime >= Intaval)
            {
                tmpTime = 0;
                Addition();

            }

        } else {
            Debug.Log("商品を購入していません");
            AitemBox.Instance.ResetAitem();
            OriginSceneManager.Instance.CheckClear();
        }
    }


    //金額の上乗せ処理
    private void Addition()
    {

        // 金額上限でなければ上乗せする

        if (UppedMoney <= UpperLimit)
        {

                UpMoney = 10 * Random.Range(1, OneUpLimit + 1);
                UppedMoney += UpMoney;
                _ItemRate = _ItemRate + UppedMoney;
                Debug.Log(UppedMoney);
                Debug.Log("現在の値段は" +_ItemRate +  "円です");
                Debug.Log(CPUs[cpuCount].name + "が掛け金を上乗せしました");
                cpuCount++;
               
           
                if(cpuCount == CPUs.Count)
                {
                    cpuCount = 0;
                }
             
        } else 

        if(UppedMoney >= UpperLimit && cpuFavorite == _aitemType)
        {
            //好きな部類の商品なら上限を加算
            UpperLimit += 2000;
            Debug.Log(CPUs[cpuCount].name + "の好きな部類の商品です");
            /*
            cpuCount++;
            if(cpuCount == CPUs.Count)
            {
                cpuCount = 0;
            }
            */
        }
        else
        {
            plusFlag = false;
            /*
            cpuCount++;
            if (cpuCount == CPUs.Count)
            {
                cpuCount = 0;
            }
            */
        }

        //1人以外全員加算できなくなっていたら落札

        for (int i = 0; i != CPUs.Count; i++)
        {
            if (!CPUs[i]) { return; }
        }
           
            Debug.Log(CPUs[cpuCount].name + "さんが商品を落札しました。");
            succcesfulBid.GetComponent<SucccesfulBid>().Succes();
            _ItemCount += 1;
            AuctionStart = true;
    }
}
