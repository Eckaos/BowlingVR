using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kegel : MonoBehaviour
{
    Vector3 position;

    private void Awake() {
        position = (GetComponent(typeof(Transform)) as Transform).position;
    }
    public bool hasFallen () => position.y < 1.4;

}
