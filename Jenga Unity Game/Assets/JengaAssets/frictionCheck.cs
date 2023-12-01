using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class frictionCheck : MonoBehaviour
{
    private float ogFriction;
    private float ogStaticFric;

    private int sceneIndex;
    // scene 1 is normal mode 
    //scene 2 is hard mode

    // the values for the normal mode for frition
    private float normalStaticFriction=0f;
    private float normalDynamicFriction=0f;

    // the values for the hard mode for frition
    private float hardStaticFriction=0.3f;
    private float hardDynamicFriction=0.3f;

    // the variables to hold for this mode
    private float collisionStaticFriction;
    private float collisionDyanmicFriction;

    void Start(){


        Physics.gravity = new Vector3(0, -6f, 0);


        // get orignal friction of the object 
        ogFriction = GetComponent<Collider>().material.dynamicFriction;
        ogStaticFric = GetComponent<Collider>().material.staticFriction;


        // Get the index of the current active scene to determine if its the hard or easy mode
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current scene index: " + sceneIndex);


        // depednign on the scene(normal or hard) set the collision friction
        if (sceneIndex==1){
            collisionStaticFriction = normalStaticFriction;
            collisionDyanmicFriction = normalDynamicFriction;
        }else{
            collisionStaticFriction = hardStaticFriction;
            collisionDyanmicFriction = hardDynamicFriction;
            darkenMaterial();

        }

    }

    //Function to darkne the material of this object
    private void darkenMaterial(){
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color(0.1f, 0.7f, 0.9f);

        //rend.material.EnableKeyword("_EMISSION");
    }


    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Player") { 
            Debug.Log("collison with player enter" +  collision.gameObject.tag);
            // set to the type of friction 
            GetComponent<Collider>().material.dynamicFriction = collisionStaticFriction;
            GetComponent<Collider>().material.staticFriction = collisionDyanmicFriction;
        }
    }

    void OnCollisionExit(Collision collision){
        if (collision.gameObject.tag == "Player") { 
            Debug.Log("Exit collison with player exit " + collision.gameObject.tag);
            GetComponent<Collider>().material.dynamicFriction = ogFriction;
            GetComponent<Collider>().material.staticFriction = ogStaticFric;
        }
    }
}
