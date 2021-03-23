using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSelect : MonoBehaviour
{
    // はじめに選択状態に設定するボタンを指定する。
    [SerializeField]
    private Button selectedButton = null;

    public void Start()
    {
        // はじめに選択状態に設定
        selectedButton.Select();
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("Stage");
    }
}
