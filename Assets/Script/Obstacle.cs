using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    
    [SerializeField] float duration = 3;
    [SerializeField] List<Transform> positions;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    private void Move()
    {
        var pos = positions[index];
        this.transform
            .DOMove(pos.position, duration)
            .onComplete = Move;

        index += 1;
        if(index == positions.Count)
            index = 0;
    }
}
