using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    public bool hasFallen () 
    {  
        return transform.localEulerAngles.z  > 30 || transform.localEulerAngles.z < -30 || transform.localEulerAngles.x > 30 || transform.localEulerAngles.x < -30;
    }
}
