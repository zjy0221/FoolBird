using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabManger : MonoBehaviour
{
    [Header("��J�ΦW����")]
    public GameObject nameWindow;
    public Text nameInput;


    // Start is called before the first frame update
    void Start()
    {
        Login();  // ���a�X�ȵn�J
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Login() 
    {
        var �n�D = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams 
            {
                GetPlayerProfile = true,
            }
        };
        PlayFabClientAPI.LoginWithCustomID(�n�D, �n�J���\, �n�J����);
    }
    void �n�J���\(LoginResult result)
    {
        Debug.Log("�A���\�n�J�F�A�ˡI");
        string name = null;

        if (result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        if (name == null)
        {
            nameWindow.SetActive(true);

        }
    }
    void �n�J����(PlayFabError error)
    {
        Debug.Log("�A���\���ѤF�A�Х[�o��I");
        Debug.Log(error.GenerateErrorReport());
    }
    public void name_btn()
    {
        var �n�D = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(�n�D, ��J�W�r���, ���ѻP���~);
        nameWindow.SetActive(false);
    }

    void ��J�W�r���( UpdateUserTitleDisplayNameResult result ) 
    {
        Debug.Log("��s�ΦW��ܡI");
    }



    public void �������Ʀ�] ( int coin )
    {
        var �n�D = new UpdatePlayerStatisticsRequest
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

        PlayFabClientAPI.UpdatePlayerStatistics(�n�D, �Ʀ�]��s, ���ѻP���~);

        void �Ʀ�]��s(UpdatePlayerStatisticsResult ���G) 
        {
            Debug.Log("�w�g���\����ƤW�Ǧܶ���");
        }
    }

    void ���ѻP���~(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
}
