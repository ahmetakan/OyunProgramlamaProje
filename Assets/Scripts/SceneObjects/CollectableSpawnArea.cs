using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnArea : MonoBehaviour
{
    public Collectable collectable;
    public float maxSpawnCount = 10;
    float instantiationDelay;
    public List<Collectable> collectables;

    void Start()
    {
        collectables = new List<Collectable>();
        instantiationDelay = Time.time + 2f;
    }

    void Update()
    {
        HandleNullElements();

        if (collectables.Count >= maxSpawnCount)
        {
            return;
        }

        if (Time.time >= instantiationDelay)
        {
            spawnCollectable();
        }
    }

    private void HandleNullElements()
    {
        for (int i = collectables.Count - 1; i >= 0; i--)
        {
            if (collectables[i] == null)
            {
                collectables.RemoveAt(i);
            }
        }

    }

    void spawnCollectable() 
    {
        Vector2 xyPositions = Random.insideUnitCircle;
        Vector3 generatedPosition = new Vector3(xyPositions.x, 0, xyPositions.y) * 22f;
        generatedPosition += transform.position;

        Collectable _collectable = Instantiate(collectable, null);

        _collectable.transform.position = generatedPosition;

        _collectable.transform.DORotate(Vector3.up * 360f, 5f, RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
        _collectable.transform.DOMoveY(2f, 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);

        collectables.Add(_collectable);

        instantiationDelay = Time.time + 2f;
    }
}