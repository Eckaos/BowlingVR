using System.Collections.Generic;
using UnityEngine;

public class TriggerTurn : MonoBehaviour
{
    public TurnManager turnManager;
    private List<Kegel> kegels;


    void Awake() {
        kegels = new List<Kegel>();
        kegels.Add(GameObject.Find("Kegel").GetComponent(typeof(Kegel)) as Kegel);
        foreach(GameObject kegel in GameObject.FindGameObjectsWithTag("Kegel"))
            kegels.Add(kegel.GetComponent(typeof(Kegel)) as Kegel);
    }
    /*private void OnCollisionEnter(Collision other) {
        
        //turnManager.Turn(kegels.Where(kegel => kegel.isFallen()).ToList().Sum());
    }*/

    private void Update() {
        turnManager.Turn(10);

    }
}
