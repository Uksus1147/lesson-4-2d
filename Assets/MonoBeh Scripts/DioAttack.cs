using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioAttack : MonoBehaviour
{
    public Animator animator;
    public Transform atackPoint;
    public LayerMask enemyLayer;
    public float ranger = 0.5f;
    public float PowerTime = 0;
    private float StopTime = 11;
    public GameObject Jotaro;
    public AudioSource wryy;
    public AudioSource MUDA;
    public AudioSource ZaWardo;
    public AudioSource TimeCont;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
            MUDA.Play();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackLeg();
            MUDA.Play();

        }
        if (Input.GetKey(KeyCode.V))
        {
            Power();
            wryy.Play();
        }
        if (PowerTime >= 25)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ZaWarudoStopTime();
                ZaWardo.Play();
            }
        }
    }
    void Attack()
    {
        animator.SetTrigger("hit arm");
        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(atackPoint.position, ranger, enemyLayer);
        foreach(Collider2D enemy in hitenemy)
        {
            enemy.GetComponent<Jotaro>().Takedamage(20);
        }
    }
    void AttackLeg()
    {
        animator.SetTrigger("hit leg");
        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(atackPoint.position, ranger, enemyLayer);
        foreach (Collider2D enemy in hitenemy)
        {
            enemy.GetComponent<Jotaro>().Takedamage(30);
        }
    }
    void Power()
    {
        PowerTime = PowerTime + Time.deltaTime;
        animator.SetTrigger("PowerAcc");
    }
    void ZaWarudoStopTime()
    {
        PowerTime = PowerTime - 25;
        animator.SetTrigger("StopTime");
        Jotaro.GetComponent<Jotaro>().InStopTime(true);
        TimeToContinue();
    }
    void TimeToContinue()
    {
        Invoke("TimeToContinueController", StopTime);
    }
    void TimeToContinueController()
    {
        TimeCont.Play();
        Jotaro.GetComponent<Jotaro>().InStopTime(false);
        
    }
    void OnDrawGizmos()
    {
        if (atackPoint == null)
            return;
        Gizmos.DrawWireSphere(atackPoint.position, ranger); 
    }
}
