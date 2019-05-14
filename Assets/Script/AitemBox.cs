using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AitemBox : SingletonMonoBehaviour<AitemBox>
{
    //仮の変数。後で消す。
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

}
