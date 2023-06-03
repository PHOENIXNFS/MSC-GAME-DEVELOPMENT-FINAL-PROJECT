using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRespawner : MonoBehaviour
{
    [SerializeField] Transform VehicleTarget;

    private void FixedUpdate()
    {
        HandleVehicleRespawn();
    }

    private void HandleVehicleRespawn()
    {
        if (VehicleTarget.rotation.z >= 90f || VehicleTarget.rotation.z <= -90f)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Vector3 eulerRotation = VehicleTarget.rotation.eulerAngles;
                VehicleTarget.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0f);
            }
        }
    }
}
