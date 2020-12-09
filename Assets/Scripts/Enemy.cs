using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private Vector3[] _wayPoints;

    private void Awake()
    {
        Transform[] pathPoints = GetComponentsInChildren<Transform>();
        _wayPoints = new Vector3[pathPoints.Length];
        for (int i = 0; i<_wayPoints.Length; i++)
            _wayPoints[i] = pathPoints[i].position;
    }

    private void Start()
    {
        Tween path = transform.DOPath(_wayPoints, 15, PathType.CatmullRom).SetOptions(true).SetLoops(-1);
    }
}
