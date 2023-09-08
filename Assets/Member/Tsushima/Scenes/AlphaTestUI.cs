using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlphaTestUI : MonoBehaviour
{
    private static int hp;
    
    private  static TextMeshProUGUI playerHp;
    [SerializeField]
    private TextMeshProUGUI sabaText;
    [SerializeField]
    private TextMeshProUGUI kazikiText;

    public void BulletTextUpdate() 
    {
        sabaText.text = SabaStats.SabaNowBullet + "/" + SabaStats.SabaMaxBullet;
        kazikiText.text = KazikiStats.KazikiNowBullet + "/" + KazikiStats.KazikiMaxBullet;
    }

    public static void PlayerTextUpdate()
    {
        playerHp.text = HpInvinciblyManager.PlayerHp + "/" + hp;
    }

    // Start is called before the first frame update
    void Start()
    {

        var obj = GameObject.Find("PlayerHP");
        playerHp = obj.GetComponent<TextMeshProUGUI>();

        hp = HpInvinciblyManager.PlayerHp;

        playerHp.text = HpInvinciblyManager.PlayerHp + "/" + HpInvinciblyManager.PlayerHp;
        sabaText.text = SabaStats.SabaNowBullet + "/" + SabaStats.SabaMaxBullet;
        kazikiText.text = KazikiStats.KazikiNowBullet + "/" + KazikiStats.KazikiMaxBullet;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
