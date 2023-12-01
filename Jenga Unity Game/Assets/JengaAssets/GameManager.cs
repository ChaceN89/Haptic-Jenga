using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // pass the block object here
    public GameObject block; // Assign your pause menu UI to this in the Inspector

    // number of layers
    public int layers = 6;
    public float yInterval = 0.205f;
    public float horzontalSeparation = 0.25f;

    // scales for the instantiated block - will get from the block in the start function
    private float xBlockScale = 0.2f;
    private float yBlockScale = 0.2f;
    private float zBlockScale = 0.7f;

    // value of the potential minimum y scale of a block 
    public float yScaleShrink = 0.02f;

    // lsit of blocks that have bee created
    private List<GameObject> instantiatedBlocks = new List<GameObject>(); // Track the instantiated blocks

    // start fucntio nto create the tower initially
    public void Start(){
        // CreateTower();
        createTowerWithRandomness();


        // Get the scale of the block object
        Vector3 blockScale = block.transform.localScale;

        // Assign the obtained scales to the global variables
        xBlockScale = blockScale.x;
        yBlockScale = blockScale.y;
        zBlockScale = blockScale.z;
        Debug.Log("xBlockScale "+ xBlockScale);
        Debug.Log("yBlockScale "+ yBlockScale);
        Debug.Log("zBlockScale "+ zBlockScale);
    }

    // update to catch if the game needs to be reset
    private void Update(){

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
    }

    // reset the game
    public void ResetGame(){
        // destroy the tower and then rebuild it
        DestroyTower();
        // CreateTower();
        createTowerWithRandomness();
    }


    // Function to destroy all the instantiated blocks
    private void DestroyTower(){
        // for every block in the list destory it
        foreach (GameObject block in instantiatedBlocks){
            Destroy(block);
        }
        instantiatedBlocks.Clear(); // Clear the list after destroying all the blocks
    }



    // creat the tower with slid randomness in the size of the blocks
    private void createTowerWithRandomness(){
        // boolean to determine if layer should be rotated or not
        bool rotate = false;

        // position of the game object (0, y_interval, 0)
        float yPosition = yInterval;

        // loop trhough the layers creating 3 blocks for each layer
        for (int i = 0; i < layers; i++){

            // set position for the middle block - independent of rotation
            Vector3 customPosition1 = new Vector3(0, yPosition, 0);

            // two positions that will change depending on the layer being rotated or not
            Vector3 customPosition2;
            Vector3 customPosition3;
            
            // rotation that will change depending on the layer being rotated or not
            Quaternion customRotation;

            // get positions and rotations for block depending on if this layer is rotated or not
            if (rotate){

                // Create the rotated position of the two side blocks
                customPosition2 = new Vector3(0, yPosition, -horzontalSeparation);
                customPosition3 = new Vector3(0, yPosition, horzontalSeparation);

                // create a rotation for  the block
                customRotation = Quaternion.Euler(0, 90, 0); 

            }else{

                // Set the Position of the blocks on the side
                customPosition2 = new Vector3(-horzontalSeparation, yPosition, 0);
                customPosition3 = new Vector3(horzontalSeparation, yPosition, 0);
   
                // rotation is nothing
                customRotation = Quaternion.identity;
   
            }

             // create 3 blocks
            GameObject block1 = Instantiate(block, customPosition1, customRotation);
            GameObject block2 = Instantiate(block, customPosition2, customRotation);
            GameObject block3 = Instantiate(block, customPosition3, customRotation);

            // select 1 of the blocks to havea  smaller y scale
            int randomIndex = Random.Range(0, 3);

            // Create 3 random yBlockScales (the y scale - the shrink scale)
            float randomyBlockScale1 = yBlockScale;
            float randomyBlockScale2 = yBlockScale;
            float randomyBlockScale3 = yBlockScale;

            // Set one of the variables to a lower value
            switch (randomIndex){
                case 0:
                    randomyBlockScale1 = yBlockScale - yScaleShrink;
                    break;
                case 1:
                    randomyBlockScale2 = yBlockScale - yScaleShrink;
                    break;
                case 2:
                    randomyBlockScale3 = yBlockScale - yScaleShrink;
                    break;
            }

            // // create 3 random yBlockScales  ( the y scale - the shrink scale)
            // float randomyBlockScale1 = Random.Range(yBlockScale - yScaleShrink, yBlockScale);
            // float randomyBlockScale2 = Random.Range(yBlockScale - yScaleShrink, yBlockScale);
            // float randomyBlockScale3 = Random.Range(yBlockScale - yScaleShrink, yBlockScale);

            // transform the Y scale of the 3 blcoks
            block1.transform.localScale = new Vector3(xBlockScale, randomyBlockScale1, zBlockScale); 
            block2.transform.localScale = new Vector3(xBlockScale, randomyBlockScale2, zBlockScale); 
            block3.transform.localScale = new Vector3(xBlockScale, randomyBlockScale3, zBlockScale); 
                               
            // add the blcoks to the list of instantiated blocks
            instantiatedBlocks.Add(block1);
            instantiatedBlocks.Add(block2);
            instantiatedBlocks.Add(block3);

            // increae the height for the next layer
            yPosition += yInterval; 

            // flip rotate bool so the next layer is rotated 90 degrees
            rotate = !rotate;
        }
    }

}


// /**


// old createTower code

//     // fucntion to create the tower with stand
//     private void CreateTower(){

//         // boolean to determine if layer shoulf be rotated or not
//         bool rotate = false;

//         // position of the game object (0,y_interval,0)
//         float yPosition = yInterval;


//         // loop trhough the layers 
//         for (int i = 0; i < layers; i++){

//             // create 3 blocks side by side by side
//             if (rotate){

//                 // create a rotation and position for the first block
//                 Quaternion customRotation1 = Quaternion.Euler(0, 90, 0); // Define the custom rotation here
//                 Vector3 customPosition1 = new Vector3(0, yPosition, 0);

//                 // create a rotation and position for the side block
//                 Quaternion customRotation2 = Quaternion.Euler(0, 90, 0); // Define the custom rotation here
//                 Vector3 customPosition2 = new Vector3(0, yPosition, -1f*horzontalSeparation);
                
//                 // create a rotation and position for the other side block
//                 Quaternion customRotation3 = Quaternion.Euler(0, 90, 0); // Define the custom rotation here
//                 Vector3 customPosition3 = new Vector3(0, yPosition, horzontalSeparation);

//                 // instantiate the block and add to list of blocks
//                 instantiatedBlocks.Add(Instantiate(block, customPosition1, customRotation1));
//                 instantiatedBlocks.Add(Instantiate(block, customPosition2, customRotation2));
//                 instantiatedBlocks.Add(Instantiate(block, customPosition3, customRotation3));


//             }else{
//                 // block in the middle position
//                 Vector3 customPosition1 = new Vector3(0, yPosition, 0);
//                 // side block position
//                 Vector3 customPosition2 = new Vector3(-1f*horzontalSeparation, yPosition, 0);
//                 // other side block position
//                 Vector3 customPosition3 = new Vector3(horzontalSeparation, yPosition, 0);

//                 // instantiate the block and add to list of blocks
//                 instantiatedBlocks.Add(Instantiate(block, customPosition1, Quaternion.identity));
//                 instantiatedBlocks.Add(Instantiate(block, customPosition2, Quaternion.identity));
//                 instantiatedBlocks.Add(Instantiate(block, customPosition3, Quaternion.identity));
//             }

//             // increae the height for the next layer
//             yPosition += yInterval; 

//             // flip rotate bool so the next layer is rotated 90 degrees
//             rotate = !rotate;
//         }
//     }
// */