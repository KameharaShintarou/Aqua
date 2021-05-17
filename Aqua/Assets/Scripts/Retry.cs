using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void OnClickRetry1Button()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void OnClickRetry2Button()
    {
        SceneManager.LoadScene("Stage3");
    }

}
