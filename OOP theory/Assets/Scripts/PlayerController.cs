using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10;
    private bool isItemTouched;
    [SerializeField] private bool isItemPicked;
    private GameObject item;

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
            //Pick up item.
            if (isItemTouched && !isItemPicked)
            {
                isItemPicked = true;
                isItemTouched = false;
                item.transform.position = holdItem.transform.position;
                item.transform.SetParent(holdItem.transform, true);
            }

            //Put down item.
            else if (!isItemTouched && isItemPicked)
            {
                isItemPicked = false;
                isItemTouched = true;
                item.transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
                item.transform.SetParent(null);
                item = null;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            item = other.gameObject;
            isItemTouched = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            item = null;
            isItemTouched = false;
        }
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
}
