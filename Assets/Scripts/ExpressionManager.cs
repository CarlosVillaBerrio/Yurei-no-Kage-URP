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
            StartCoroutine(TemporalChangeBool());
        }
    }

    IEnumerator TemporalChangeBool()
    {
        yukiAnimator.SetBool("isTakingObject", true);
        yield return new WaitForSeconds(1.5f);
        yukiAnimator.SetBool("isTakingObject", false);

    }
}
