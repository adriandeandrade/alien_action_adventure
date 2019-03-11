using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithinARadius : MonoBehaviour
{
    /*The goal of this script is to always stay within a radius of a defined target.
    * Whenever we are farther then the allowed radius, this script will bring us at the maximum radius distance.*/

    public Transform target;    //This will be the actual target to look at it.

    public float radius;        //This is the maximum radius distance allowed.
    public bool useLateUpdate;  //This says if we are updated in LateUpdate or not.

    Enemy enemy;

    //    [Space(10)]                 //This is just a spacer to make it more appealing in the Inspector.
    //    public bool useMinimumY;    //This says if we must respect a minimum value for Y position.
    //    public float minimumY;      //This is the actual minimum value for Y position to respect if useMinimumY is true.

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = enemy.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //If the designer has checked useLateUpdate, then we shoud not use Update...
        //Check if useLateUpdate is true
        if (useLateUpdate)
        {
            //If it's true, then we must exit the function.
            return;
        }
        //If not, then we proceed calling StayWithinARadiusUpdate, where the actual script behavior is scripted.
        StayWithinARadiusUpdate();
    }

    // Update is called once per frame after every scene's object's Update.
    void LateUpdate()
    {
        //If the designer doesn't have checked useLateUpdate, then we shoud not use LateUpdate...
        //Check if useLateUpdate is false
        if (!useLateUpdate)
        {
            //If it's false, then we must exit the function.
            return;
        }
        //If not, then we proceed calling StayWithinARadiusUpdate, where the actual script behavior is scripted.
        StayWithinARadiusUpdate();
    }

    void StayWithinARadiusUpdate()
    {
        //This function is the core of that script. It's here that Stay Within A Radius behavior is scripted.
        //Since we can't reffer to a null target, we must validate that target is not null
        if (!target)
        {
            //If it's null, then we safely exit the function.
            return;
        }        

        //First we need to know the distance and orientation to go from the target to our gameObject.
        Vector3 fromTargetDeltaPos = transform.position - target.position;

        //Now that we have the delta position, we can validate if its length (magnitude) is greater then the maximum allowed radius.
        if (fromTargetDeltaPos.magnitude > radius)
        {
            //It's greater than the allowed radius limit, so we need to reposition the object within limit.
            //Since fromTargetDeltaPos hold both the direction AND the length from target's position and our gameObject's position, we need to extract ONLY the orientation.
            //We'll acheive it by using "normalized" which will return a vector of the same orientation but with a fixed lenght (magnitude) of 1.
            Vector3 fromTargetDeltaPosNormalized = fromTargetDeltaPos.normalized;

            //Now we have fromTargetDeltaPosNormalized representing the direction from target's position and our gameObject's position.
            //We want to place our gameObject at the same orientation ralative to the target's position but at the limit of the allowed radius.
            //Since fromTargetDeltaPosNormalized has a length (magnitude) of 1, we can simply multiply it by the desired length we want.
            transform.position = target.position + fromTargetDeltaPosNormalized * radius;

            if (gameObject.GetComponent<Rigidbody>())
            {                
                gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity - Vector3.Project(gameObject.GetComponent<Rigidbody>().velocity, fromTargetDeltaPosNormalized);
            }
        }

/*        //Then whether we have adjusted the pos or not, we check if we need to rescpect a minimum value for Y position.
        //We also validate that the actual position is less that the minimum value. 
        if (useMinimumY && transform.position.y < minimumY + target.position.y)
        {
            //Being in that scope means that we must set the Y position to minimumY value
            //We can't simply change Y position like that :----> transform.position.Y = minimumY;
            //So we need to create a new Vector3 with the wanted values, and then store it as being our transform.position.
            transform.position = new Vector3(transform.position.x, minimumY + target.position.y, transform.position.z);
        }
*/
    }
}
