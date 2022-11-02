using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LineConfiguration
{
    [SerializeField] private Color cubeColor;
    [SerializeField] private Color lineColor;
    [SerializeField] private int pointsCount;
    [SerializeField] private float moveTime;
    [SerializeField] private float pointsHeightOffset;
    [SerializeField] private float pointsMaxRandomWidth;
    [SerializeField] private GameObject collisionFX;
    [SerializeField] private Point pointPrefab;
    [SerializeField] private Line linePrefab;
    [SerializeField] private Cube cubePrefab;


    public int PointsCount => pointsCount;
    public float MoveTime => moveTime;
    public float PointsHeightOffset => pointsHeightOffset;
    public float PointsMaxRandomWidth => pointsMaxRandomWidth;
    public Color CubeColor => cubeColor;
    public Color LineColor => lineColor;
    public Point PointPrefab => pointPrefab;
    public Line LinePrefab => linePrefab;
    public Cube CubePrefab => cubePrefab;
    public GameObject CollisionFX => collisionFX;
}
