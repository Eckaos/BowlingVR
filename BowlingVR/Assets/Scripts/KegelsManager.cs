using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KegelsManager : MonoBehaviour
{
    public List<Kegel> kegels;

    public int GetNumberOfFallenKegels() => kegels.Where(kegel => kegel.hasFallen()).Count();
}
