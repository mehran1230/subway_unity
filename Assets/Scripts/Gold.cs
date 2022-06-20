using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 15;
    [SerializeField] private float Distance = 40;
    private PlayerMove player_script;
    private Vector3 current_pos;
    private Vector3 player_pos;
    void Start()
    {
        player_script = GameObject.FindGameObjectWithTag("Character").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_script.mag_active==true && player_script.is_alive==true)
        {
            current_pos= transform.position;
            player_pos = player_script.gameObject.transform.position;
            if (Vector3.Distance(current_pos,player_pos)<=Distance) {
                transform.position = Vector3.MoveTowards(current_pos, player_pos, speed * Time.deltaTime);
            }
        }
        
    }
}
