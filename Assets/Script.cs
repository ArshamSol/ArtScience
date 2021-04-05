using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using System;
using UnityEngine.UI;
public class Script : MonoBehaviour
{
    float lastY = 0;
    int UpCount = 0;
    Finger THUMB, INDEX, MIDDLE, PINKY, RING;
   
    // Start is called before the first frame update
    void Start()
    {
        Controller controller = new Controller();


        controller.FrameReady += OnFrame;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject RightHand = GameObject.FindGameObjectWithTag("RightPalm");
        
        if (THUMB != null&&INDEX!=null)
        {
            float m= (THUMB.TipPosition - INDEX.TipPosition).Magnitude;
            //GameObject.FindGameObjectWithTag("text").GetComponent<Text>().text= m.ToString();
            if (m< 27)
            {
                //this is pinch
            }
        }
        if (THUMB != null && MIDDLE != null)
        {
            float m = (THUMB.TipPosition - MIDDLE.TipPosition).Magnitude;
            //GameObject.FindGameObjectWithTag("text").GetComponent<Text>().text = m.ToString();
            if (m < 27)
            {
                //When middle attach to the thumb
            }
        }
        if (THUMB != null && PINKY != null)
        {
            float m = (THUMB.TipPosition - PINKY.TipPosition).Magnitude;
            GameObject.FindGameObjectWithTag("text").GetComponent<Text>().text = m.ToString();
            if (m < 90)
            {
                //When PINKY attach to the thumb
            }
        }
        if (THUMB != null && RING != null)
        {
            float m = (THUMB.TipPosition - RING.TipPosition).Magnitude;
            GameObject.FindGameObjectWithTag("text").GetComponent<Text>().text = m.ToString();
            if (m < 40)
            {
                //When RING attach to the thumb
            }
        }
    }
    public void OnFrame(object sender, FrameEventArgs args)
    {
       
        Frame frame = args.frame;
       
        List<Hand> hands= frame.Hands;
        if (hands.Count != 0)
        {
            List < Finger > fing= hands[0].Fingers;
            for (int i = 0; i < fing.Count; i++)
            {
                if (fing[i].Type == Finger.FingerType.TYPE_THUMB)
                {
                    THUMB = fing[i];
                   
                }

                if (fing[i].Type == Finger.FingerType.TYPE_INDEX)
                {
                    INDEX = fing[i];
                    
                }
                if (fing[i].Type == Finger.FingerType.TYPE_MIDDLE)
                {
                    MIDDLE = fing[i];

                }
                if (fing[i].Type == Finger.FingerType.TYPE_PINKY)
                {
                    PINKY = fing[i];

                }
                if (fing[i].Type == Finger.FingerType.TYPE_RING)
                {
                    PINKY = fing[i];

                }
            }
           
            
        }
    }
}
