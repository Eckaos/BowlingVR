using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    public GameObject point;
    public bool hasFallen () 
    {  
        return point.transform.localPosition.y < GetComponent<Renderer>().bounds.size.y/2;
    }
}
