using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform player;
    public TurnManager turnManager;
    public KegelsManager kegelsManager;

    private void Update()
    {

        /*if (Vector3.Distance(player.position, transform.position) < 25)
            return;

        turnManager.Score(kegelsManager.GetNumberOfFallenKegels());
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position = player.transform.position;*/
    }
}
