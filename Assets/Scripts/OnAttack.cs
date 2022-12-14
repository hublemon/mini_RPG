using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttack : MonoBehaviour
{
    List<string> attacks = new List<string>();

    Animator attackAnimator;

    [SerializeField]
    GameObject monsterEntity;

    public GameObject Effect1;
    public GameObject Effect2;
    public GameObject Effect3;

    LivingEntity monster;

    RaycastHit hit;

    //마우스왼쪽 버튼으로 공격
    //애니매이션 상태보고 다른 공격 나가기
    // Start is called before the first frame update
    void Start()
    {
        attacks.Add("Attack1");
        attacks.Add("Attack2");
        attacks.Add("Attack3");
        attackAnimator = GetComponent<Animator>();
        monster = monsterEntity.GetComponent<LivingEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        Hit();
    }

    public void StartAttack()

        //믹사모 스킨 같이 가져왔으면 이벤트함수가능한데, 아쉽다
    {
        if (attackAnimator.GetCurrentAnimatorStateInfo(0).IsName(attacks[0]) && attackAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.6f+Time.deltaTime &&
                attackAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f)
        {
            Debug.Log(attacks[0]);
            //monster.TakeHit(50, hit);
            GameObject effect1=Instantiate(Effect1, hit.transform);
            effect1.transform.position += effect1.transform.up*1.5f;
            Destroy(effect1, 1.4f);


        }
        if (attackAnimator.GetCurrentAnimatorStateInfo(0).IsName(attacks[1]) && attackAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.6f + Time.deltaTime &&
                attackAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f)
        {
            Debug.Log(attacks[1]);
            //monster.TakeHit(70, hit);
            GameObject effect2=Instantiate(Effect2, hit.transform);
            effect2.transform.position += effect2.transform.up*1.5f;
            Destroy(effect2, 1.4f);

        }
        if (attackAnimator.GetCurrentAnimatorStateInfo(0).IsName(attacks[2]) && attackAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.6f + Time.deltaTime &&
                attackAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.6f)
        {
            Debug.Log(attacks[2]);
            //monster.TakeHit(100, hit);
            GameObject effect3=Instantiate(Effect3, hit.transform);
            effect3.transform.position += effect3.transform.up*1.5f;
            Destroy(effect3, 1.4f);
        }
    }
    void Hit()
    {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200f))
            {
                if (hit.collider.tag == "Monster")
                {
                    StartAttack();
                }
            }
        
    }
    
}
