using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gutter : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    [SerializeField] private KegelList kegelList;
    [SerializeField] private KegelSpawner kegelSpawner;

    private void Awake() {
        kegelSpawner.OnKegelsSpawned += SetKegelList;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if(ball == null) return;
        TriggerScoring(ball);
    }

    public IEnumerator TriggerScoring(Ball ball)
    {
        yield return new WaitForSeconds(2);
        turnManager.Scoring(kegelList.GetNumberOfFallenKegels());
        ball.Respawn();
    }

    public void SetKegelList(KegelList list)
    {
        kegelList = list;
    }
}
