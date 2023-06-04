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

    public void 紀錄給排行榜 ( int coin )
    {
        var 要求 = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "coin_playfab" ,
                    Value = coin
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(要求, 排行榜更新, 失敗);

        void 排行榜更新(UpdatePlayerStatisticsResult 結果) 
        {
            Debug.Log("已經成功把分數上傳至雲端");
        }
        void 失敗(PlayFabError error) 
        {
            
        }
    }


}
