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
            CreateAccount = true

        };
        PlayFabClientAPI.LoginWithCustomID(�n�D, ���\, ����);

        void ���\ ( LoginResult result ) 
        {
            Debug.Log("�A���\�n�J�F�A�ˡI");
        }

        void ���� ( PlayFabError error )
        {
            Debug.Log("�A���\���ѤF�A�Х[�o��I");
            Debug.Log(error.GenerateErrorReport());
        }

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

        PlayFabClientAPI.UpdatePlayerStatistics(�n�D, �Ʀ�]��s, ����);

        void �Ʀ�]��s(UpdatePlayerStatisticsResult ���G) 
        {
            Debug.Log("�w�g���\����ƤW�Ǧܶ���");
        }
        void ����(PlayFabError error) 
        {
            
        }
    }


}
