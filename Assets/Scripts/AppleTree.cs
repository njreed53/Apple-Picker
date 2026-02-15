using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject branchPrefab;
    [Range(0f,1f)]
    public float branchChance = 0.1f;
    public float speed = 16f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public int c = 0;
    void Start()
    {
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject drop;
        if(UnityEngine.Random.value < branchChance)
        {
            drop = Instantiate(branchPrefab);
        }
        else
        {
            drop = Instantiate(applePrefab);
            c++;
        }

        if(c == 5)
        {
            FindObjectOfType<GameManager>().NextRound();
            IncreaseDifficulty();
            c=0;
        }
        drop.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    public void IncreaseDifficulty()
    {
        if(speed >= 0)
        {
            speed+=4;
        }
        else
        {
            speed-=4;
        }
        appleDropDelay -= 0.1f;

        if(appleDropDelay <0.4f){
            appleDropDelay = 0.4f;
        }
    }
    public void ResetDifficulty()
    {
        speed = 16f;
        appleDropDelay = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        //} else if (UnityEngine.Random.value < changeDirChance){
                //speed *= -1;
        }
    }
        void FixedUpdate()
        {
            if (UnityEngine.Random.value < changeDirChance)
            {
                speed *= -1;
            }
        }
    
}
