using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectButton : MonoBehaviour
{
    // はじめに選択状態に設定するボタンを指定します。
    [SerializeField]
    private Button selectedButton = null;

    public void Start()
    {
        // はじめに選択状態に設定
        selectedButton.Select();
    }

    public void OnClickNextStageButton()
    {
        SceneManager.LoadScene("Stage");
    }
    public void OnClickSelectStageButton()
    {
        SceneManager.LoadScene("SelectStage");
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
