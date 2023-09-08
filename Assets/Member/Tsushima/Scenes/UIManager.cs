using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;  // インスタンス
    [SerializeField]
    private List<GameObject> hpImg = new List<GameObject>();    // HPイメージ
    [SerializeField]
    private TextMeshProUGUI sabaText;   // サバ残弾テキスト
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject kazikiObj;       // カジキの画像UI切り替え
    [SerializeField]
    private Slider sabaSlider;          // プレイヤー下の残弾ゲージ
    private bool kazikiFlag;            // スイッチ切り替え
    
    private int score;

    void Start()
    {

        uiManager = this.gameObject.GetComponent<UIManager>();  // インスタンス格納
        InitUI();
    }
    public void InitUI()
    {
        kazikiFlag = true;              // 初期設定
        sabaText.text = SabaStats.SabaNowBullet + "/" + SabaStats.SabaMaxBullet;    // 初期化
        sabaSlider.maxValue = SabaStats.SabaMaxBullet;  // 初期設定
        sabaSlider.value = SabaStats.SabaNowBullet;     // 初期化
        score = 0;
    }

    // 弾関連更新
    public void BulletTextUpdate() 
    {
        // マガジン内 / 最大装填数
        // でテキスト更新
        sabaText.text = SabaStats.SabaNowBullet + "/" + SabaStats.SabaMaxBullet;
        // スライダーの値更新
        sabaSlider.value = SabaStats.SabaNowBullet;
    }

    // プレイヤーのHP更新
    public void PlayerHpUpdate()
    {
        // 減少処理の後に起動
        // HPIMGをActive(false)
        if(HpInvinciblyManager.PlayerHp <= -1) return;
        hpImg[HpInvinciblyManager.PlayerHp].SetActive(false);
    }

    // カジキ画像更新
    public void KazikiUpdate()
    {
        // kaziki残弾があるかどうか
        if(kazikiFlag)  // 発射
        {
            kazikiFlag = false;
            kazikiObj.SetActive(false);
        }
        else            // 水着シロコEX(釣り)
        {
            kazikiFlag = true;
            kazikiObj.SetActive(true);
        }
    }

    public void ScoreUpdate()
    {
        /*
        score++;
        BetaUI.score = score;
        if(score > 99999)
            scoreText.text = score.ToString();
        else
            scoreText.text = score.ToString();
        */
        StartCoroutine(ScoreAnimation(1,0.5f));
    }
    IEnumerator ScoreAnimation(int addScore, float time)
    {
        //前回のスコア
        int befor = BetaUI.score;
        //今回のスコア
        int after = befor + addScore;
        //得点加算
        BetaUI.score += addScore;
        //0fを経過時間にする
        float elapsedTime = 0.0f;

        //timeが０になるまでループさせる
        while (elapsedTime < time)
        {
            float rate = elapsedTime / time;
            // テキストの更新
            scoreText.text = (befor + (after - befor) * rate).ToString("f0");

            elapsedTime += Time.deltaTime;
            // 0.01秒待つ
            yield return new WaitForSeconds(0.01f);
        }
        // 最終的な着地のスコア
        scoreText.text = after.ToString();
    }

    public void CutuluhuScore(int i)
    {
        if(i == 0)
        {
            scoreText.text = BetaUI.score.ToString();
            return;
        }
        /*
        BetaUI.score += i;
        if(score > 99999)
            scoreText.text = BetaUI.score.ToString();
        else
            scoreText.text = BetaUI.score.ToString();
        */
        StartCoroutine(ScoreAnimation(i,0.5f));
    }
}