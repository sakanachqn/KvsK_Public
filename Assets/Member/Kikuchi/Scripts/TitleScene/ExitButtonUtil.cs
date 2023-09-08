using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButtonUtil : MonoBehaviour, IPointerDownHandler
{
    /// <summary>
    /// Exitボタンが押されたら終了する処理
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
                                        Application.Quit();//ゲームプレイ終了
        #endif
    }



}
