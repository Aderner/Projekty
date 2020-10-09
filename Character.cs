using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed;
    protected Animator MyAnimator;
    protected bool isAttacking = false;
    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

 
    protected Vector2 direction;

    private Rigidbody2D rb;





    // Start is called before the first frame update
    protected Coroutine attackRoutine;
    protected virtual void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
    }

    protected virtual void Update ()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        //Player movement script
        rb.velocity = direction.normalized * speed;


    }
        public void HandleLayers()
        {
        //Sprawddza czy nasza postać się porusza czy stoi
        // is Moving w Get 
        if (IsMoving)
        {


            ActivateLayer("WalkLayer");



            // aktualizuje parametry animacji tak aby 
            // twarz postaci była w odpowiednim miejscu

            MyAnimator.SetFloat("Horizontal", direction.x);
            MyAnimator.SetFloat("Vertical", direction.y);

            StopAttack();
        }


         else if (isAttacking)
         {
             ActivateLayer("AttackLayer");
         }

        else
        {
            // Sprawia że wracamy do pozycji spoczynku gdy
            // nie naciskamy żadnego przycisku

            ActivateLayer("IdleLayer");

        }
    }
    //konstruktor pozwala nam na szybkie wyświetlanie naszych animacji
    //po nazwie np.( .....ActivateLayer("Layer1");.....)
        public void ActivateLayer(string layerName)
        {
            for (int i = 0; i < MyAnimator.layerCount; i++)
            {
                MyAnimator.SetLayerWeight(i, 0);
            }
            MyAnimator.SetLayerWeight(MyAnimator.GetLayerIndex(layerName), 1);
        }
    public void StopAttack()
    {
        if (attackRoutine != null)
        {


            StopCoroutine(attackRoutine);
            isAttacking = false;
            MyAnimator.SetBool("attack", isAttacking);
        }
    }
}