using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("Stage");
        Debug.Log("hh");
    }
}
