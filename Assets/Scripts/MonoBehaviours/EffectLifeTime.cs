using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLifeTime : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        AnimatorClipInfo[] clipInfos = animator.GetCurrentAnimatorClipInfo(0);

        float duration = 0;

        foreach (var item in clipInfos)
        {
            duration = item.clip.length;
        }

        Destroy(gameObject, duration);
    }
}
