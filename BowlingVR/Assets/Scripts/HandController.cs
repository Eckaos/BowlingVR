using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{

    ActionBasedController controller;
    public Hand hand;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        hand.SetGrip(controller.selectAction.action.ReadValue<float>);
    }
}
