using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KegelsManager : MonoBehaviour
{
    public List<Kegel> kegels;

    public int GetNumberOfFallenKegels()
    {
        List<Kegel> fallen = kegels.Where(kegel => kegel.hasFallen()).ToList();
        int numberOfFallen = kegels.RemoveAll(kegel => fallen.Contains(kegel));
        fallen.ForEach(kegel => Destroy(kegel));
        return numberOfFallen;
    }
}
