using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KegelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject kegelListPrefab;
    [SerializeField] private Vector3 position;
    private KegelList currentKegelList;

    public delegate void SpawnKegels(KegelList list);
    public event SpawnKegels OnKegelsSpawned;

    public void RespawnKegels()
    {
        if(currentKegelList != null)
            Destroy(currentKegelList.gameObject);
        currentKegelList = Instantiate(kegelListPrefab, position, Quaternion.identity).GetComponent<KegelList>();
        if(OnKegelsSpawned != null) OnKegelsSpawned.Invoke(currentKegelList);
    }
}
