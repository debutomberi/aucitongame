using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    //行動をフラグ化する。
    public static bool[] stayflg = new bool[5];

    // Start is called before the first frame update
    void Start()
    {
        //フラグをfalseにする
        for(int i = 0; i < 5; i++)
        {
            stayflg[i] = false;

        }
    }
}
