using UnityEngine;

public enum BlockType
{
    Move,
    Fixed,
}

public class Block : MonoBehaviour
{
    [SerializeField]
    Material MoveBlockMaterial;

    [SerializeField]
    MeshRenderer MeshRenderer;

    [SerializeField]
    GameObject BlockPrefab;

    [SerializeField]
    GameObject BlocksParent;

    [SerializeField]
    bool isWall;

    [SerializeField]
    BlockType BlockType;

    [SerializeField]
    BlockType CopyType;

    [SerializeField]
    bool isCopy;

    void Awake()
    {
        if (!isCopy)
        {
            if (!isWall)
            {
                Vector3 position = new Vector3(
                    -transform.position.x,
                    -transform.position.y,
                     transform.position.z);

                GameObject blockCopy = Instantiate(
                                        BlockPrefab,
                                        position,
                                        Quaternion.EulerAngles(Vector3.zero),
                                        BlocksParent.transform);

                MoveBlock moveBlock;
                MoveBlock moveBlockCopy;

                if (BlockType == BlockType.Move)
                {
                    moveBlock = gameObject.AddComponent<MoveBlock>();
                    moveBlock.SetLinkBlock(blockCopy);
                    moveBlock.SetIsWall(isWall);

                    gameObject.tag = "MoveBlock";
                    ChangeMaterial();
                }
                if (CopyType == BlockType.Move)
                {
                    moveBlockCopy = blockCopy.AddComponent<MoveBlock>();
                    moveBlockCopy.SetLinkBlock(gameObject);
                    moveBlockCopy.SetIsWall(isWall);

                    blockCopy.tag = "MoveBlock";
                    blockCopy.GetComponent<Block>().ChangeMaterial();
                }
            }
        }
    }

    void ChangeMaterial()
    {
        MeshRenderer.material = MoveBlockMaterial;
    }
}
