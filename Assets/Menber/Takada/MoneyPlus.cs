using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyPlus : MonoBehaviour
{
    //CPUが商品の金額をあげるスクリプト

    public SucccesfulBid succcesfulBid;

    public GameObject[] CPUs = new GameObject[4]; //CPUを入れる配列
    int UpMoney; // 上乗せする金額
    int UppedMoney; //どれだけ上がったか
    int[] UpperLimit = new int[4]; // 上乗せできる表向きの合計金額上限
    int OneUpLimit = 10; //一度に上乗せできる金額の上限 

    bool AuctionStart = true; //オークション開始のフラグ
    bool plusFlag　= true;    //CPUが競りに参加しているかのフラグ

    public int[] _cpuMoney = new int[4]; //CPUの所持金

    [SerializeField]
    private float Intaval;　　//どれだけ遅延させるか
    private float tmpTime = 0;

    public string[] _UserName = new string [4];
    public int _ItemRate;     //商品の初期金額
    AitemType _aitemType;     //商品の部類
    AitemType cpuFavorite;　　//お気に入りの商品
    int _ItemCount = 0;




    private void Start()
    {

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
                

                for (int i = 0; i != CPUs.Length; i++)
                {
                    _cpuMoney[i] = UserBox.Instance.UserMoneyCheck(i);
                    _UserName[i] = UserBox.Instance.UserNameCheck(i);
                    UpperLimit[i] = _ItemRate + 2000 + 10 * Random.Range(50, 200);
                    if (UpperLimit[i] > _cpuMoney[i])
                    {
                        UpperLimit = _cpuMoney;
                    }
                    Debug.Log(_UserName + "の限界は" + UpperLimit);
                }

                AuctionStart = false;
            }

            //インターバル毎に行う処理
            tmpTime += Time.deltaTime;
            //Debug.Log(tmpTime);
            if (tmpTime >= Intaval)
            {
                Addition();
                tmpTime = 0f;
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
        for (int i = 0; i < CPUs.Length; i++)
        {
            _UserName[i] = UserBox.Instance.UserNameCheck(i);
            cpuFavorite = UserBox.Instance.UserLikeCheck(i);

            // 金額上限でなければ上乗せする
            if (plusFlag)
            {
                if (UppedMoney <= UpperLimit[i])
                {
                    UpMoney = 10 * Random.Range(1, OneUpLimit + 1);
                    UppedMoney += UpMoney;
                    _ItemRate = _ItemRate + UppedMoney;
                    //ここで誰が上げたか判定

                    Debug.Log(UppedMoney);
                    Debug.Log("現在の値段は" + _ItemRate + "円です");
                    Debug.Log(_UserName + "が掛け金を上乗せしました");

                }

                else

                if (UppedMoney >= UpperLimit[i] && cpuFavorite == _aitemType)
                {
                    //好きな部類の商品なら上限を加算
                    UpperLimit[i] += 2000;
                    Debug.Log(_UserName + "の好きな部類の商品です");

                }
                else
                {
                    plusFlag = false;

                }
            }
        }
        
            //1人以外全員加算できなくなっていたら落札

            for (int i = 0; i != CPUs.Length; i++)
            {
                if (!CPUs[i]) { return; }
            }

            Debug.Log(_UserName + "さんが商品を落札しました。");
            //succcesfulBid.GetComponent<SucccesfulBid>().Succes();
            _ItemCount += 1;
            AuctionStart = true;
        
    }
}
