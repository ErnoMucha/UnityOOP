using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //public Machine currentMachine;
    //public GameObject currentItem;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
