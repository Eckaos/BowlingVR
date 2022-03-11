using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    public bool hasFallen () 
    {   
        return transform.rotation.eulerAngles.z > 30 || transform.rotation.eulerAngles.z < -30 || transform.rotation.eulerAngles.x > 30 || transform.rotation.eulerAngles.x < -30;
    }
}
