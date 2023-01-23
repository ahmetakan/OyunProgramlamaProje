using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Unlockable : MonoBehaviour
{
    public UnlockData unlockableData;
    public TextMeshPro name;
    public TextMeshPro price;
    public List<GameObject> objectsToUnlock = new List<GameObject>();

    private void OnEnable()
    {
        checkUnlocked();
    }
    void Start()
    {
        objectsToUnlock.ForEach((x) => x.SetActive(false));
        name.text = "UNLOCK " + unlockableData.unlockableName.ToUpper();
        price.text = unlockableData.RemainingPrice.ToString();
    }
    private void paymentCompleted()
    {
        price.text = unlockableData.RemainingPrice.ToString();
        checkUnlocked();
    }
    private void checkUnlocked()
    {
        if (unlockableData.RemainingPrice <= 0)
        {
            objectsToUnlock.ForEach((unlockable) =>
            {
                unlockable.transform.parent = null;
                unlockable.SetActive(true);
            });

            gameObject.SetActive(false);
        }
    }

    public void pay(Stashable stashable)
    {
        if (unlockableData.RemainingPrice <= 0)
            return;

        unlockableData.CollectedPrice++;
        
        stashable.remove(transform, paymentCompleted);
    }
}
