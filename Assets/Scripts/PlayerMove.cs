using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float forward_speed=5;
    [SerializeField] float direction_speed=10;
    [SerializeField] AudioSource coin;
    [SerializeField] AudioSource hit;
    [SerializeField] AudioSource back_ground_music;
    [SerializeField] int number_of_gold = 0;
    Animator player_animator;
    float line_x = 3.5f;
    int line_number = 0;
    bool is_alive = true;
    void Start()
    {
        player_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_alive)
        {
            // this.transform.Translate(Vector3.forward* speed * Time.deltaTime,Space.World);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                line_number++;
                if (line_number > 1)
                {
                    line_number = 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                line_number--;
                if (line_number < -1)
                {
                    line_number = -1;
                }
            }

            this.transform.Translate(Vector3.forward * forward_speed * Time.deltaTime, Space.World);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(line_x * line_number, transform.position.y, transform.position.z), Time.deltaTime * direction_speed);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("gold"))
        {
            coin.Play();
            Destroy(other.gameObject);
            number_of_gold++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("obstacle")) {
            Debug.Log("Lose");
            is_alive = false;
            back_ground_music.Stop();

            hit.Play();
            player_animator.Play("lose");
        }
    }

}
