using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KazikiStats : MonoBehaviour
{
    public static int KazikiPower;
    public static int KazikiMaxBullet;
    public static int KazikiNowBullet;
    public static float KazikiChargeTime;
    public static float KazikiBulletSpeed;
    public static float KazikiStanTime;
    
    private List<string[]> csvData = new List<string[]>();  //CSVファイルの中身を入れるリスト
    void Awake()
    {
        #if UNITY_EDITOR
            StreamReader fs = new StreamReader(Application.dataPath + "/StreamingAssets/csv/KazikiStats.csv");    
        #elif UNITY_STANDALONE_OSX
            StreamReader fs = new StreamReader(Application.dataPath + "/Resources/Data/StreamingAssets/csv/KazikiStats.csv");    
        #elif UNITY_STANDALONE_WIN
            StreamReader fs = new StreamReader(Application.dataPath + "/StreamingAssets/csv/KazikiStats.csv");    
        #endif
        {
            while (fs.Peek() != -1)
            {
                var str = fs.ReadLine();
                csvData.Add(str.Split(',')); 
            }
            KazikiPower = int.Parse(csvData[0][0]);
            KazikiMaxBullet = int.Parse(csvData[0][1]);
            KazikiChargeTime = float.Parse(csvData[0][2]);
            KazikiBulletSpeed = float.Parse(csvData[0][4]);
            KazikiStanTime = float.Parse(csvData[0][5]);
            KazikiNowBullet = KazikiMaxBullet;
        }
    }
}
