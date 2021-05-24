using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField]
    MeshRenderer MeshRenderer;

    [SerializeField]
    Material Material;

    bool goalFlag;

    void Start()
    {
        goalFlag = false;
    }

    public void OnGoalFlag()
    {
        goalFlag = true;
        MeshRenderer.material = Material;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player.GetIsPlaying() &&
                goalFlag)
            {
                switch (SceneManager.GetActiveScene().name)
                {
                    case "Stage1":
                        SceneManager.LoadScene("StageClear1");
                        break;
                    case "Stage2":
                        SceneManager.LoadScene("StageClear2");
                        break;
                    case "Stage3":
                        SceneManager.LoadScene("StageClear3");
                        break;
                }
            }
        }
    }
}
