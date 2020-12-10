using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocity : MonoBehaviour {


    // The velocity in y is 10 units per second.  If the GameObject starts at (0,0,0) then
    // it will reach (0,100,0) units after 10 seconds.
   
        Transform rT;

    void Start()
    {
        rT = GetComponent<Transform>();
         
        
    }


    void Update()
    { 
        SetTransformX(4.0f);
    }


    void SetTransformX(float n)
    {
        transform.position = new Vector3(transform.position.x, n , transform.position.z);
    }

}
