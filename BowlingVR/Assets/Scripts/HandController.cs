using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class HandController : MonoBehaviour
{

    ActionBasedController controller;
    Hand hand;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
