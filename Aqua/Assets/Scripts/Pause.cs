
using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

	[SerializeField]
	//　ポーズした時に表示するUIのプレハブ
	public GameObject pauseUIPrefab;
	//　ポーズUIのインスタンス
	public GameObject pauseUIInstance;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("p"))
		{
			Debug.Log("1");
			//UIがなかったら
			if (pauseUIInstance == null)
			{
				Debug.Log("2");
				//UI召喚
				pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
				//時間停止
				Time.timeScale = 0f;
			}
		}
	}
}


