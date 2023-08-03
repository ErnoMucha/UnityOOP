using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PaintMachine : Machine
{
    // POLYMORPHISM
    public override void Use(GameObject item)
    {
        //Call: PlayerController.cs
        //Paint an existing item.
        if (IsTurnedOn)
        {
            Renderer renderer = item.GetComponent<Renderer>();
            float r = Random.Range(0, 1.0f);
            float g = Random.Range(0, 1.0f);
            float b = Random.Range(0, 1.0f);

            renderer.material.color = new Color(r, g, b, 0);
            item.transform.position = newItemPosition.transform.position;
        }
    }
}
