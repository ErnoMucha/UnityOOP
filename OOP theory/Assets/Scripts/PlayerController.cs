using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10;
    private bool isItemTouched;
    private bool isItemPicked;
    private bool isMachineTouched;
    private GameObject currentItem;
    private Machine currentMachine;

    public GameObject holdItem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isMachineTouched)
            {
                //Pick up item.
                if (isItemTouched && !isItemPicked)
                {
                    isItemPicked = true;
                    isItemTouched = false;
                    currentItem.transform.position = holdItem.transform.position;
                    currentItem.transform.SetParent(holdItem.transform, true);
                }

                //Put down item.
                else if (!isItemTouched && isItemPicked)
                {
                    PutDownItem();
                }
            }
            else if (currentMachine.IsTurnedOn)
            {
                if (!isItemPicked)
                {
                    //Make default item if the player doesn't carry item.
                    currentMachine.Use();
                }
                else
                {
                    //Modify item by machine's function.

                    isItemPicked = false;
                    isItemTouched = false;
                    currentItem.transform.SetParent(null);
                    currentMachine.Use(currentItem);
                    currentItem = null;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            currentItem = other.gameObject;
            isItemTouched = true;
        }

        if (other.gameObject.CompareTag("Machine"))
        {
            currentMachine = other.gameObject.GetComponent<Machine>();
            isMachineTouched = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            currentItem = null;
            isItemTouched = false;
        }

        if (other.gameObject.CompareTag("Machine"))
        {
            currentMachine = null;
            isMachineTouched = false;
        }
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    void PutDownItem()
    {
        isItemPicked = false;
        isItemTouched = true;
        currentItem.transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
        currentItem.transform.SetParent(null);
        currentItem = null;
    }
}
