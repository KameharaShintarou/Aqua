using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [SerializeField]
    Text KeyText;

    [SerializeField]
    Goal Goal;

    [SerializeField]
    int keyCount;
    int keyMax = 3;

    void Start()
    {
        keyCount = 0;
    }

    void Update()
    {
        
    }

    public void GetKey()
    {
        keyCount++;

        KeyText.text = "× " + keyCount;

        if (keyCount == keyMax)
        {
            Goal.OnGoalFlag();
        }
    }
}
