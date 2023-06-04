using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_click : MonoBehaviour
{
    public void OnMouseDown() 
    {
        SceneManager.LoadScene(0);
    }

}
