using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    //カーソルとボタンが重なったとき鳴らす
    public AudioClip selectButtonSound;
    //
    public AudioClip Sound;

    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        //前のシーンから現在のシーンに変わった時に鳴らす(仮)
        audioSource.PlayOneShot(Sound);
    }

    void Update()
    {

    }
    public void Event()
    {
        //カーソルとボタンが重なったとき鳴らす
        audioSource.PlayOneShot(selectButtonSound);
        //Debug.Log("イベント発生");

    }
}
