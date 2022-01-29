using System;
using System.Collections;
using System.Collections.Generic;
using CardSorting.Utils;
using UnityEngine;

public class CubicBezierTest : MonoBehaviour
{
    public GameObject objectPrefab;
    public bool isNeedRecalculate = false;


    public Vector2 startPoint = new Vector2(0, 0);
    public Vector2 endPoint = new Vector2(5, 0);
    public Vector2 controlPoint = new Vector2(2.5f, 2.5f);

    public int segmentCount = 10;

    private List<GameObject> _objects;

    private void Update()
    {
        if (!isNeedRecalculate)
        {
            return;
        }

        isNeedRecalculate = false;

        if (_objects != null)
        {
            foreach (var gameObject in _objects)
            {
                Destroy(gameObject);
            }
        }

        _objects = new List<GameObject>();

        CubicBezier spline = new CubicBezier(startPoint, endPoint, controlPoint);

        for (int i = 0; i <= segmentCount; i++)
        {
            float t = i / (float)segmentCount;
            Vector2 pos = spline.Solve(t);
            float tan = spline.SolveTangent(t);
            GameObject go = Instantiate(objectPrefab);
            go.transform.position = pos;
            go.transform.localRotation = Quaternion.Euler(new Vector3(0,0,tan));
            go.name = $"createdObj";
            _objects.Add(go);
        }
    }
}