using DG.Tweening;
using Supyrb;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private float moveTime;

    private Color cubeColor;
    private List<Point> cubePath;
    private GameObject collisionFX;

    private Signal startGameSignal;
    private Signal gameOverSignal;
    private Signal endPointReachedSignal;

    public void Init(Color cubeColor, ref List<Point> cubePath, float moveTime,GameObject collisionFX)
    {
        this.cubeColor = cubeColor;
        this.cubePath = cubePath;
        this.moveTime = moveTime;
        this.collisionFX = collisionFX;
    }

    private void Start()
    {
        startGameSignal = Signals.Get<StartGameSignal>();
        gameOverSignal = Signals.Get<GameOverSignal>();
        endPointReachedSignal = Signals.Get<EndPointReachedSignal>();

        startGameSignal.AddListener(StartMove);
        GetComponent<MeshRenderer>().material.color = cubeColor;
    }

    private void StartMove()
    {
        Vector3[] path = new Vector3[cubePath.Count];
        for (int i = 0; i < cubePath.Count; i++)
        {
            cubePath[i].SetMovableState(false);
            path[i] = cubePath[i].transform.position;
        }
        transform.DOPath(path, moveTime, PathType.CatmullRom).OnWaypointChange((int point) =>
        {
            cubePath[point].fx.Play();
        }).OnComplete(()=> 
        {
            endPointReachedSignal?.Dispatch();
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            Destroy(Instantiate(collisionFX, transform.position, Quaternion.identity),2f);
            DOTween.Kill(transform);
            DOTween.Kill(other.transform);
            gameOverSignal?.Dispatch();
        }
    }

    private void OnDestroy()
    {
        startGameSignal.RemoveListener(StartMove);
        DOTween.Kill(transform);
    }
}
