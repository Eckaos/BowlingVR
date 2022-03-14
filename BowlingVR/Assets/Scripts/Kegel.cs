using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    public GameObject point;
    public bool hasFallen () 
    {  
        Debug.Log(point.transform.localPosition.y +"   "+ GetComponent<Renderer>().bounds.size.y/2);
        return point.transform.localPosition.y < GetComponent<Renderer>().bounds.size.y/2;
    }
}
