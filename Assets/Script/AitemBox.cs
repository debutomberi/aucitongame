using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AitemBox : SingletonMonoBehaviour<AitemBox>
{

    public int money = 1000000;

    Aitem[] aitems = new Aitem[4];
    [HideInInspector]
    public int nextAitem = 0;
    

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Buy(Aitem buyAitem)
    {
        if (nextAitem >= 4) return;
        aitems[nextAitem] = buyAitem;
        nextAitem++;
        for (int i = 0; i <= nextAitem - 1; i++)
        {
            Debug.Log((i+1)+"."+aitems[i].aitemName);
        }
    }

    public void ResetAitem()
    {
        for (int i = 0; i <= aitems.Length - 1; i++)
        {
            aitems[i] = null;
        }

    }

    //アイテムの値段
    public int AuctionStartprice(int auctionNumber)
    {
        return aitems[auctionNumber].startPrice;
    }

    //アイテムの種類
    public AitemType AucitionAitemType(int auctionNumber)
    {
        return aitems[auctionNumber].aitemType;
    }

    //アイテムの名前
    public string AutionAitemName(int auctionNumber)
    {
        return aitems[auctionNumber].aitemName;
    }

}
