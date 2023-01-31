using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class OrlagAnimationController : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Swing()
    {
        anim.SetTrigger("Harvest");
    }

    public void Walk()
    {
        anim.SetTrigger("Walk");
    }

    public void Deliver()
    {
        anim.SetTrigger("Deliver");//needs changing
    }

    public void Idle()
    {
        anim.SetTrigger("Wait");
    }
}
