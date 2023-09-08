using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip audioClip;
        public float playedTime;    //前回再生した時間
    }
    private AudioSource[] audioSourceList = new AudioSource[40]; //AudioSourceを同時に鳴らしたい音の数だけ用意

    [SerializeField] private SoundData[] soundDatas;    //音声データの取得
    
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>(); //音声データに名前を登録
    
    [SerializeField] private float playableDistance = 0.2f;     //一度再生してから次再生出来るまでの間隔(秒)

    [HideInInspector]
    public AudioSource BGMsource = null;   //BGM用のオーディオソース格納用変数


    private void Awake()
    {
        //auidioSourceList配列の数だけAudioSourceを自分自身に生成して配列に格納
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }

        //soundDictionaryにセット
        foreach (var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    //未使用のAudioSourceの取得 全て使用中の場合はnullを返却
    private AudioSource GetUnusedAudioSource()
    {
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            if (audioSourceList[i].isPlaying == false && audioSourceList[i] != BGMsource) return audioSourceList[i];
        }

        return null; 
    }

    /// <summary>
    /// 音声データの再生
    /// </summary>
    /// <param name="clip">再生したい音声データの名前</param>
    private void Play(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //再生不可
        audioSource.clip = clip;
        audioSource.Play();
    }

    /// <summary>
    /// 音声データのループ再生
    /// </summary>
    /// <param name="clip">再生したい音声データの名前</param>
    private void BGMPlay(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //再生不可
        audioSource.clip = clip;
        audioSource.loop = true;
        if(BGMsource == null)BGMsource = audioSource;
        audioSource.Play();
    }

    /// <summary>
    ///　BGMの変更用
    /// </summary>
    /// <param name="clip"></param>
    private void ChangeBGMPlay(AudioClip clip)
    {
        var audioSource = BGMsource;
        if (audioSource == null) return; //再生不可
        audioSource.clip = clip;
        audioSource.loop = true;
        if (BGMsource == null) BGMsource = audioSource;
        audioSource.Play();
    }

    /// <summary>
    /// 登録された名前で音声データの再生
    /// </summary>
    /// <param name="name">音声データに登録した名前</param>
    public void Play(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //管理用Dictionary から、別名で探索
        {
            if (Time.realtimeSinceStartup - soundData.playedTime < playableDistance) return;    //まだ再生するには早い
            soundData.playedTime = Time.realtimeSinceStartup;//次回用に今回の再生時間の保持
            Play(soundData.audioClip); //見つかったら、再生
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }

    /// <summary>
    /// 登録された名前で音声データのループ再生
    /// </summary>
    /// <param name="name">音声データに登録した名前</param>
    public void LoopPlay(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //管理用Dictionary から、別名で探索
        {
            if (Time.realtimeSinceStartup - soundData.playedTime < playableDistance) return;    //まだ再生するには早い
            soundData.playedTime = Time.realtimeSinceStartup;//次回用に今回の再生時間の保持    
            BGMPlay(soundData.audioClip); //見つかったら、再生
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }

    /// <summary>
    /// 登録された名前で音声データのループ再生切り替え
    /// </summary>
    /// <param name="name">音声データに登録した名前</param>
    public void ChangeBGM(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //管理用Dictionary から、別名で探索
        {
            if (Time.realtimeSinceStartup - soundData.playedTime < playableDistance) return;    //まだ再生するには早い
            soundData.playedTime = Time.realtimeSinceStartup;//次回用に今回の再生時間の保持    
            ChangeBGMPlay(soundData.audioClip); //見つかったら、再生
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }
}
