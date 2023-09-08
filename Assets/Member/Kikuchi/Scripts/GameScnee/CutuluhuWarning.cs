using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CutuluhuWarning : MonoBehaviour
{
    [SerializeField]
    private Canvas prefabCanvas;
    private CanvasGroup canvasGroup = null;

    [SerializeField][Header("明滅周期")]
    private float blinkCycle = 1;
    [SerializeField][Header("表示時間")]
    private float warningTime = 3;

    private float blinkTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        //キャンバスグループの取得
        canvasGroup = prefabCanvas.GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// キャンバスアクティブ→明滅処理
    /// </summary>
    public void CutuluhuWarnigBlink()
    {
        prefabCanvas.gameObject.SetActive(true);
        Blink();
    }
    /// <summary>
    /// 明滅処理関数
    /// </summary>
    private async void Blink()
    {
        //設定した時間になるまで繰り返す
        while (blinkTime <= warningTime)
        {
            //経過時間格納
            blinkTime += Time.deltaTime;
            //処理タイミングを同期
            await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken: this.GetCancellationTokenOnDestroy());
            //明滅するための透明度設定
            var alpha = Mathf.Sin(2 * Mathf.PI * blinkTime / blinkCycle) * 0.5f + 0.5f;
            //透明度代入
            canvasGroup.alpha = alpha;
        }
        //初期化
        blinkTime = 0;
        prefabCanvas.gameObject.SetActive(false);
    }
}
