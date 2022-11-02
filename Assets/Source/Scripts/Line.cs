using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour
{
    private Color cubeColor;
    private Color lineColor;
    private float pointsHeightOffset;
    private float pointsMaxRandomWidth;
    private float moveTime;
    private int pointsCount;

    private Point pointPrefab;
    private Cube cubePrefab;
    private GameObject collisionFX;

    private List<Point> linePoints;
    private LineRenderer lineRenderer;

    public void Init(Color cubeColor,Color lineColor,float moveTime, float pointsHeightOffset,float pointsMaxRandomWidth, int pointsCount, Point pointPrefab,Cube cubePrefab,GameObject collisionFX)
    {
        this.cubeColor = cubeColor;
        this.lineColor = lineColor;
        this.moveTime = moveTime;
        this.pointsHeightOffset = pointsHeightOffset;
        this.pointsMaxRandomWidth = pointsMaxRandomWidth;
        this.pointsCount = pointsCount;
        this.pointPrefab = pointPrefab;
        this.cubePrefab = cubePrefab;
        this.collisionFX = collisionFX;
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
        linePoints = new List<Point>();
        lineRenderer.positionCount = pointsCount;

        for (int i = 0; i < pointsCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-pointsMaxRandomWidth, pointsMaxRandomWidth+1),
                0, i * pointsHeightOffset);

            linePoints.Add(Instantiate(pointPrefab, transform));
            linePoints.Last().transform.localPosition = randomPosition;
            lineRenderer.SetPosition(i, linePoints[i].transform.position);
            if (i == 0 || i == pointsCount - 1)
            {
                linePoints[i].transform.localPosition = new Vector3(0, 
                    linePoints[i].transform.localPosition.y,
                    linePoints[i].transform.localPosition.z);
                linePoints[i].SetMovableState(false);
            }
            if (i != 0)
            {
                linePoints[linePoints.Count - 2].SetNextPointPositionZ(linePoints[linePoints.Count - 1].transform.position.z);
                linePoints[linePoints.Count - 1].SetPrevPointPositionZ(linePoints[linePoints.Count - 2].transform.position.z);
            }
            else
            {
                Instantiate(cubePrefab, linePoints[linePoints.Count - 1].transform.position, Quaternion.identity).Init(
                    cubeColor,
                    ref linePoints,
                    moveTime,
                    collisionFX);
            }
        }
    }

    private void UpdateLine()
    {
        lineRenderer.positionCount = linePoints.Count;
        for (int i = 0; i < linePoints.Count; i++)
        {
            lineRenderer.SetPosition(i, linePoints[i].transform.position);
        }
    }

    private void Update()
    {
        UpdateLine();
    }
}
