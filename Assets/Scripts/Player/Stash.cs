using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour
{
    public Transform stashParent;
    public List<Stashable> collectedMetals = new List<Stashable>();
    public int collectedCount => collectedMetals.Count;
    public float collectionHeight = 1;
    public int maxStashableCount = 5;
    public float stashSpeed;
    void Start()
    {

    }

    void Update()
    {

    }

    public void addStash(Collectable collectable)
    {
        if (collectedCount >= maxStashableCount)
        {
            return;
        }

        Stashable collectedStashable = collectable.collect();

        var yLocalPosition = collectedCount * collectionHeight;

        collectedStashable.addStash(stashParent, yLocalPosition, onCompleteCollect, stashSpeed);
        collectedMetals.Add(collectedStashable);
    }

    private void onCompleteCollect()
    {

    }

    public Stashable removeStash()
    {
        if (collectedCount <= 0)
        {
            return null;
        }

        var removableStash = collectedMetals[collectedCount - 1];
        collectedMetals.RemoveAt(collectedCount - 1);

        return removableStash;
    }
}