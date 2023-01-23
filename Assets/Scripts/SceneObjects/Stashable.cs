using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stashable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addStash(Transform stashParent, float yLocalPosition, Action onCompleteCollect, float stashSpeed)
    {
        float completionRadius = 0.8f;
        Tweener tweener = transform.DOMove(stashParent.position, stashSpeed).SetSpeedBased(true);
        var targetPos = stashParent.position + Vector3.up * yLocalPosition;
        float distance;

        tweener.OnUpdate(() => {

            distance = Vector3.Distance(transform.position, targetPos);

            if (distance > completionRadius)
            {
                targetPos = stashParent.position + Vector3.up * yLocalPosition;
                tweener.ChangeEndValue(targetPos, true);
            }
        })
        .OnComplete(() =>
        {
            transform.parent = stashParent;
            transform.localPosition = Vector3.up * yLocalPosition;
            transform.localRotation = Quaternion.identity;
            onCompleteCollect?.Invoke();
        });
    }

    public void remove(Transform target, Action onCompleted)
    {
        var targetPosition = target.position;

        var direction = targetPosition - transform.position;

        direction.y = 0;

        var middlePosition = transform.position + direction / 2f;

        float duration = 0.5f;

        transform.parent = null;

        transform.DOPath(new Vector3[] { middlePosition, targetPosition },
                         duration, PathType.CatmullRom)
        .OnComplete(() =>
        {
            Destroy(gameObject);
            onCompleted();
        });
    }
}