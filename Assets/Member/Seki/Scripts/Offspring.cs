using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;


//�[�����̂ǂ�
public class Offspring : MonoBehaviour
{
    //�p�����[�^�[
    [SerializeField] int EHp = 50;
    [SerializeField] float Range=0.1f;

    [SerializeField]
    private EnemySponePoollManager poolManager;

    private bool stan;

    public GameObject target;
    private NavMeshAgent agent;
    public bool OffspringMove = true;

    [SerializeField]
    private GameObject deathEffect;

    [SerializeField]
    private Renderer renderer;
    private float lightTimer;


    void Start()
    {
  
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = true;
        poolManager = EnemySponePoollManager.enemySponePoolManager;

    }

    // Update is called once per frame
    void Update()
    {
        if(stan) return;

        //�ǐ�AI
        /*
        if (target)
        {
            agent.SetDestination(PlayerController.PlayerGameObject.transform.position);
        }
        */
        agent.SetDestination(PlayerController.PlayerGameObject.transform.position);

        if(lightTimer != 0f)
        {
            lightTimer += Time.deltaTime;
            if(lightTimer > 0.3f)
            {
                renderer.material.SetFloat("_RimLight", 0f);
                lightTimer = 0f;
            }

        }


        //�U���͈͓��̎��ɐÎ~
        float dis = Vector3.Distance(this.transform.position, PlayerController.PlayerGameObject.transform.position);
        if (dis <Range)
        {
            OffspringMove = false;
            agent.isStopped = true;
            //Vector3 vector3 = target.transform.position - this.transform.position;
            

            this.transform.LookAt(PlayerController.PlayerGameObject.transform);
        }
        else
        {
            OffspringMove = true;
            agent.isStopped = false;
        }

        //HP0�Ŏ�
        if (EHp <= 0)
        {
            EHp = 30;
            GameManager.GameManagerClass.soundManager.Play("EnemyDie");
            if (poolManager != null)
            {
                var eff = Instantiate(deathEffect, this.transform.position, Quaternion.identity);
                poolManager.OnReleaseToPool3(this.gameObject);
            }
            else
            {
                var eff = Instantiate(deathEffect, this.transform.position, Quaternion.identity);

                Destroy(this.gameObject);
            }
        }
    }
    private IEnumerator MackrelAttack()
    {
        stan = true;
        agent.isStopped = true;
        EHp -= SabaStats.SabaPower;
        yield return new WaitForSeconds(SabaStats.SabaStanTime);
        agent.isStopped = false;
        stan = false;
    }


    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.tag == "Player")
        {         
            HpInvinciblyManager.IsDeceleration = true;
        }
        if (Other.gameObject.tag == "Mackrel")
        {
            var saba = Other.gameObject.GetComponent<SabaResidue>();
            saba.boxCollider.enabled = false;
            StartCoroutine(saba.fixedSaba("Enemy"));
            StartCoroutine(RimLightSet());
            StartCoroutine(MackrelAttack());

            //Other.transform.parent.gameObject.SetActive(false);
        }
        else if(Other.gameObject.tag == "SwordFish")
        {
            StartCoroutine(RimLightSet());
            EHp -= KazikiStats.KazikiPower;
        }
    }

    private IEnumerator RimLightSet()
    {
        renderer.material.SetFloat("_RimLight", 1f);
        lightTimer = 0.1f;
        yield break;
    }

}
