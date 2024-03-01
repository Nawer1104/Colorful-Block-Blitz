using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Block : MonoBehaviour
{
    public Transform target;

    public bool isReachedTarget;

    private void Start()
    {
        isReachedTarget = false;
    }

    public void GoToTarget()
    {
        transform.DOMove(target.position, 1f, false).OnComplete(() => {
            isReachedTarget = true;
        });
    }
}
