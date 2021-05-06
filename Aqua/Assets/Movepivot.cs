using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movepivot : MonoBehaviour
{
    private Vector3 target;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time)*speed+target.x, target.y, target.z);
    }
}
