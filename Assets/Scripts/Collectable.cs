using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent"))
        {
            DoStuff(other);
        }
    }

    protected virtual void DoStuff(Collider other)
    {
        Destroy(gameObject);
    }
}
