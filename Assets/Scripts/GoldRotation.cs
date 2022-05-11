using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldRotation : MonoBehaviour
{
    [SerializeField] float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(90,0,0)*speed*Time.deltaTime);
    }
}
