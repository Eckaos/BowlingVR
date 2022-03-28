using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private KegelList kegelList;
    [SerializeField] private KegelSpawner kegelSpawner;

    public delegate void Collision();
    public event Collision OnCollision;

    private void Awake() {
        kegelSpawner.OnKegelsSpawned += SetKegelList;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if(ball == null) return;
        StartCoroutine(TriggerScoring());
        ball.Respawn();
        kegelSpawner.playSound();
    }

    public void SetKegelList(KegelList list)
    {
        kegelList = list;
    }

    private IEnumerator TriggerScoring()
    {
        yield return new WaitForSeconds(2);
        turnManager.Scoring(kegelList.GetNumberOfFallenKegels());
    }   
}
