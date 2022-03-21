using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private TurnManager turnManager;
    [SerializeField]private Transform ball;
    public KegelManager kegelManager;

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Collider>().name == "Ball")
        {
            turnManager.Score(kegelManager.GetNumberOfFallenKegels());
            ball.position = player.transform.position;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
