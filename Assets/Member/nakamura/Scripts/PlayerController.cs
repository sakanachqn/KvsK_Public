using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;//�������x
    [SerializeField]
    private float runSpeed;//���鑬�x
    private float inputX, inputZ;//x�������Az�������̓��͂̕ۑ�
    private float distance;//�ړ������p

    [SerializeField]
    private float deceleration;//���x������
    [SerializeField]
    private float decelerationTime;//�������ʎ���
    private float attenuation;//������
    private float decelerationCompaTime;//��r�p����
    private float decelerationReset;//�ēx���x�����ʂ�����p
    [SerializeField]
    private ParticleSystem dashEffect;

    public static bool DASH;

    //Kikuchi
    [SerializeField]
    [Header("Playerの視線方向")]
    private Transform crosshair;

    [SerializeField]
    private Transform player;
    
    public static GameObject PlayerGameObject;

    private Vector3 latestPos;  
    
    private PlayerAnim anim;

    [SerializeField]
    private SceneStartDelay CSD;

    void Awake()
    {
        PlayerGameObject = this.gameObject;
    }

    void Start()
    {
        attenuation = (1f - deceleration) / decelerationTime;//減速の計算
        decelerationReset = deceleration * 1;
        decelerationCompaTime = 0;

        if(anim == null)
        {
            anim = GetComponent<PlayerAnim>();
        }

    }

    void Update()
    {
        if(!CSD.IsDelay || CthulhuManager.IsDead) return;
        MovePlayer();//�v���C���[�̈ړ�����
    }

    public void MovePlayer()
    {
        latestPos = this.transform.position; // 移動前の座標
        //x�������Az�������̓��͂̎擾
        inputX = Input.GetAxis("Horizontal");//�����A������
        inputZ = Input.GetAxis("Vertical");//�����A�c����
        //�ړ��̌����Ȃǂ̍��W�֘A
        Vector3 velocity = new Vector3(inputX, 0, inputZ);

        //�x�N�g���̌����̎擾
        Vector3 direction = velocity.normalized;

        //�ړ������̌v�Z
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            DASH = true;
            if (HpInvinciblyManager.IsDeceleration)
                distance = runSpeed * Time.deltaTime * deceleration;//����
            else
                distance = runSpeed * Time.deltaTime;//��������
            
        }
        else
        {
            DASH = false;
            if (HpInvinciblyManager.IsDeceleration)
                distance = walkSpeed * Time.deltaTime * deceleration;//����
            else
                distance = walkSpeed * Time.deltaTime;//��������
        }


        //減速
        if (HpInvinciblyManager.IsDeceleration)
        {
            //���G���Ԉȓ��Ȃ�
            if (decelerationCompaTime < decelerationTime)
            {
                decelerationCompaTime += Time.deltaTime;
                deceleration += attenuation * 0.01f;
            }//�������ʎ��Ԉȏ�Ȃ�
            else if (decelerationCompaTime >= decelerationTime)
            {
                HpInvinciblyManager.IsDeceleration = false;//����𖳂���
                decelerationCompaTime = 0;//���Ԃ����Z�b�g
                deceleration = decelerationReset;//���x�����ʂ�����
            }
            if (deceleration >= 1) deceleration = 1;
        }

        //�ړ���̌v�Z
        Vector3 destination = transform.position + direction * distance;


        if(DASH)
        {
            dashEffect.transform.rotation = Quaternion.Euler(direction.z * 90f,0f,-direction.x * 90f);
            dashEffect.Play();
        }
        else
            dashEffect.Stop(true, ParticleSystemStopBehavior.StopEmitting);



        //�ړ���Ɍ������ĉ�]
        //transform.LookAt(new Vector3(lookPos.position.x, 0f, lookPos.position.z));

        //正面方向の設定
        SetFoward();

        //�ړ���̍��W�̐ݒ�
        transform.position = destination;

        anim.PosAnimCheck(latestPos);
            
    }

    /// <summary>
    /// Playerの正面方向をCrosshiarの方へ向ける
    /// </summary>
    public void SetFoward()
    {
        player.transform.rotation = Quaternion.FromToRotation(player.transform.forward,crosshair.transform.position - player.transform.position) * player.transform.rotation;
        this.transform.rotation = Quaternion.Euler(0.0f, player.transform.eulerAngles.y, 0.0f);
    }


}
