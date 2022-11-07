using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_controller : MonoBehaviour
{
    bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey("right")){
            gameObject.transform.Translate(5f * Time.deltaTime, 0,0);
        }

        if(Input.GetKey("left")){
            gameObject.transform.Translate(-5f * Time.deltaTime, 0,0);
        }

        if(Input.GetKey("up") && canJump){
            gameObject.transform.Translate(0, 15f * Time.deltaTime,0);
            if(gameObject.transform.position.y > (150f * Time.deltaTime)){ 
                canJump = false;
            }
        }
    }        

    private void OnCollisionEnter2D(Collision2D other) {    
        if (other.transform.tag == "floor"){
            canJump = true;
        }
    }
}
