using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockscript : MonoBehaviour
{


    public GameObject block;

    public Transform startPoint;
    public Transform endPoint;

    public float speed = 0.5f;
    public float distance = 3.0f;
    public float startTime;

    public void platform()
    {
        startTime = Time.time;
        StartCoroutine(Blockmove());
        
    }

    private IEnumerator Blockmove()
    {
        yield return new WaitForSeconds(speed); 
        while(block != endPoint.transform) 
        { 
            float distMoved = Mathf.PingPong(Time.time - startTime, distance / speed);
            block.transform.position = Vector3.Lerp(startPoint.position, endPoint.position, distMoved / distance);
            yield return null;
        }
        
    }

}
