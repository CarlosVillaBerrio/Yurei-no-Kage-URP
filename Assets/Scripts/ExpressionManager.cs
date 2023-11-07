using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionManager : MonoBehaviour
{
    [SerializeField] private Animator yukiAnimator;

    public void GrabbingObject()
    {        
       StartCoroutine(TemporalChangeBool());        
    }

    IEnumerator TemporalChangeBool()
    {
        yukiAnimator.SetBool("isTakingObject", true);
        yield return new WaitForSeconds(0.8f);
        yukiAnimator.SetBool("isTakingObject", false);

    }

    public void ActivateDeath()
    {
        yukiAnimator.SetBool("isDeath", true);
    }
}
