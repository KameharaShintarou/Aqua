using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // フェードイン終了後の処理
    public void EndFadeInAnimation()
    {
        Destroy(this.gameObject);
    }
}
