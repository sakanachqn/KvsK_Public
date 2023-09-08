using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject fadePrefab;
    private GameObject fadeCanvas;
    private bool flag;

    FadeController fadeController;


    /// <summary>
    /// �V�[���J�ڐ�w��p
    /// </summary>
    public enum SceneType
    {
        toTitle,
        toPrologue,
        toTutorial,
        toMainGame,
        toCutuluhu,
        toResult,
        toGameOver,
        toShowCase
    }

    

    /// <summary>
    /// �V�[���R���g���[���[�̏���������
    /// </summary>
    public void SceneControllerStart()
    {
        fadeCanvas = Instantiate(fadePrefab, gameObject.transform); //�t�F�[�h�L�����o�X�̐���
        fadeController = fadeCanvas.GetComponent<FadeController>(); //�X�N���v�g�̎擾
        fadeCanvas.SetActive(false);    //�t�F�[�h�L�����o�X�̔�A�N�e�B�u��(�g�����ɃA�N�e�B�u��)
        SceneManager.sceneLoaded += GameManager.GameManagerClass.OnSceneChangeEvent;
    }


    /// <summary>
    /// �V�[���J�ڗp�֐�
    /// ����:�J�ڐ�V�[����(enum)
    /// </summary>
    /// <param name="sceneType">�J�ڐ�V�[����(enum)</param>
    public void ChangeScene(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.toTitle: FadeToSceneChange(GameManager.GameManagerClass.titleSceneObj); break;
            case SceneType.toPrologue: FadeToSceneChange(GameManager.GameManagerClass.prologueSceneObj); break;
            case SceneType.toTutorial: FadeToSceneChange(GameManager.GameManagerClass.tutorialSceneObj); break;
            case SceneType.toMainGame: FadeToSceneChange(GameManager.GameManagerClass.gameSceneObj); break;
            case SceneType.toCutuluhu: FadeToSceneChange(GameManager.GameManagerClass.cutuluhuSceneObj); break;
            case SceneType.toResult: FadeToSceneChange(GameManager.GameManagerClass.resultSceneObj); break;
            case SceneType.toGameOver: FadeToSceneChange(GameManager.GameManagerClass.gameoverSceneObj); break;
            case SceneType.toShowCase: FadeToSceneChange(GameManager.GameManagerClass.showcaseSceneObj); break;
            default: break;
        }
    }


    /// <summary>
    /// �t�F�[�h�y�уV�[���J�ڏ���
    /// </summary>
    /// <param name="sceneName"></param>
    private async void FadeToSceneChange(SceneObject sceneName)
    {
        if(flag) return;
        flag = true;
        fadeCanvas.SetActive(true); //�t�F�[�h�L�����o�X�̃A�N�e�B�u��
        fadeController.Fade(FadeController.FadeType.FadeOut);   //�t�F�[�h�A�E�g����
        await UniTask.WaitUntil(() => fadeController.isEndFadeOut, cancellationToken: this.GetCancellationTokenOnDestroy());    //�t�F�[�h�A�E�g���I���܂ő҂�
        fadeController.isEndFadeOut = false;    //�t���O�̏�����
        SceneManager.LoadScene(sceneName);  //�V�[���J��
        await UniTask.WaitUntil(() => GameManager.GameManagerClass.isEndSceneChangeFlag, cancellationToken: this.GetCancellationTokenOnDestroy());
        GameManager.GameManagerClass.isEndSceneChangeFlag = false;
        await UniTask.Delay(TimeSpan.FromSeconds(GameManager.GameManagerClass.fadeWaitTime));
        fadeController.Fade(FadeController.FadeType.FadeIn);    //�t�F�[�h�C������
        await UniTask.WaitUntil(() => fadeController.isEndFadeIn, cancellationToken: this.GetCancellationTokenOnDestroy()); //�t�F�[�h�C�����I���܂ő҂�
        fadeController.isEndFadeIn = false; //�t���O�̏�����
//        CursorManager.cursorManager.CursorUpdate();
        fadeCanvas.SetActive(false);    //�t�F�[�h�L�����o�X�̔�A�N�e�B�u��
        flag = false;
    }









}
