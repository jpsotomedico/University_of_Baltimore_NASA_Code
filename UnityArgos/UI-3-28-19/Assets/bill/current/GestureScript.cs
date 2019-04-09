using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR.MagicLeap;

public class GestureScript : MonoBehaviour
{
    //spawn vars
    
    public GameObject chair;
    public GameObject ctransform; // camera's transform
    public GameObject prefab;
    Vector3 pos = new Vector3(0, 0.025f, 1.0f);
    private bool spawned = false;
    private bool chairSpawn = false;
    // switch used to only spawn a single object
    GameObject table;
    GameObject _chair;

    GameObject myInstructions;
    
    //gesture vars
    private MLHandKeyPose[] gestures; // Holds the different gestures we will look for

    //revolution vars
    private bool inc = true;
    public float _x;
    public float _z;
    public Quaternion revPos;
    public float radius = 1.0f;
    public float theta =45.0f;
    public int counter = 0;
    public int tableCounter = 0;
    public int tableTotal = 0;

    public float previousTimer = 0f;
    public float nextTimer = 0f;

    public float previousWaitTime = 1f;
    public float nextWaitTime = 1f;

    GameObject lockedCanvas;
    GameObject unlockedCanvas;

    //erver url
    public string screenShotURL = "http://www.my-server.com/cgi-bin/screenshot.pl";
    private bool canTakeScreenShot = true;
    void Awake()
    {
        MLHands.Start(); //start hands api

        gestures = new MLHandKeyPose[8]; //array holding all possible poses
        gestures[0] = MLHandKeyPose.Ok;
        gestures[1] = MLHandKeyPose.Fist;
        gestures[2] = MLHandKeyPose.OpenHandBack;
        gestures[3] = MLHandKeyPose.L;
        gestures[4] = MLHandKeyPose.Thumb;
        gestures[5] = MLHandKeyPose.Pinch;
        gestures[6] = MLHandKeyPose.C;
        gestures[7] = MLHandKeyPose.Finger;
        MLHands.KeyPoseManager.EnableKeyPoses(gestures, true, false);

       
    }

    private void Start()
    {
        lockedCanvas = GameObject.Find("LockedCanvas");
        unlockedCanvas = GameObject.Find("UnlockedCanvas");
    }

    void OnDestroy()
    {
        MLHands.Stop();//when app is closed stop running mlhands
    }

    void Update()
    {

        if (previousTimer > 0)
            previousTimer -= Time.deltaTime;
        if (nextTimer > 0)
            nextTimer -= Time.deltaTime;

        tableTracker();
        screenShot();
        revolution();
        //check to see if right or left hand is giving okay
        if (GetGesture(MLHands.Left, MLHandKeyPose.Ok) || GetGesture(MLHands.Right, MLHandKeyPose.Ok))
        {
            if (spawned == false) // if we have yet to spawn our object
            {
                newSpawn();
                spawned = true;

            }

        }

           // revolution();
           //spawn item
            if(GetGesture(MLHands.Left,MLHandKeyPose.Thumb) || GetGesture(MLHands.Right, MLHandKeyPose.Thumb))
            {
                GameObject go = GameObject.Find("LackTableInstructions(Clone)");
                //if (chairSpawn == false)
                //{
                //    chair = Instantiate(chair, go.transform.position, Quaternion.identity);
                //    GameObject cgo = GameObject.Find("Shell_SwivelChair(Clone)");
                //    cgo.transform.parent = go.transform;
                //    chairSpawn = true;
                //}
                if(table != null)
                    table.GetComponent<InstructionsPanelController>().animButton.onClick.Invoke();
        }


            //push table away, increase radius
            if(GetGesture(MLHands.Left , MLHandKeyPose.OpenHandBack) || GetGesture(MLHands.Right, MLHandKeyPose.OpenHandBack)) // move object awaty from camera
            {
                GameObject go = GameObject.Find("LackTableInstructions(Clone)");
                Vector3 pos = go.transform.position;
                radius += 0.01f;
                _x = radius * Mathf.Sin(theta);
                _z = radius * Mathf.Cos(theta);

                pos.x = _x;
                pos.z = _z;
                go.transform.position = pos;
            }

            //pull table in, dec radius
            if (GetGesture(MLHands.Left, MLHandKeyPose.Fist) || GetGesture(MLHands.Right, MLHandKeyPose.Fist))// move towards camera
            {
                GameObject go = GameObject.Find("LackTableInstructions(Clone)");
                Vector3 pos = go.transform.position;
                radius -= 0.01f;
                _x = radius * Mathf.Sin(theta);
                _z = radius * Mathf.Cos(theta);

                pos.x = _x;
                pos.z = _z;
                go.transform.position = pos;
            }

            //push active item clockwise around orbit
            if (GetGesture(MLHands.Left, MLHandKeyPose.L)) // right to left
            {
                GameObject go = GameObject.Find("LackTableInstructions(Clone)");
                Vector3 pos = go.transform.position;
                theta += 0.0125f;
                _x = radius * Mathf.Sin(theta);
                _z = radius * Mathf.Cos(theta);

                pos.x = _x;
                pos.z = _z;
                go.transform.position = pos;
            }

            //coutnerclockwise around orbit
            if (GetGesture(MLHands.Right, MLHandKeyPose.L)) // left to right?
            {
                GameObject go = GameObject.Find("LackTableInstructions(Clone)");
                Vector3 pos = go.transform.position;
                theta -= 0.0125f;
                _x = radius * Mathf.Sin(theta);
                _z = radius * Mathf.Cos(theta);

                pos.x = _x;
                pos.z = _z;
                go.transform.position = pos;
            }

            //see if we can take and send screen shot
            //if (GetGesture(MLHands.Left, MLHandKeyPose.Finger) && GetGesture(MLHands.Right, MLHandKeyPose.Finger))
            // {
            //    canTakeScreenShot = false;

            //}
            // else
            // {
            //    canTakeScreenShot = true;
            //}

        if(GetGesture(MLHands.Left, MLHandKeyPose.Finger) && previousTimer <= 0)
        {
            if(table != null)
            {
                previousTimer = previousWaitTime;
                table.GetComponent<InstructionsPanelController>().previous.onClick.Invoke();
            }
        }
        if (GetGesture(MLHands.Right, MLHandKeyPose.Finger) && nextTimer <=0 )
        {
            if (table != null)
            {
                nextTimer = nextWaitTime;
                table.GetComponent<InstructionsPanelController>().next.onClick.Invoke();
            }
        }
            //rotacte acitve item 
            if (GetGesture(MLHands.Left, MLHandKeyPose.C) || GetGesture(MLHands.Right, MLHandKeyPose.C))
            {
            //GameObject go = GameObject.Find("LackTableInstructions(Clone)");
            //go.transform.Rotate(Vector3.up, 15.0f);

            }

        //hold to delete
        if (GetGesture(MLHands.Right, MLHandKeyPose.Pinch) || GetGesture(MLHands.Left, MLHandKeyPose.Pinch)) // delete object
            {
                counter++;
                if (counter == 30)
                {
                    GameObject go = GameObject.Find("LackTableInstructions(Clone)");
                    //GameObject cgo = GameObject.Find("Shell_SwivelChair");
                    //chairSpawn = false;
                    Destroy(go);
                    //Destroy(cgo);
                tableTotal--;
                    
                    spawned = false; // allow the object to be spawned again on hand gesture. 
                    counter = 0;
                }
            }

            else
            {
                counter = 0;
            }
            


       // }//end spawned check
    }//end update


 


    //checks gesture to our array
    bool GetGesture(MLHand hand, MLHandKeyPose type)
    {
        if (hand != null)
        {
            if (hand.KeyPose == type)
            {
                if (hand.KeyPoseConfidence > 0.9f)
                {
                    return true;
                }
            }
        }
        return false;
    }//end get gestures


    //create table
    public void newSpawn()
    {
        
        
        
        Vector3 pos1 = transform.position;
        if (table != null)
            Destroy(table);

        table = Instantiate(prefab, /*new Vector3(pos1.x, pos1.y, radius)*/ GameObject.Find("LockedCanvas").transform.position ,Quaternion.identity, unlockedCanvas.transform);
        theta = 0.0f;
       /* GameObject go = GameObject.Find("LackTableInstructions(Clone)");
        Vector3 pos = go.transform.position;
        
        _x = radius * Mathf.Sin(theta+20.0f);
        _z = radius * Mathf.Cos(theta +20.0f);

        pos.x = _x;
        pos.z = _z;
        go.transform.position = pos;*/
    }//end new spawn


    //move table around orbit
    public void revolution()
    {
        if (theta >= 90)
        {
            inc = false;

        }
        else if (theta <= 0)
        {
            inc = true;
        }
       
    }

    //limit tables created
    public void tableTracker()
    {
        if (spawned == true && tableTotal < 1)
        {
            
            tableCounter++;
        }
        if (tableCounter > 100)
        {
            tableTotal++;
            spawned = false;
            tableCounter = 0;
        }
        if (tableTotal >= 4)
        {
            spawned = true;
        }
    }

    //if else tracker for screenshots
    public void screenShot()
    {
        if (canTakeScreenShot)
        {
            UploadPNG();
        }
        else
        {
            return;
        }
    }

    //screenshot/upload
    IEnumerator UploadPNG()
    {
        // We should only read the screen after all rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, in RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);

        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("fileUpload", bytes, "screenShot.png", "image/png");

        // Upload to a cgi script
        using (var w = UnityWebRequest.Post(screenShotURL, form))
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                print(w.error);
            }
            else
            {
                print("Finished Uploading Screenshot");
            }
        }
    }






}//end class

    