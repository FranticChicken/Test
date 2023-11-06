using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTest : MonoBehaviour
{

    //this LookAt() function changes own tranform according to the object to which we are looking at


    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
    }
}
