using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payer : MonoBehaviour
{
    // Start is called before the first frame update
    private Stash _stash;
    private float payDelay;

    void Start()
    {
        _stash = GetComponent<Stash>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        payDelay = Time.time + 0.3f;
    }

    private void OnTriggerStay(Collider other)
    {
        if(payDelay >= Time.time)
        {
            return;
        }

        if (other.CompareTag("Unlockable"))
        {
            if (other.TryGetComponent(out Unlockable unlockableArea))
            {

                Stashable removableStashable = _stash.removeStash();

                if (removableStashable == null)
                {
                    return;
                }

                unlockableArea.pay(removableStashable);
                payDelay = Time.time + 0.5f;
            }
        }
    }
}
