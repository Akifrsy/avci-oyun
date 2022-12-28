using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBehaviour : MonoBehaviour
{

    public int speed;
    public int turnDelay;
    
    bool faceRight = false;
  

    private void Start()
    {
        StartCoroutine(SwitchDirections());
    }


    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    IEnumerator SwitchDirections()
    {
        yield return new WaitForSeconds(turnDelay);
        Switch(); 
    }

    private void Switch()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

        speed *= -1;


        StartCoroutine(SwitchDirections());
    }

    


}


