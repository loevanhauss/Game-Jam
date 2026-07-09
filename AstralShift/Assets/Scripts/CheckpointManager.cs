using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    private Vector3 dernierCheckpoint;

    private void Awake()
    {
        instance = this;
        dernierCheckpoint = FindFirstObjectByType<MovementPlayer>().transform.position;
    }

    public void SetCheckpoint(Vector3 position)
    {
        dernierCheckpoint = position;
    }

    public Vector3 GetCheckpoint()
    {
        return dernierCheckpoint;
    }
}