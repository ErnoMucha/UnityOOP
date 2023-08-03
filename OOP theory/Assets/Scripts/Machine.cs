using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    // ENCAPSULATION
    private bool m_isTurnedOn;
    public bool IsTurnedOn
    {
        get { return m_isTurnedOn; }
        set { m_isTurnedOn = value; }
    }

    public GameObject itemPrefab;
    public GameObject newItemPosition;

    // Start is called before the first frame update
    void Start()
    {
        IsTurnedOn = false;
        SetColor(Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Turn on/off machine
    private void OnMouseDown()
    {
        if (IsTurnedOn)
        {
            IsTurnedOn = false;
            SetColor(Color.red);
        }
        else
        {
            IsTurnedOn = true;
            SetColor(Color.green);
        }
    }

    private void SetColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();

        renderer.material.color = color;
    }

    // POLYMORPHISM
    public void Use()
    {
        // ABSTRACTION
        //Call: PlayerController.cs
        //If the player didn't carry any item make a default item with every machine.
        if (IsTurnedOn)
        {
            Instantiate(itemPrefab, newItemPosition.transform.position, newItemPosition.transform.rotation);
        }
    }

    // POLYMORPHISM
    public virtual void Use(GameObject item)
    {
        //If the player carried item make modification on it.
    }
}
