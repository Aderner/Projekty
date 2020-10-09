using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Player_hit
{


    private Animator potAnim;
    // Start is called before the first frame update
    void Start()
    {

        potAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Smash()
    {
        potAnim.SetBool("smash",true);
    }

}
