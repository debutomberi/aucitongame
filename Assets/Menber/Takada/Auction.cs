using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auction : MonoBehaviour
{
    List<GameObject> cpus = new List<GameObject>();

    int upMoney;
    int uppedMoney;
    int[] upperLimit = new int[4];
    int oneUpLimit;

    bool auctionStart = true;
    bool plusFlag = true;

    public int[] cpuMoney = new int[4];
    public string[] cpuName = new string[4];

    [SerializeField]
    private float intaval;
    private float tmpTime = 0;
 
    int _itemRate;
    int itemCount;
    AitemType _itemType;
    AitemType cpuFavorite;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AitemBox.Instance.AucitonStart())
        {
            if (auctionStart)
            {
                _itemRate = AitemBox.Instance.AuctionStartprice(itemCount);
                _itemType = AitemBox.Instance.AucitionAitemType(itemCount);
                for(int i = 0; i != cpus.Count; i++)
                {
                    cpuMoney[i] = UserBox.Instance.UserMoneyCheck(i);
                    cpuName[i] = UserBox.Instance.UserNameCheck(i);
                }

            }

        }
    }
    
    private void Addition()
    {

    }
}
