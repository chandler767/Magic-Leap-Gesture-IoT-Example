using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using PubNubAPI;


public class GestureScript : MonoBehaviour {

    public Text instuctText;
    public float instuctTextTimeLeft  = 1.0f; // Transition color on scene load.
    public Text onText;
    public Image onGesture;
    public float onTimeLeft;
    public Text offText;
    public Image offGesture;
    public float offTimeLeft;
    public Text changeText;
    public Image changeGesture;
    public float changeTimeLeft;

    public float sendTimeController;

    public static PubNub pubnub;

    private MLHandKeyPose[] gestures; // Holds the different hand poses we will look for.

    void Awake ()
    {
        
        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-931b4ee3-e758-4c5d-b6b9-1133c03e4f20";
        pnConfiguration.SubscribeKey = "sub-c-83a10382-b06a-11e8-96e7-b288138ed50a";
        pnConfiguration.Secure = true;
        pubnub = new PubNub(pnConfiguration);

        instuctText = GameObject.Find("InstuctText").GetComponent<Text>();
        onText = GameObject.Find("OnText").GetComponent<Text>();
        onGesture = GameObject.Find("onGesture").GetComponent<Image>();
        offText = GameObject.Find("OffText").GetComponent<Text>();
        offGesture = GameObject.Find("offGesture").GetComponent<Image>();
        changeText = GameObject.Find("ChangeText").GetComponent<Text>();
        changeGesture = GameObject.Find("changeGesture").GetComponent<Image>();

        MLHands.Start(); // Start the hand tracking.
        gestures = new MLHandKeyPose[3]; //Assign the gestures we will look for.
        gestures[0] = MLHandKeyPose.Fist;
        gestures[1] = MLHandKeyPose.Thumb;
        gestures[2] = MLHandKeyPose.Finger;
        MLHands.KeyPoseManager.EnableKeyPoses(gestures, true, false); // Enable the hand poses.
    }
    
    void OnDestroy()
    {
        MLHands.Stop();
    }

    void Update()
    {

        if (sendTimeController <= Time.deltaTime) { // Restrict how often messages can be sent.
            if (GetGesture(MLHands.Left, MLHandKeyPose.Thumb) || GetGesture(MLHands.Right, MLHandKeyPose.Thumb)) {
                pubnub.Publish()
                    .Channel("control")
                    .Message("on")
                    .Async((result, status) => {    
                        if (!status.Error) {
                            Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                        } else {
                            Debug.Log(status.Error);
                            Debug.Log(status.ErrorData.Info);
                        }
                    });
                onText.color = Color.green; // Set color to green.
                onGesture.color = Color.green; // Set color to green.
                onTimeLeft = 1.0f; // Transition color back to white.
                sendTimeController = 0.1f; // Stop multiple messages from being sent.
            } else if (GetGesture(MLHands.Left, MLHandKeyPose.Fist) || GetGesture(MLHands.Right, MLHandKeyPose.Fist)) {
                pubnub.Publish()
                    .Channel("control")
                    .Message("off")
                    .Async((result, status) => {    
                        if (!status.Error) {
                            Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                        } else {
                            Debug.Log(status.Error);
                            Debug.Log(status.ErrorData.Info);
                        }
                    });
                offText.color = Color.green; // Set color to green.
                offGesture.color = Color.green; // Set color to green.
                offTimeLeft = 1.0f; // Transition color back to white.
                sendTimeController = 0.1f; // Stop multiple messages from being sent.
            } else if (GetGesture(MLHands.Left, MLHandKeyPose.Finger)) {
                pubnub.Publish()
                    .Channel("control")
                    .Message("changel")
                    .Async((result, status) => {    
                        if (!status.Error) {
                            Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                        } else {
                            Debug.Log(status.Error);
                            Debug.Log(status.ErrorData.Info);
                        }
                    });
                changeText.color = Color.green; // Set color to green.
                changeGesture.color = Color.green; // Set color to green.
                changeTimeLeft = 1.0f; // Transition color back to white.
                sendTimeController = 0.9f; // Stop multiple messages from being sent.
            } else if (GetGesture(MLHands.Right, MLHandKeyPose.Finger)) {
                pubnub.Publish()
                    .Channel("control")
                    .Message("changer")
                    .Async((result, status) => {    
                        if (!status.Error) {
                            Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                        } else {
                            Debug.Log(status.Error);
                            Debug.Log(status.ErrorData.Info);
                        }
                    });
                changeText.color = Color.green; // Set color to green.
                changeGesture.color = Color.green; // Set color to green.
                changeTimeLeft = 1.0f; // Transition color back to white.
                sendTimeController = 0.9f; // Stop multiple messages from being sent.
            }
        } else {
            sendTimeController -= Time.deltaTime; // Update the timer.
        }

        if (instuctTextTimeLeft > Time.deltaTime) {
            instuctText.color = Color.Lerp(instuctText.color, Color.white, Time.deltaTime / instuctTextTimeLeft); // Calculate interpolated color.
            instuctTextTimeLeft -= Time.deltaTime; // Update the timer.
        }
        if (onTimeLeft > Time.deltaTime) {
            onText.color = Color.Lerp(onText.color, Color.white, Time.deltaTime / onTimeLeft); // Calculate interpolated color.
            onGesture.color = Color.Lerp(onGesture.color, Color.white, Time.deltaTime / onTimeLeft); // Calculate interpolated color.
            onTimeLeft -= Time.deltaTime; // Update the timer.
        }
        if (offTimeLeft > Time.deltaTime) {
            offText.color = Color.Lerp(offText.color, Color.white, Time.deltaTime / offTimeLeft); // Calculate interpolated color.
            offGesture.color = Color.Lerp(offGesture.color, Color.white, Time.deltaTime / offTimeLeft); // Calculate interpolated color.
            offTimeLeft -= Time.deltaTime; // Update the timer.
        }
        if (changeTimeLeft > Time.deltaTime) {
            changeText.color = Color.Lerp(changeText.color, Color.white, Time.deltaTime / changeTimeLeft); // Calculate interpolated color.
            changeGesture.color = Color.Lerp(changeGesture.color, Color.white, Time.deltaTime / changeTimeLeft); // Calculate interpolated color.
            changeTimeLeft -= Time.deltaTime; // Update the timer.
        }
    }

    bool GetGesture(MLHand hand, MLHandKeyPose type)
    {
        if (hand != null)
        {
            if (hand.KeyPose == type)
            {
                if (hand.KeyPoseConfidence > 0.98f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
