using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rideable : MonoBehaviour
{
    private bool isInCar = false;
    private CarController controller;
    public Button enterButton;
    public Button exitButton;
    public Button holdBrakeButton;

    public void showEnterButton()
    {
        if (isInCar)
        {
            return;
        }

        enterButton.gameObject.SetActive(true);
    }

    public void hideBothButtons()
    {
        enterButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        holdBrakeButton.gameObject.SetActive(false);
    }

    public void enterVehicle(GameObject player)
    {
        controller = GetComponent<CarController>();
        controller.enabled = true;

        player.transform.parent = gameObject.transform;
        player.transform.position = gameObject.transform.position;
        
        player.SetActive(false);
        

        enterButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(true);
        holdBrakeButton.gameObject.SetActive(true);

        
        isInCar = true;
    }

    public void exitVehicle(GameObject player)
    {
        controller = GetComponent<CarController>();
        controller.enabled = false;

        Vector3 vehiclePosition = gameObject.transform.position;
        Vector3 previousPlayerPosition = player.transform.position;

        player.transform.parent = null;
        player.transform.position = new Vector3(vehiclePosition.x - 12, 0, vehiclePosition.z);

        player.SetActive(true);
        
        isInCar = false;

        hideBothButtons();
    }
}
