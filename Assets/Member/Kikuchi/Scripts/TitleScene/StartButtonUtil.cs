using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartButtonUtil : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image startButton;

    //ボタンの明滅周期設定用変数
    [SerializeField]
    [Header("スタートボタンの明滅周期")]
    private float blinkTime = 1;
    [SerializeField]
    [Header("スタートボタンの透明度下限")]
    private float blinkAlphaUnderLimit = 0.1f;
    [SerializeField]
    [Header("ボタンにかーそるが載ってる時の拡大率")]
    private float buttonScaleSize = 1.5f;

    //ボタンの明滅切り替え、停止用フラグ
    private bool isBlinkStopFlag = false;
    private bool isBlinkOut = true;

    private float startButtonHeight = 0;
    private float startButtonWidth = 0;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GetComponent<Image>();
        startButtonHeight = startButton.rectTransform.rect.height;
        startButtonWidth = startButton.rectTransform.rect.width;
    }
    // Update is called once per frame
    void Update()
    {
        ButtonBlink();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isBlinkStopFlag = true;
        startButton.color = new Color(255f, 255f, 255f, 1f);
        startButton.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, startButtonWidth * buttonScaleSize);
        startButton.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, startButtonHeight * buttonScaleSize);
    }

    //ボタンの上からカーソルが外れた時、明滅を再開する
    public void OnPointerExit(PointerEventData eventData)
    {
        isBlinkStopFlag = false;
        isBlinkOut = true;
        startButton.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, startButtonWidth);
        startButton.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, startButtonHeight);
    }

    /// <summary>
    /// スタートボタンの明滅処理
    /// </summary>
    private void ButtonBlink()
    {
        if (isBlinkStopFlag) return;
        if (isBlinkOut)
        {
            startButton.color = new Color(255f, 255f, 255f, startButton.color.a - Time.deltaTime / blinkTime);
            if (startButton.color.a <= blinkAlphaUnderLimit) isBlinkOut = false;
        }
        else
        {
            startButton.color = new Color(255f, 255f, 255f, startButton.color.a + Time.deltaTime / blinkTime);
            if (startButton.color.a >= 1f) isBlinkOut = true;
        }

    }
}

