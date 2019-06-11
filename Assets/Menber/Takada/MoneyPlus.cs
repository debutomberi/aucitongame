using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyPlus : MonoBehaviour
{
    //CPUが商品の金額をあげるスクリプト
    

    public GameObject[] CPUs = new GameObject[4]; //CPUを入れる配列
    int UpMoney; // 上乗せする金額
    int UppedMoney; //どれだけ上がったか
    int[] UpperLimit; // 上乗せできる表向きの合計金額上限
    int OneUpLimit = 10; //一度に上乗せできる金額の上限
    int money;           

    bool AuctionStart = true; //オークション開始のフラグ
    bool plusFlag;    //CPUが競りに参加しているかのフラグ
   [SerializeField] bool[] additionFlag;

    public int[] _cpuMoney; //CPUの所持金
    string bidder;      //落札者

    [SerializeField]
    private float Intaval;　　//どれだけ遅延させるか
    private float tmpTime = 0;

    public string[] _UserName;
    public int _ItemRate;     //商品の初期金額
    AitemType _aitemType;     //商品の部類
    AitemType cpuFavorite;　　//お気に入りの商品
    int _ItemCount = 0;

    [SerializeField]
    int count = 0;


    private void Start()
    {
        additionFlag = new bool[4];
        UpperLimit = new int[4];
        _cpuMoney = new int[4];
        _UserName = new string[4];
        money = AitemBox.Instance.money;

    }

    // Update is called once per frame
    void Update()
    {
        //アイテムが入っていれば競りを開始
        if (_ItemCount < 4 && AitemBox.Instance.AucitonStart(_ItemCount))
        {
            //競り開始時の商品の値段とアイテムタイプとユーザーの加算上限額を設定
            if (AuctionStart)
            {
                plusFlag = true;

                _ItemRate = AitemBox.Instance.AuctionStartprice(_ItemCount);
                _aitemType = AitemBox.Instance.AucitionAitemType(_ItemCount);
                
                for (int i = 0; i < CPUs.Length; i++)
                {
                    _cpuMoney[i] = UserBox.Instance.UserMoneyCheck(i);
                    _UserName[i] = UserBox.Instance.UserNameCheck(i);
                    UpperLimit[i] = _ItemRate + 2000 + 10 * Random.Range(50, 200);
                    if (UpperLimit[i] > _cpuMoney[i])
                    {
                        UpperLimit = _cpuMoney;
                    }
                    Debug.Log(_UserName[i] + "の限界は" + UpperLimit[i]);
                }

                AuctionStart = false;
            }

            //インターバル毎に行う処理
            tmpTime += Time.deltaTime;
            if (tmpTime >= Intaval)
            {
                Addition();
                tmpTime = 0f;
            }

        } else {
            //購入したアイテムがなくなったまたは購入していない場合はメニューへ戻る。
            Debug.Log("商品を購入していません");
            AitemBox.Instance.ResetAitem();
            OriginSceneManager.Instance.CheckClear();
        }
    }


    //金額の上乗せ処理
    private void Addition()
    {
        if (count == 3)
        {
            BidderCheck();
            return;
        }
        for (int i = 0; i < CPUs.Length; i++)
        {
            //CPUの名前と好みを配列に入れる。
            _UserName[i] = UserBox.Instance.UserNameCheck(i);
            cpuFavorite = UserBox.Instance.UserLikeCheck(i);

            if (!additionFlag[i])
            {
                if (UppedMoney <= UpperLimit[i])
                {
                    // 金額上限でなければ上乗せする
                    UpMoney = Random.Range(1,11) * Random.Range(1, OneUpLimit + 1);
                    UppedMoney += UpMoney;
                    _ItemRate = _ItemRate + UpMoney;

                    Debug.Log(UppedMoney);
                    Debug.Log("現在の値段は" + _ItemRate + "円です");
                    Debug.Log(_UserName[i] + "が掛け金を上乗せしました");

                }
                /*else if (UppedMoney >= UpperLimit[i] && cpuFavorite == _aitemType)
                {
                    //金額上限に到達し、好きな部類の商品なら上限を加算
                    UpperLimit[i] += 2000;
                    Debug.Log(_UserName[i] + "の好きな部類の商品です");

                }*/
                else
                {
                    //金額条件に到達し、好きな部類でなければ上げられなくする。
                    additionFlag[i] = true;
                    count++;
                    Debug.Log(_UserName[i] + "が降りました");
                    if (count == 3) break;
                }
            }
        }
    }

    void BidderCheck()
    {
        //1人以外全員加算できなくなっていたら落札して売り上げとして所持金に加算

        for (int i = 0; i < CPUs.Length; i++)
        {
            if (!additionFlag[i])
            {
                bidder = _UserName[i];
                _cpuMoney[i] -= _ItemRate;
            }
        }

        Debug.Log(bidder + "さんが商品を落札しました。");
        AitemBox.Instance.money += _ItemRate;
        _ItemCount += 1;
        count = 0;
        UppedMoney = 0;
        for (int i = 0;i < additionFlag.Length;i++)
        {
            additionFlag[i] = false;
        }
        AuctionStart = true;
    }
}

