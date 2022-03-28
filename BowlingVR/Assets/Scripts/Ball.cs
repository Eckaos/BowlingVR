using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform spawningPoint;
    private new Rigidbody rigidbody;
    private new AudioSource audio;
    private void Awake() {
        transform.position = spawningPoint.position;
        rigidbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    public void Respawn()
    {
        transform.position = spawningPoint.position;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other) {
        Kegel kegel = other.GetComponent<Kegel>();
        if(kegel == null) return;
        audio.Play();
    }
}
