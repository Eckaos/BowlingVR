using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KegelList : MonoBehaviour
{
    public List<Kegel> kegels;
    
    AudioSource source;
    
    public int GetNumberOfFallenKegels()
    {
        List<Kegel> fallen = kegels.Where(kegel => kegel.hasFallen()).ToList();
        int numberOfFallen = kegels.RemoveAll(kegel => fallen.Contains(kegel));
        fallen.ForEach(kegel => Destroy(kegel.gameObject));
        return numberOfFallen;
    }

     
     void Start()
     {
        source = GetComponent<AudioSource>();
     }
 
     private void OnCollisionEnter(Collision collision)
     {
         source.Play();
     }
}
