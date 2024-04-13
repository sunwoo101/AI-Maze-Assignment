using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    protected override void DoStuff(Collider other)
    {
        other.GetComponent<AgentCollection>().coinsCollected += 1;
        base.DoStuff(other);
    }
}
