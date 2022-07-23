using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Rigidbody2D rb;
    public KeyCode up;
    public KeyCode down;
    public float startpointx;
    public float startpointy;
    public bool ai;
    float timestart;
    void Start()
    {
        transform.position = new Vector3((float)startpointx,(float)startpointy,0);

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.position = new Vector2((float)7.8,0);
        timestart = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ai){
            if (Input.GetKey (up)) {

                rb.MovePosition(rb.position + new Vector2(0,speed*Time.deltaTime));
                
            } else if (Input.GetKey (down)) {
                rb.MovePosition(rb.position + new Vector2(0,-speed*Time.deltaTime));
                
            }
            else{
                rb.velocity = new Vector2(0,0);
            }
        
        }
        else{

            Vector3 ballpoint = GameObject.Find("Ball").transform.position;

            if(timestart < 1.0f){
                timestart += Time.deltaTime;
                return;
            }

            if(ballpoint.y > transform.position.y){

                rb.MovePosition(rb.position + new Vector2(0,speed*Time.deltaTime));
            }
            else if(ballpoint.y < transform.position.y){

                rb.MovePosition(rb.position + new Vector2(0,-speed*Time.deltaTime));
            }
            else{
                rb.velocity = new Vector2(0,0);
            }
        }
    }
}
