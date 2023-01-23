using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetInAndOut : MonoBehaviour
{
    public Button enterButton;
    public Button exitButton;
    public Button holdBrakeButton;

    private EventTrigger eventTrigger;
    void Start()
    {
        eventTrigger = holdBrakeButton.GetComponent<EventTrigger>();
    }
    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            if (other.TryGetComponent(out CarController controller))
            {
                eventTrigger.triggers.Clear();

                EventTrigger.Entry pointerUp = new EventTrigger.Entry();
                EventTrigger.Entry pointerDown = new EventTrigger.Entry();

                pointerUp.eventID = EventTriggerType.PointerUp;
                pointerUp.callback.AddListener((temp) => controller.releaseBrake());

                pointerDown.eventID = EventTriggerType.PointerDown;
                pointerDown.callback.AddListener((temp) => controller.holdBrake());

                eventTrigger.triggers.Add(pointerUp);
                eventTrigger.triggers.Add(pointerDown);
            }

            if (other.TryGetComponent(out Rideable rideable))
            {
                rideable.showEnterButton();
                enterButton.onClick.AddListener(() => rideable.enterVehicle(gameObject));
                exitButton.onClick.AddListener(() => rideable.exitVehicle(gameObject));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            if (other.TryGetComponent(out Rideable rideable))
            {
                rideable.hideBothButtons();
            }
        }
    }
}
