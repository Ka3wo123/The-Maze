using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2v1 : MonoBehaviour
{
    public List<GameObject> panels;
    public float distance = 0.5f;
    public float waitTime = 3.0f;
    public float waitTime2 = 10.0f;
    public float moveUp_time = 1.0f;
    public float moveDown_time = 3.0f;
    public float timeSpace = 3.0f;      // Time Interval between Panels




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitializeTimeSpaceBetween());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InitializeTimeSpaceBetween()
    {
        float counter = 0.0f;
        foreach (GameObject panel in panels)
        {   
            StartCoroutine(AnimationLoop(panel));
            counter++;
            yield return new WaitForSeconds(timeSpace);
            
        }
        
    }


    IEnumerator AnimationLoop(GameObject trap)
    {
        while (true)
        {
            // Move each trap from current position to up
                Vector3 startPos = trap.transform.position;
                Vector3 endPos = new Vector3(startPos.x, startPos.y, startPos.z + distance);
                StartCoroutine(MoveObject(trap, startPos, endPos, moveUp_time));


            // Wait for the specified time
            yield return new WaitForSeconds(waitTime);

            // Move each trap back from up to current position

                startPos = trap.transform.position;
                endPos = new Vector3(startPos.x, startPos.y, startPos.z - distance);
                StartCoroutine(MoveObject(trap, startPos, endPos, moveDown_time));

            // Wait for the specified time before the next loop
            yield return new WaitForSeconds(waitTime2);
        }
    }

    IEnumerator MoveObject(GameObject obj, Vector3 startPos, Vector3 endPos, float time)
    {
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            obj.transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object is exactly at the end position
        obj.transform.position = endPos;
    }


}
