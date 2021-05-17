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
                // SceneChangeのスクリプトの関数に置き換えたい
                SceneManager.LoadScene("GameClear");
            }
        }
    }
}
