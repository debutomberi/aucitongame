using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct User {

    public string userName;
    public AitemType likeAitem;
    public int moneyHeld;
}

public enum name {田中,小林,八九寺,豪炎寺,寺生まれ,ギーグ,円藤,万丈目,武藤,城乃内}

public class UserBox : SingletonMonoBehaviour<UserBox>
{

    User[] users = new User[4];

    // Start is called before the first frame update
    void Start()
    {

        UsersCreate();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //4人の客のステータスを生成
    public void UsersCreate()
    {
        for(int i=0;i < users.Length; i++)
        {
            users[i] = UserCreate(i);
            Debug.Log("名前:" + users[i].userName +
                        "好みのアイテム:" + users[i].likeAitem.ToString() +
                        "所持金:" + users[i].moneyHeld
                );
        }
    }

    //ユーザーの名前を参照
    public string UserNameCheck(int userNum)
    {
        return users[userNum].userName;
    }
    //ユーザーの好みを参照
    public AitemType UserLikeCheck(int userNum)
    {
        return users[userNum].likeAitem;
    }
    //ユーザーの所持金を参照
    public int UserMoneyCheck(int userNum)
    {
        return users[userNum].moneyHeld;
    }
    //ユーザーの所持金を減らす
    public void UserMoneyCut(int userNum,int CutVal)
    {
        users[userNum].moneyHeld =- CutVal;
    }


    User UserCreate(int i){
        User user = new User();
        bool OK = false;
        while(OK == false)
        {
            name name = RandomEnumValue<name>();
            user.userName = name.ToString();
            OK = true;
            for(int j = 0; j < i; j++)
            {
                if(users[j].userName == user.userName)
                {
                    OK = false;
                }
            }
        }
        OK = false;
        while (OK == false)
        {
            user.likeAitem = RandomEnumValue<AitemType>();
            if(i == 0)
            {
                OK = true;
            }
            else if (users[i-1].likeAitem != user.likeAitem)
            {
                OK = true;
            }
        }
        user.moneyHeld = 8000 + UnityEngine.Random.Range(0, 6001);
        return user;
    }

    static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(new System.Random().Next(v.Length));
    }

}
