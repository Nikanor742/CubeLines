using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour
{
    private Color lineColor;
    private float pointsOffset;
    private int pointsCount;

    private Point pointPrefab;

    private List<Transform> linePoints;
    private LineRenderer lineRenderer;

    public void Init(Color lineColor, float pointsOffset, int pointsCount, Point pointPrefab)
    {
        this.lineColor = lineColor;
        this.pointsOffset = pointsOffset;
        this.pointsCount = pointsCount;
        this.pointPrefab = pointPrefab;
    }

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        GeneratePoints();
    }

   

    private void GeneratePoints()
    {
        linePoints = new List<Transform>();
        lineRenderer.positionCount = pointsCount;

        for (int i = 0; i < pointsCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-1, 2), 0, i * pointsOffset);

            linePoints.Add(Instantiate(pointPrefab, randomPosition, Quaternion.identity).transform);
            linePoints[i].parent = transform;

            lineRenderer.SetPosition(i, linePoints[i].position);
            if (i == 0 || i == pointsCount - 1)
            {
                Destroy(linePoints[i].GetComponent<Point>());
            }
        }
    }

    private void UpdateLine()
    {
        lineRenderer.positionCount = linePoints.Count;
        for (int i = 0; i < linePoints.Count; i++)
        {
            lineRenderer.SetPosition(i, linePoints[i].position);
        }
    }

    private void Update()
    {
        UpdateLine();
    }
}
