using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + new Vector3(0, 1, 0);
    }
}
