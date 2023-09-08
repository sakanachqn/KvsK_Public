using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneChangeButtonController : MonoBehaviour, IPointerDownHandler
{

    [SerializeField]
    private SceneController.SceneType toSceneType;

    public void OnPointerDown(PointerEventData eventData)
    {
        switch(toSceneType)
        {
            case SceneController.SceneType.toTitle:
                {
                    GameManager.GameManagerClass.TransitionToTitleScene();
                }
                break;
            case SceneController.SceneType.toPrologue:
                {
                    GameManager.GameManagerClass.TransitionToPrologScene();
                }
                break;
            case SceneController.SceneType.toTutorial:
                {
                    GameManager.GameManagerClass.TransitionToTutorialScene();
                }
                break;
            case SceneController.SceneType.toMainGame:
                {
                    GameManager.GameManagerClass.TransitionToGameScene();
                }
                break;
            case SceneController.SceneType.toCutuluhu:
                {
                    GameManager.GameManagerClass.TransitionToCutuluhuScene();
                }
                break;
            case SceneController.SceneType.toResult:
                {
                    GameManager.GameManagerClass.TransitionToResultScene();
                }
                break;
            case SceneController.SceneType.toGameOver:
                {
                    GameManager.GameManagerClass.TransitionToGameOverScene();
                }
                break;
            case SceneController.SceneType.toShowCase:
                {
                    GameManager.GameManagerClass.TransitionToShowCaseScene();
                }
                break;

            default:
                break;
        }
    }


}
