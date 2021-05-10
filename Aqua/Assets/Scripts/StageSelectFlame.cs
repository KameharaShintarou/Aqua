//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class StageSelectFlame : MonoBehaviour
//{
//    const float FlameCountMax = 2;

//    const float FlameCountMin = 0;

//    float FlameCount = 0;


//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetButtonDown("left"))
//        {
//            FlameCount++;
//        }
//        if (Input.GetKey("RaightArrow"))
//        {
//            FlameCount--;
//        }

//        FlameCount = System.Math.Min(FlameCount, FlameCountMax);
//        // 最小値を下回ったら最小値を渡す
//        FlameCount = System.Math.Max(FlameCount, FlameCountMin);

//        // transformを取得
//        Transform myTransform = this.transform;

//        // 座標を取得
//        Vector3 pos = myTransform.position;

//        myTransform.position = pos;  // 座標を設定
//        if (FlameCount == 1)
//        {
//            pos.x += -600f;   
//        }
//        else if(FlameCount == 2)
//        {
//            pos.x += 600f;
//        }
//        else if (FlameCount == 3)
//        {
//            pos.x += 600f;
//        }

//    }
//}
