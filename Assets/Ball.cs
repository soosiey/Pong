using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float speed;
    Vector2 moveVector;
    Rigidbody2D rb;
    float mag;
    public float MAXANGLE;

    void Start()
    {
        transform.position = new Vector3(0,0,0);
        mag = speed * Time.timeScale;
        float startangle = Random.Range(0,2*Mathf.PI);
        moveVector = new Vector2(Mathf.Cos(startangle)*mag,Mathf.Sin(startangle)*mag);
        rb = gameObject.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + moveVector);

    }

    void OnCollisionEnter2D(Collision2D collision){

        ContactPoint2D [] contacts = new ContactPoint2D[2];
        int numContacts = rb.GetContacts(contacts);

        Vector3 normal = contacts[numContacts-1].normal;

        Rigidbody2D otherbody = contacts[numContacts-1].rigidbody;


        if(otherbody.CompareTag("Goal")){
            
            float x = otherbody.transform.position.x;

            if(x < 0){

                GameObject.Find("Right Score").GetComponent<RightScore>().inc();
            }
            else{
                GameObject.Find("Left Score").GetComponent<LeftScore>().inc();
            }
            this.Start();
            return;
        }
        else if(otherbody.CompareTag("Wall")){

            moveVector = Vector2.Reflect(moveVector,normal);
            mag *= 1.05f;
        }
        else if(otherbody.CompareTag("Player")){
            
            Vector2 rigidPoint = otherbody.GetPoint(contacts[numContacts-1].point);
            float heightnorm = otherbody.transform.localScale.y / 2f;
            rigidPoint = rigidPoint / heightnorm;
            float maginc = Mathf.Abs(rigidPoint.y) * .05f;
            mag *= (1f + maginc);

            float newangle = 90 - (rigidPoint.y * MAXANGLE);

            if(otherbody.transform.position.x > 0){
                newangle += 90;
            }
            else{
                newangle -= 90;
            }
            newangle *= Mathf.Deg2Rad;

            moveVector = new Vector2(Mathf.Cos(newangle)*mag, Mathf.Sin(newangle)*mag);
            
        }
        moveVector.Normalize();
        moveVector = moveVector * mag;
        
        
    }

}
