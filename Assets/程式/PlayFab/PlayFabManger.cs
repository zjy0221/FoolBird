using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabManger : MonoBehaviour
{
    [Header("輸入匿名視窗")]
    public GameObject nameWindow;
    public Text nameInput;


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
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams 
            {
                GetPlayerProfile = true,
            }
        };
        PlayFabClientAPI.LoginWithCustomID(要求, 登入成功, 登入失敗);
    }
    void 登入成功(LoginResult result)
    {
        Debug.Log("你成功登入了，親！");
        string name = null;

        if (result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        if (name == null)
        {
            nameWindow.SetActive(true);

        }
    }
    void 登入失敗(PlayFabError error)
    {
        Debug.Log("你成功失敗了，請加油喔！");
        Debug.Log(error.GenerateErrorReport());
    }
    public void name_btn()
    {
        var 要求 = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(要求, 輸入名字顯示, 失敗與錯誤);
        nameWindow.SetActive(false);
    }

    void 輸入名字顯示( UpdateUserTitleDisplayNameResult result ) 
    {
        Debug.Log("更新匿名顯示！");
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

        PlayFabClientAPI.UpdatePlayerStatistics(要求, 排行榜更新, 失敗與錯誤);

        void 排行榜更新(UpdatePlayerStatisticsResult 結果) 
        {
            Debug.Log("已經成功把分數上傳至雲端");
        }
    }

    void 失敗與錯誤(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
}
