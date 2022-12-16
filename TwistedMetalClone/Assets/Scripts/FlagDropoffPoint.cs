using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDropoffPoint : MonoBehaviour
{
    [SerializeField] private GameObject redFlagObj;
    [SerializeField] private GameObject blueFlagObj;
    private GameController gameController;

    private enum DropoffType { Blue, Red };
    [SerializeField] private DropoffType dropoffType;

    private void Start() {
        if(gameController == null) {
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(dropoffType == DropoffType.Red) {
            if(other.tag == "RedFlagCarrier") {
                gameController.IncrementScore("Red");
                //Reset carrying flag UI / status
                blueFlagObj.SetActive(true);
                other.tag = "Red";
            }
        }
        else if(dropoffType == DropoffType.Blue)
        {
            if(other.tag == "BlueFlagCarrier")
            {
                gameController.IncrementScore("Blue");
                //Reset  carrying flag UI / status
                redFlagObj.SetActive(true);
                other.tag = "Blue";
            }
        }

    }
}
