using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    public bool hasFallen () 
    {   
        var angleX = transform.localEulerAngles.z;
        var angelY = transform.localEulerAngles.y;
        return transform.localEulerAngles.z  > 30 || transform.localEulerAngles.z < -30 || transform.localEulerAngles.x > 30 || transform.localEulerAngles.x < -30;
    }
}
