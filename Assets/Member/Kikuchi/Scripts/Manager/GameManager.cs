using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public SoundManager soundManager;

    [SerializeField]
    public SceneController sceneController;

    public static GameManager GameManagerClass;

    [HideInInspector]
    public bool isEndSceneChangeFlag = false;
    [HideInInspector]
    public bool IsEndCountDown = false;

    public SceneObject titleSceneObj;
    public SceneObject prologueSceneObj;
    public SceneObject tutorialSceneObj;
    public SceneObject gameSceneObj;
    public SceneObject cutuluhuSceneObj;
    public SceneObject resultSceneObj;
    public SceneObject gameoverSceneObj;
    public SceneObject showcaseSceneObj;

    [SerializeField] public int fadeWaitTime = 1;

    public static GameObject singletonManager;



    private void Awake()
    {
        if (singletonManager == null)
        {
            singletonManager = this.gameObject;
            DontDestroyOnLoad(this.gameObject); //���g�̃I�u�W�F�N�g��j������Ȃ��悤��

            //�N���X��ϐ��Ɋi�[
            GameManagerClass = this.gameObject.GetComponent<GameManager>();
            soundManager = this.gameObject.GetComponent<SoundManager>();
            Application.targetFrameRate = 60;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        //awake��
        //start��
        sceneController.SceneControllerStart();
    }

    public void OnSceneChangeEvent(Scene scene, LoadSceneMode mode)
    {
        isEndSceneChangeFlag = true;
    }

    // Update is called once per frame
    private void Update()
    {

    }
    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }


    #region �V�[���J�ڊ֐�
    /// <summary>
    /// �^�C�g���V�[���֑J��
    /// </summary>
    public void TransitionToTitleScene()
    {
        sceneController.ChangeScene(SceneController.SceneType.toTitle);
    }
    /// <summary>
    /// �v�����[�O�V�[���֑J��
    /// </summary>
    public void TransitionToPrologScene()
    {
        sceneController.ChangeScene(SceneController.SceneType.toPrologue);
    }
    /// <summary>
    /// �`���[�g���A���V�[���֑J��
    /// </summary>
    public void TransitionToTutorialScene()
    {
        sceneController.ChangeScene(SceneController.SceneType.toTutorial);
    }
    /// <summary>
    /// ���C���Q�[���V�[���֑J��
    /// </summary>
    public void TransitionToGameScene()
    {
        sceneController.ChangeScene(SceneController.SceneType.toMainGame);
    }
    /// <summary>
    /// �N�g�D���t�퓬�V�[���֑J��
    /// </summary>
    public void TransitionToCutuluhuScene()
    {
        sceneController.ChangeScene(SceneController.SceneType.toCutuluhu);
    }
    /// <summary>
    /// ���U���g�V�[���֑J��
    /// </summary>
    public void TransitionToResultScene()
    {
        sceneController.ChangeScene(SceneController.SceneType.toResult);
    }
    /// <summary>
    /// �Q�[���I�[�o�[�V�[���֑J��
    /// </summary>
    public void TransitionToGameOverScene()
    {
        sceneController.ChangeScene(SceneController.SceneType.toGameOver);
    }
    /// <summary>
    /// Shocaseシーンへ遷移
    /// </summary>
    public void TransitionToShowCaseScene()
    {
        sceneController.ChangeScene(SceneController.SceneType.toShowCase);
    }
    
    #endregion


}
