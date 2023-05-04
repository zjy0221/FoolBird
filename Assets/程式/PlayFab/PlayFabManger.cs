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

}
