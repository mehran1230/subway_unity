using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float forward_speed=5;
    [SerializeField] float direction_speed=10;
    float line_x = 3.5f;
    int line_number = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.Translate(Vector3.forward* speed * Time.deltaTime,Space.World);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            line_number++;
            if(line_number > 1)
            {
                line_number = 1;
            }
        }else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
           line_number--;
            if(line_number < -1)
            {
                line_number = -1;
            }
        }

        this.transform.Translate(Vector3.forward * forward_speed * Time.deltaTime, Space.World);
        transform.position = Vector3.MoveTowards(transform.position,  new Vector3(line_x*line_number, transform.position.y, transform.position.z), Time.deltaTime * direction_speed);


    }
   
}
