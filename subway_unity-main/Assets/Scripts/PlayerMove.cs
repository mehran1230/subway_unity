using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float forward_speed=5;
    [SerializeField] float direction_speed=10;
    float line_x = 3.5f;
    int line_number = 0;
    private int score=0;
    private bool alive=true;
    private AudioSource audioSource;
    public AudioClip[] clips; // 0-hit 1-CoinAudio
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alive){
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

    void OnCollisionEnter(Collision collision) {
        Debug.Log("collision!!!!!!!");
        if(collision.transform.tag=="Train"){
            alive=false;
            audioSource.clip=clips[0];
            audioSource.Play();
            Debug.Log("GameOver");
        }
    }

    private void OnTriggerEnter(Collider collision){
       if(collision.transform.tag=="Coin"){
           Debug.Log("!!!Coin!!!");
           audioSource.clip=clips[1];
           audioSource.Play();
           score++;
           Debug.Log("Score"+score);
           Destroy(collision.gameObject);
       }
   }

}
