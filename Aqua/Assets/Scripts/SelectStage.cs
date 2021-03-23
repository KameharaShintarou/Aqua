using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// 「ステージ選択」画面の進行を制御します。
public class SelectStage : MonoBehaviour
{


    // 各ステージボタンをクリックした際に呼び出されます。
    public void OnClickStageButton(int stageNo)
    {
        //// ステージ番号からシーン名を作成して読み込む。
        //var sceneName = string.Format("Stage{0}", stageNo);
        //SceneManager.LoadScene(sceneName);

        //TODO: 現在Stageシーンのみなため一時的にこちらを使用する
        SceneManager.LoadScene("Stage");
    }
}
