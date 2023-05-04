using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Login();  // 本地訪客登入
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Login() 
    {
        var 要求 = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true

        };
        PlayFabClientAPI.LoginWithCustomID(要求, 成功, 失敗);

        void 成功 ( LoginResult result ) 
        {
            Debug.Log("你成功登入了，親！");
        }

        void 失敗 ( PlayFabError error )
        {
            Debug.Log("你成功失敗了，請加油喔！");
            Debug.Log(error.GenerateErrorReport());
        }

    }

}
