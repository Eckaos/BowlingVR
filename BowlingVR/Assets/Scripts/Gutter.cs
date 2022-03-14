using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{
    public Transform player;
    public TurnManager turnManager;
    public KegelsManager kegelsManager;
    public Transform ball;
    public GameObject kegelsPrefab;

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Collider>().name == "Ball")
        {
            turnManager.Score(kegelsManager.GetNumberOfFallenKegels());
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.position = player.transform.position;
            GameObject kegels = GameObject.Find("Quilles");
            Vector3 kegelsPosition = kegels.transform.position;
            kegelsManager = Instantiate(kegelsPrefab, kegelsPosition, Quaternion.identity).GetComponent<KegelsManager>();
            Destroy(kegels);
        }
    }
}
