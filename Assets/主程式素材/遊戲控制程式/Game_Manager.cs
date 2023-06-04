using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer
{
    public class Game_Manager : MonoBehaviour
    {
        public static Game_Manager instance;
        public PlayFabManger PlayFabManger;

        public int coinsCounter = 0;
        public int coinSum = 0;

        public GameObject playerGameObject;
        private PlayerCode player;
        public GameObject deathPlayerPrefab;
        public Text coinText;

        public GameObject result;
        public Text coinResult_Text;
        public Text timeResult_Text;
        float time_f;
        int time_i;

        public GameObject nameWindow;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerCode>();
            result.SetActive(false);

        }

        void Update()
        {
            coinText.text = coinsCounter.ToString();
            if (player.deathState == true)
            {
                playerGameObject.SetActive(false);
                GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                player.deathState = false;
                Invoke("ReloadLevel",2.0f);
            }

            if (result.active == true)
            {
                Result_State();
            }
            else
            {
                Time.timeScale = 1;
            }

            void Result_State()
            {
                coinSum = coinsCounter;
                coinResult_Text.text = coinSum.ToString();

                time_f = Time.time;
                time_i = Mathf.FloorToInt(time_f);
                Time.timeScale = 0;
                timeResult_Text.text = time_i.ToString();

                PlayFabManger.¬ö¿ýµ¹±Æ¦æº](coinSum);
            }

            if (nameWindow.active == true)
            {
                Time.timeScale = 0;
            }

        }
        public void ReloadLevel()
        {
            //SceneManager.LoadScene(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
