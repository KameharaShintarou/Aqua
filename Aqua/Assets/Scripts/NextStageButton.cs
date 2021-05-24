using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextStageButton : MonoBehaviour
{

    public void OnClickNextStage2Button()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void OnClickNextStage3Button()
    {
        SceneManager.LoadScene("Stage3");
    }

}
