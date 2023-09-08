using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SabaStats : MonoBehaviour
{
    public static int SabaPower;
    public static int SabaMaxBullet;
    public static int SabaNowBullet;
    public static float SabaFireRate;
    public static float SabaReloadTime;
    public static float SabaRandomAC;  
    public static float SabaBulletSpeed;
    public static float SabaStanTime;
    
    
    private List<string[]> csvData = new List<string[]>();  //CSVファイルの中身を入れるリスト
    void Awake()
    {
        #if UNITY_EDITOR
            StreamReader fs = new StreamReader(Application.dataPath + "/StreamingAssets/csv/SabaStats.csv");    
        #elif UNITY_STANDALONE_WIN
            StreamReader fs = new StreamReader(Application.dataPath + "/StreamingAssets/csv/SabaStats.csv");    
        #elif UNITY_STANDALONE_OSX
            StreamReader fs = new StreamReader(Application.dataPath + "/Resources/Data/StreamingAssets/csv/SabaStats.csv");    
        #endif
        {
            while (fs.Peek() != -1)
            {
                var str = fs.ReadLine();
                csvData.Add(str.Split(',')); 
            }
            var fireRate = 1 / float.Parse(csvData[0][2]);

            Debug.Log(fireRate);
            SabaPower = int.Parse(csvData[0][0]);
            SabaMaxBullet = int.Parse(csvData[0][1]);
            SabaFireRate = fireRate;
            SabaReloadTime = float.Parse(csvData[0][3]);
            SabaRandomAC = float.Parse(csvData[0][4]);
            SabaBulletSpeed = float.Parse(csvData[0][5]);
            SabaStanTime = float.Parse(csvData[0][6]);

            SabaNowBullet = SabaMaxBullet;
        }
    }

}
