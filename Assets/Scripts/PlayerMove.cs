using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{

    [SerializeField] float forward_speed=5;
    [SerializeField] float direction_speed=10;
    [SerializeField] AudioSource coin;
    [SerializeField] AudioSource hit;
    [SerializeField] AudioSource back_ground_music;
    [SerializeField] int number_of_gold = 0;
    [SerializeField] Text gold_number_text;
    [SerializeField] Text score_number_text;
    [SerializeField] Text lose_gold_number_text;
    [SerializeField] Text lose_score_number_text;
    [SerializeField] GameObject gameover_panel_game_object;
    Animator player_animator;
    float line_x = 3.5f;
    int line_number = 0;
    public bool is_alive = true;

    public bool mag_active = false;
    [SerializeField]private float mag_time = 30;
     private float remaining_mag_time=0;

    [SerializeField] private float apple_time = 30;
    private float remaining_apple_time = 0;
    private CapsuleCollider player_colider;
    private bool in_obstacle = false;

    private Vector3 player_start_pos;
    void Start()
    {
        player_animator = GetComponent<Animator>();
        gold_number_text.text = "0";

        gameover_panel_game_object.SetActive(false);
        player_colider= GetComponent<CapsuleCollider>();
        player_start_pos=transform.position;
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
            score_number_text.text = ((int)Vector3.Distance(player_start_pos, transform.position)).ToString();
        }
        if (mag_active == true)
        {
            remaining_mag_time -= Time.deltaTime;
            if(remaining_mag_time <= 0)
            {
                mag_active = false;
                remaining_mag_time = 0;
                Debug.Log("mag ended");
            }
        }
        if(remaining_apple_time > 0)
        {
            remaining_apple_time -= Time.deltaTime;

            if(remaining_apple_time <= 0)
            {
                if (in_obstacle == false)
                {
                    player_colider.isTrigger = false;
                }


                  remaining_apple_time = 0;
                Debug.Log("apple ended");
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (is_alive)
        {
            if (other.transform.CompareTag("gold"))
            {
                coin.Play();
                Destroy(other.gameObject);
                number_of_gold++;
                gold_number_text.text = number_of_gold.ToString();
            }
            if (other.transform.CompareTag("mag"))
            {
                Destroy(other.gameObject);
                mag_active = true;

                remaining_mag_time = mag_time;
            }
            if (other.transform.CompareTag("apple"))
            {

                Destroy(other.gameObject);
                player_colider.isTrigger = true;
                remaining_apple_time = apple_time;
            }
            if (other.transform.CompareTag("obstacle"))
            {
                in_obstacle = true;
            }
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("obstacle"))
        {
            in_obstacle = false;
            if (remaining_apple_time <= 0 && player_colider.isTrigger == true)
            {
                player_colider.isTrigger = false;
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("obstacle")) {
            lose_gold_number_text.text= number_of_gold.ToString();
            lose_score_number_text.text = ((int)Vector3.Distance(player_start_pos, transform.position)).ToString();
            is_alive = false;
            player_animator.SetBool("is_alive",false);
            //Debug.Log("Lose");
            back_ground_music.Stop();

            hit.Play();
            gameover_panel_game_object.SetActive(true);
        }
    }

}
