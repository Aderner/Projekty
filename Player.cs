using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Stats health ;
    [SerializeField]
    private Stats energy;
    [SerializeField]
    private Stats mana;

    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float maxEnergy = 50;
    [SerializeField]
    private float maxMana = 100;

    public Animator animator;

  


    protected override void Start()
    {
        health.Initialize(maxHealth, maxHealth);
        energy.Initialize(maxEnergy, maxEnergy);
        mana.Initialize(maxMana, maxMana);
        base.Start();
    }
    protected override void Update()
    {
        GetInput();
        
        base.Update();

        // Czesc kodu odpowiadajaca za zbieranie danych o kierunku ruchu gracza
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }
    private void GetInput()
    {
        direction = Vector2.zero;

        ///DEBUG ONLY
        ///

        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            energy.MyCurrentValue += 10;
            mana.MyCurrentValue += 50;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            health.MyCurrentValue -= 10;
 
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            energy.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            mana.MyCurrentValue -= 10;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector2.right;
            }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAttacking && !IsMoving)
            {
                attackRoutine = StartCoroutine(Attack());
            }
            

        }

    }

    public IEnumerator Attack()
    {


        isAttacking = true;
        energy.MyCurrentValue -= 1;
        MyAnimator.SetBool("attack", isAttacking);

        yield return new WaitForSeconds(0.5f); //Dla debugera !
        Debug.Log("Attack done");
        StopAttack();


    }


}
