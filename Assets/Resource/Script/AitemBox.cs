﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AitemBox : SingletonMonoBehaviour<AitemBox>
{

    public int money = 10000;

    [SerializeField]Aitem[] aitems = new Aitem[4];
    [HideInInspector]
    public int nextAitem = 0;
    

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
        nextAitem = 0;
    }

    public bool AucitonStart(int i) {
        if (aitems[i] == null) { return false; }
        else { return true; }
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
        if (aitems[auctionNumber] == null) { return "未購入"; }
        return aitems[auctionNumber].aitemName;
    }

}
