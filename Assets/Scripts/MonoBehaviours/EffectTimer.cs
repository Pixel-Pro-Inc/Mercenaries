using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour
{
    // Update is called once per frame
    private void Start()
    {
        Destroy(gameObject, 10f);
    }
}
