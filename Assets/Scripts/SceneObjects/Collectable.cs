using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Stashable _metal;

    public Stashable collect()
    {
        var _collectable = Instantiate(_metal, transform.position, transform.rotation, null);
        Destroy(gameObject);
        return _collectable;
    }
}