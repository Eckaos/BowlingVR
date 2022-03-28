using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform spawningPoint;
    private new Rigidbody rigidbody;

    private void Awake() {
        transform.position = spawningPoint.position;
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Respawn()
    {
        transform.position = spawningPoint.position;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.velocity = Vector3.zero;
    }
}
