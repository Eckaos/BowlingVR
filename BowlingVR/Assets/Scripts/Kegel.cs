using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    public GameObject point;
    public bool hasFallen () 
    {  
        return point.transform.localEulerAngles.z  > 30 || point.transform.localEulerAngles.z < -30 || point.transform.localEulerAngles.x > 30 || point.transform.localEulerAngles.x < -30;
    }
}
