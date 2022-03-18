using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    public bool hasFallen () => Vector3.Angle(transform.up, Vector3.up) > 5;
}
