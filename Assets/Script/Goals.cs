using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goals : MonoBehaviour
{
    public UnityEvent onBallGoalEnter = new UnityEvent();

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Ball"))
        {
            onBallGoalEnter.Invoke();
        }
    }
}
