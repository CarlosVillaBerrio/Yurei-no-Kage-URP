using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionManager : MonoBehaviour
{
    [SerializeField] private Animator yukiAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            yukiAnimator.SetBool("isTakingObject", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            yukiAnimator.SetBool("isTakingObject", false);
        }
    }
}
