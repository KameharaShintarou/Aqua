using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField]
    GameObject PauseUI;
    public void OnClickStartButton()
    {
        Destroy(PauseUI);
        Time.timeScale = 1.0f;
        Debug.Log("3");
    }
}