using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    public GameObject point;
    public bool hasFallen () 
    {  
        return Vector3.Angle(transform.up, Vector3.up) > 5;
    }
}
