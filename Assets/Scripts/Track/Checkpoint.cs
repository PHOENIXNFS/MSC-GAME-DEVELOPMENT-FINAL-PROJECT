using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private TrackCheckpointManager trackCheckpointManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CarController>(out CarController carController))
        {
            //Debug.Log("Checkpoint Reached");
            trackCheckpointManager.CarPassedCheckpoint(this);
        }
    }

    public void SetCurrentCheckpoint(TrackCheckpointManager trackCheckpointManager)
    {
        this.trackCheckpointManager = trackCheckpointManager;
    }
}
