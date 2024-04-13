using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collectable
{
    protected override void DoStuff(Collider other)
    {
        if (other.GetComponent<AgentCollection>().collectsKeys)
        {
            other.GetComponent<AgentCollection>().hasKey = true;
            base.DoStuff(other);
        }
    }
}
