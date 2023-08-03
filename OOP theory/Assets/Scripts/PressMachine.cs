using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PressMachine : Machine
{
    private float pressModifier = 0.8f;

    // POLYMORPHISM
    public override void Use(GameObject item)
    {
        //Call: PlayerController.cs
        //Press an existing item.
        if (IsTurnedOn)
        {
            item.transform.position = newItemPosition.transform.position;
            item.transform.localScale = new Vector3(1, item.transform.localScale.y * pressModifier, 1);
        }
    }
}
