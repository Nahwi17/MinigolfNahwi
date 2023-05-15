using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] BallController ballController;
    [SerializeField] CameraController CamController;
    [SerializeField] GameObject finishWindow;
    [SerializeField] TMP_Text finishText;
    [SerializeField] TMP_Text shootCountText;

    bool isBallOutside;
    Vector3 lastBallPosition;
    bool isBallTeleporting;
    bool isGoal;

    private void onEnabled(){
        ballController.onBallShooted.AddListener(UpdateShootCount);
    }

    private void OnDisable() {
        ballController.onBallShooted.RemoveListener(UpdateShootCount);
    }

    private void Update()
    {
        if(ballController.ShootingMode)
        {
            lastBallPosition = ballController.transform.position;
        }

        var inputActive = Input.GetMouseButton(0) 
            && ballController.IsMove() == false 
            && ballController.ShootingMode == false
            && isBallOutside == false;
            
        CamController.SetInputActive(inputActive);
    }

    public void onBallGoalEnter()
    {
        isGoal = true;
        ballController.enabled = false;
        // TODO player win window pop up 
        finishWindow.gameObject.SetActive(true);
        finishText.text = "Finished!!!\n" + "Shoot Count: " + ballController.ShootCount;

    }

    public void OnBalloutside()
    {
        if(isGoal)
            return;

        if(isBallTeleporting == false)
            Invoke("TeleportBallLastPosition", 3);

        ballController.enabled = false;
        isBallOutside = true;
        isBallTeleporting = true;
    }

    public void TeleportBallLastPosition()
    {
        TeleportBall(lastBallPosition);
    }

    public void TeleportBall(Vector3 targetPosition)
    {
        var rb = ballController.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballController.transform.position = lastBallPosition;
        rb.isKinematic = false;

        ballController.enabled = true;
        isBallOutside = false;
        isBallTeleporting = false;
    }

    public void UpdateShootCount(int shootCount)
    {
        shootCountText.text = shootCount.ToString();
    }
}
