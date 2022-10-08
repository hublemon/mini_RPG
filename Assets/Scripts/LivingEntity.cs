using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamagable
{
    //�������׸� �ϴ� �ֱ�

    [SerializeField]
    float startHP = 200;

    protected float health;
    protected bool dead;

    Animator beingAttackAnimator;

    public void TakeHit(float damage, RaycastHit hit)    //�ٸ����� �޴� �Ŷ� public�ؾ���
    {
        health -= damage;
        beingAttackAnimator.SetTrigger("beingAttack");

        if (health <= 0 & !dead)
        {
            beingAttackAnimator.SetTrigger("Die");
            Invoke("Die()", 2.5f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        health = startHP;
        beingAttackAnimator = GetComponent<Animator>();
    }

    void Die()
    {
        dead = true;
        GameObject.Destroy(gameObject);
    }

}
