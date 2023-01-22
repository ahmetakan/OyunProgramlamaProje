using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    public int vehiclePrice;
    public int paidMetalCount = 0;
    public string unlockableName;

    public TextMeshPro name;
    public TextMeshPro price;

    private int remainingPrice => vehiclePrice - paidMetalCount;

    public List<GameObject> unlockableAreas = new List<GameObject>();

    private void OnEnable()
    {
        unlockableAreas.ForEach(unlockable =>
        {
            unlockable.SetActive(false);
        });
    }

    public void Start()
    {
        name.text = unlockableName;
        price.text = remainingPrice.ToString();
    }
    private void paymentCompleted()
    {
        price.text = remainingPrice.ToString();
        checkUnlocked();
    }
    private void checkUnlocked()
    {
        if (paidMetalCount < vehiclePrice)
        {
            return;
        }

        unlockableAreas.ForEach(unlockable =>
        {
            unlockable.transform.parent = null;
            unlockable.SetActive(true);
        });

        gameObject.SetActive(false);
    }

    public void pay(Stashable stashable)
    {
        paidMetalCount++;
        
        stashable.remove(transform, paymentCompleted);
    }
}
