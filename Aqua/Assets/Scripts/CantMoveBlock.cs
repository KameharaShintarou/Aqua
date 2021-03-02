using UnityEngine;

public class CantMoveBlock : MonoBehaviour
{
    [SerializeField]
    GameObject BlockPrefab;

    [SerializeField]
    GameObject BlocksParent;

    void Awake()
    {
        Vector3 position = new Vector3(
            -transform.position.x,
            -transform.position.y,
             transform.position.z);

        Instantiate(BlockPrefab,
            position,
            Quaternion.EulerAngles(Vector3.zero),
            BlocksParent.transform);
    }
}
