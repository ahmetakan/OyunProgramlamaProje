using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // Start is called before the first frame update

    Stash _stash;
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
        if (other.CompareTag("Collectable"))
        {
            if (other.TryGetComponent(out Collectable collected))
            {
                _stash.addStash(collected);
            }
        }
    }
}