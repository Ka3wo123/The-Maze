using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    public List<GameObject> traps;
    public float distance = 0.5f;
    public float waitTime = 3.0f;
    public float waitTime2 = 10.0f;
    public float moveUp_time = 1.0f;
    public float moveDown_time = 3.0f;
    public GameObject Thorns;

        void Start()
    {
        // Start the animation loop
        StartCoroutine(AnimationLoop());
    }

    IEnumerator AnimationLoop()
    {
        while (true)
        {
            // Move each trap from current position to up
                Vector3 startPos = Thorns.transform.position;
                Vector3 endPos = new Vector3(startPos.x, startPos.y + distance, startPos.z);
                StartCoroutine(MoveObject(Thorns, startPos, endPos, moveUp_time));
            

            // Wait for the specified time
            yield return new WaitForSeconds(waitTime);


                startPos = Thorns.transform.position;
                endPos = new Vector3(startPos.x, startPos.y - distance, startPos.z);
                StartCoroutine(MoveObject(Thorns, startPos, endPos, moveDown_time));
            

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



    // Update is called once per frame
    void Update()
    {
        
    }
}
