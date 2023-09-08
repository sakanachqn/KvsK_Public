using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField]
    private EnemySponePoollManager poolManager;
    [SerializeField]
    private bool useObjectPool = true;

    private int count;              // 生成が何回回ったか
    private int num;                // スポーン回数の計算用
    private int spownPointCount;    // スポーンポイントの生成順を記録

    private float enemySpownTime;   // スポーン時間
    private int firstEnemy;         // 敵の出現数
    private int spownCountCounter;  // 何回ごとに敵を増やすか
    private float spownDis;
    private int spownCountUp;       // 敵の増える数
    [SerializeField]
    private List<int> enemyShoggoth = new List<int>();
    [SerializeField]
    private List<int> enemyDropOfStars = new List<int>();
    private List<string[]> csvData = new List<string[]>();  //CSVファイルの中身を入れるリスト
    private WaitForSeconds spownWait;// スポーン時間のキャッシュ化
    [SerializeField]
    private List<GameObject> enemyObj = new List<GameObject>();    // 敵のprefab入れる
    [SerializeField]
    private List<GameObject> spownPoint = new List<GameObject>();  // スポーンポイントを入れる
    private List<CameraRange> cameraRange = new List<CameraRange>();

    // Start is called before the first frame update
    void Start()
    {
        count = 1;
        num = 1;
        SetUp();
        StartCoroutine(EnemyGenerationSetUp());
        StartCoroutine(Generation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUp()
    {
        for(int i = 0; i < spownPoint.Count;i++)
        {
            cameraRange.Add(spownPoint[i].GetComponent<CameraRange>());
        }
    }


    public IEnumerator EnemyGenerationSetUp()
    {
        Debug.Log("-----EnemyGenerationSetUp Start-----");
        csvData.Clear();
        #if UNITY_EDITOR
            StreamReader fs = new StreamReader(Application.dataPath + "/StreamingAssets/csv/EnemySpown.csv");    
        #elif UNITY_STANDALONE_OSX
            StreamReader fs = new StreamReader(Application.dataPath + "/Resources/Data/StreamingAssets/csv/EnemySpown.csv");    
        #elif UNITY_STANDALONE_WIN
            StreamReader fs = new StreamReader(Application.dataPath + "/StreamingAssets/csv/EnemySpown.csv");    
        #endif
        {
            while (fs.Peek() != -1)
            {
                var str = fs.ReadLine();
                csvData.Add(str.Split(',')); 
            }

            enemySpownTime = float.Parse(csvData[1][0]);
            firstEnemy = int.Parse(csvData[1][1]);
            spownCountCounter = int.Parse(csvData[1][2]);
            spownCountUp = int.Parse(csvData[1][3]);
            spownDis = float.Parse(csvData[1][4]);

        }
        fs.Close();
        csvData.Clear();
        #if UNITY_EDITOR
            StreamReader sr = new StreamReader(Application.dataPath + "/StreamingAssets/csv/SpownRaito.csv");    
        #elif UNITY_STANDALONE_OSX
            StreamReader sr = new StreamReader(Application.dataPath + "/Resources/Data/StreamingAssets/csv/SpownRaito.csv");    
        #elif UNITY_STANDALONE_WIN
            StreamReader sr = new StreamReader(Application.dataPath + "/StreamingAssets/csv/SpownRaito.csv");    
        #endif
        {
            while (sr.Peek() != -1)
            {
                var str = sr.ReadLine();
                csvData.Add(str.Split(',')); 
            }

            for(int i = 1; i < csvData.Count;i++)
            {
                enemyShoggoth.Add(int.Parse(csvData[i][0]));
                enemyDropOfStars.Add(int.Parse(csvData[i][1]));
            }
        }
        sr.Close();
        Debug.Log("-----EnemyGenerationSetUp End-----");
        yield return null;
    }

    IEnumerator Generation()
    {
        
        // スポーンウェイト
        spownWait = new WaitForSeconds(enemySpownTime);
        yield return spownWait;
        yield return null;
        while(true)
        {
            // スポーンポイントが増えても動作可能
            for(int i = 0; i < spownPoint.Count;i++)
            {
                var dis = cameraRange[i].RangeFinder();
                
                if(dis < spownDis)
                    continue;
                // firstEnemy分回す
                for(int j = 0; j < firstEnemy;j++)
                {
                    // 星の落とし子が最優先
                    // その後ショゴス 
                    // 残り
                    if(enemyDropOfStars[count] != 0)
                    {
                        enemyDropOfStars[count]--;
                        EnemyPick(2,i);
                    }
                    else if(enemyShoggoth[count] != 0)
                    {
                        enemyShoggoth[count]--;
                        EnemyPick(1,i);
                    }
                    else
                    {
                        EnemyPick(0,i);
                    }
                    
                }

            }
            count++;
            if(count == spownCountCounter * num)
            {  
                firstEnemy += spownCountUp;
                num++;
            }
            yield return spownWait;
//            Debug.Log("Wait終了");
        }
    }

    // 引数に応じて生成するEnemyと場所を選択
    void EnemyPick(int i ,int j)
    {
        Debug.Log("生成!");
        poolManager.GetGameObject(i, spownPoint[j].transform.position, Quaternion.identity);
        //Instantiate(enemyObj[i],spownPoint[j].transform.position,Quaternion.identity);
    } 
}

/*
敵の各スクリプトに追記or修正
// 上に宣言
[SerializeField]
private EnemySponePoollManager poolManager;

// 破壊処理
// intの番号
// Fishingman 0 , Shoggoth 1 , Offspring 2
poolManager.ReleaseGameObject(this.gameObject,ここにintの番号)
*/