using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class StageController : MonoBehaviour
{
    [SerializeField]
    int stageLength;

    [SerializeField]
    Text KeyText;

    [SerializeField]
    Goal Goal;

    [SerializeField]
    int keyCount;
    int keyMax = 3;


    [SerializeField]
    GameObject GroundPrefab;
    [SerializeField]
    List<GameObject> Grounds = new List<GameObject>();

    [SerializeField]
    GameObject BackGroundPrefab;
    [SerializeField]
    List<GameObject> BackGrounds = new List<GameObject>();

    [SerializeField]
    GameObject stage;

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

    public int GetStageLength()
    {
        return stageLength;
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (stage == null)
        {
            stage = new GameObject("Stage");
        }

        if (Grounds.Count != stageLength)
        {
            foreach (GameObject Ground in Grounds)
            {
                EditorApplication.delayCall += () => DestroyImmediate(Ground);
            }
            Grounds.Clear();

            foreach (GameObject BackGround in BackGrounds)
            {
                EditorApplication.delayCall += () => DestroyImmediate(BackGround);
            }
            BackGrounds.Clear();


            for (int i = 0; i < stageLength; i++)
            {
                Vector3 position = new Vector3((i * 7) - ((float)(stageLength - 1) / 2 * 7), 0, 0);
                Grounds.Add(Instantiate(GroundPrefab, position, Quaternion.Euler(0, 0, 0), stage.transform));
                BackGrounds.Add(Instantiate(BackGroundPrefab, position, Quaternion.Euler(0, 0, 0), stage.transform));
                BackGrounds.Add(Instantiate(BackGroundPrefab, position, Quaternion.Euler(0, 180, 0), stage.transform));
            }

            BackGrounds.Add(Instantiate(BackGroundPrefab, new Vector3(((float)(stageLength - 1) / 2 * 7), 0, 0), Quaternion.Euler(0, 90, 0), stage.transform));
            BackGrounds.Add(Instantiate(BackGroundPrefab, new Vector3(-((float)(stageLength - 1) / 2 * 7), 0, 0), Quaternion.Euler(0, -90, 0), stage.transform));
        }
    }
#endif

}
