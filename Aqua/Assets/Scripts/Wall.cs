using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    Material MoveBlockMaterial;

    [SerializeField]
    MeshRenderer[] MeshRenderers;

    [SerializeField]
    GameObject BlockPrefab;

    [SerializeField]
    GameObject BlocksParent;

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
                moveBlock.SetIsWall(false);

                gameObject.tag = "MoveBlock";
                ChangeMaterial();
            }
            if (CopyType == BlockType.Move)
            {
                moveBlockCopy = blockCopy.AddComponent<MoveBlock>();
                moveBlockCopy.SetLinkBlock(gameObject);
                moveBlockCopy.SetIsWall(false);

                blockCopy.tag = "MoveBlock";
                blockCopy.GetComponent<Wall>().ChangeMaterial();
            }
        }
    }

    void ChangeMaterial()
    {
        foreach (MeshRenderer meshRenderer in MeshRenderers)
        {
            meshRenderer.material = MoveBlockMaterial;
        }
    }
}
