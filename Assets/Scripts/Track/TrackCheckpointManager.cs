using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpointManager : MonoBehaviour
{
    //public event EventHandler OnPlayerCorrectCheckpoint;
    //public event EventHandler OnPlayerWrongCheckpoint;
    
    private List<Checkpoint> checkpointList;
    private int nextCheckpointIndex;
        
    private void Awake()
    {
        Transform CheckpointTransforms = transform.Find("Checkpoints");

        checkpointList = new List<Checkpoint>();

        foreach (Transform CheckpointTransform in CheckpointTransforms)
        {
            //Debug.Log(CheckpointTransform);
            Checkpoint checkpoint = CheckpointTransform.GetComponent<Checkpoint>();
            checkpoint.SetCurrentCheckpoint(this);
            checkpointList.Add(checkpoint);

            nextCheckpointIndex = 0;
        }
    }

    public void CarPassedCheckpoint(Checkpoint checkpoint)
    {
        if (checkpointList.IndexOf(checkpoint) == nextCheckpointIndex)
        {
            Debug.Log("Correct Checkpoint");
            nextCheckpointIndex = (nextCheckpointIndex + 1) % checkpointList.Count;
        }

        else
        {
            Debug.Log("Wrong Checkpoinr");
        }

    }
}
