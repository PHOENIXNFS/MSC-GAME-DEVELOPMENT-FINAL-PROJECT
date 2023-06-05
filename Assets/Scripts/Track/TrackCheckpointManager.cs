using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpointManager : MonoBehaviour
{
    //public event EventHandler OnPlayerCorrectCheckpoint;
    //public event EventHandler OnPlayerWrongCheckpoint;

    [SerializeField] private List<Transform> RacersTransformList;
    private List<Checkpoint> checkpointList;
    private List<int> nextCheckpointIndexList;
        
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

            nextCheckpointIndexList = new List<int>();
            foreach (Transform racerTransform in RacersTransformList)
            {
                nextCheckpointIndexList.Add(0);
            }
        }
    }

    public void CarPassedCheckpoint(Checkpoint checkpoint, Transform racerTransform)
    {
        int nextCheckpointIndex = nextCheckpointIndexList[RacersTransformList.IndexOf(racerTransform)];

        if (checkpointList.IndexOf(checkpoint) == nextCheckpointIndex)
        {
            Debug.Log("Correct Checkpoint");
            nextCheckpointIndexList[RacersTransformList.IndexOf(racerTransform)] = (nextCheckpointIndex + 1) % checkpointList.Count;
        }

        else
        {
            Debug.Log("Wrong Checkpoinr");
        }

    }
}
