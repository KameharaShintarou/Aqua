using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    enum KeyColor
    {
        Bronze,
        Silver,
        Gold,
    }

    [SerializeField]
    KeyColor keyColor;

    [SerializeField]
    StageController StageController;

    [SerializeField]
    MeshRenderer MeshRenderer;

    [SerializeField]
    Material[] Materials;

    //void Awake()
    //{
    //}

    void OnValidate()
    {
        switch (keyColor)
        {
            case KeyColor.Bronze:
                MeshRenderer.material = Materials[0];
                break;
            case KeyColor.Silver:
                MeshRenderer.material = Materials[1];
                break;
            case KeyColor.Gold:
                MeshRenderer.material = Materials[2];
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player.GetIsPlaying())
            {
                StageController.GetKey();
                Destroy(gameObject);
            }
        }
    }
}
