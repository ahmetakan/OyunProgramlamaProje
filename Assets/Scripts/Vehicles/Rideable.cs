using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rideable : MonoBehaviour
{
    private bool isInCar = false;

    public Button enterButton;
    public Button exitButton;
    public Button holdBrakeButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void showHideButton()
    //{
    //    if (!isPressed)
    //    {

    //    }
    //}

    public void showEnterButton()
    {
        if (isInCar)
        {
            return;
        }

        //enterButton.onClick.AddListener(() => enterVehicle(player: player));
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
        //if (isPressed)
        //{
        //    return;
        //}
        //enterButton.onClick.AddListener(() => enterVehicle(player: player));
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
        //if (isPressed)
        //{
        //    return;
        //}

        Vector3 vehiclePosition = gameObject.transform.position;
        Vector3 previousPlayerPosition = player.transform.position;

        //exitButton.onClick.AddListener(() => exitVehicle(player: player));
        player.transform.parent = null;
        player.transform.position = new Vector3(vehiclePosition.x - 12, 0, vehiclePosition.z);

        player.SetActive(true);
        
        isInCar = false;

        hideBothButtons();
    }

    //public void setHoldBrakeButton()
    //{
    //    holdBrakeButton.OnPointerUp();
    //}
}
