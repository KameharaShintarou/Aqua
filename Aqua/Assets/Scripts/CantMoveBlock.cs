using UnityEngine;

public class CantMoveBlock : MonoBehaviour
{
    [SerializeField]
    GameObject BlockPrefab;

    [SerializeField]
    GameObject BlocksParent;

    void Awake()
    {
        Instantiate(BlockPrefab,
            -transform.position,
            Quaternion.EulerAngles(Vector3.zero),
            BlocksParent.transform);
    }
}
