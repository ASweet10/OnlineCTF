using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    //Current point in video
    // Part 2: 33:27, but need to backtrack and comment code fully
    // Part 3: 53:17, need to copy logic from carinputhandler + "raycastcar"

    /*
    private PlayerInput playerInput;
    private RaycastCar carController;

    public string actionMapPlayerControls;
    public string actionMapMenuControls;
    private void Awake() {
        playerInput = gameObject.GetComponent<PlayerInput>();
        var actions = playerInput.actions;

        carController = gameObject.GetComponent<RaycastCar>();

        carController.ProviderAccelerate = actions.FindAction("Accelerate").ReadValue<float>();
        carController.ProviderBrake = actions.FindAction("Brake").ReadValue<float>();
        carController.ProviderSteer = actions.FindAction("Steer").ReadValue<float>();
    }

    public void OnAccelerate() {
        carController.ProviderAccelerate?.Invoke();
    }
    */
}
