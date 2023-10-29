using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesGenerator : MonoBehaviour
{
    public static LinesGenerator Instance { get; private set; }
    [SerializeField] private LineConfiguration[] lines;

    private void Awake()
    {
        Instance = this;
    }

    public void GenerateLevel(int linesCount,int pointsInLine,float fieldWidth)
    {
        for (int i = 0; i < linesCount; i++)
        {
            float startPos = -(fieldWidth / 2);
            Vector3 linePosition = new Vector3(startPos + (i * (fieldWidth / linesCount)), 0, 0);
            Instantiate(lines[i].LinePrefab, linePosition, Quaternion.identity).Init(
                lines[i].CubeColor,
                lines[i].LineColor,
                lines[i].MoveTime,
                lines[i].PointsHeightOffset,
                lines[i].PointsMaxRandomWidth,
                pointsInLine,
                lines[i].PointPrefab,
                lines[i].CubePrefab,
                lines[i].CollisionFX);
        }
    }
}
