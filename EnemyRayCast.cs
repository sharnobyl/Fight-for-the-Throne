using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayCast : MonoBehaviour
{
    public float raycastMaxDistance = 0.4f;
    public float rayOffset = 0.9f;

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hitright = Physics2D.Raycast(new Vector2 (transform.position.x + rayOffset, transform.position.y), new Vector2(1, 0), raycastMaxDistance);
        RaycastHit2D hitleft = Physics2D.Raycast(new Vector2(transform.position.x - rayOffset, transform.position.y), new Vector2(-1, 0), raycastMaxDistance);

        if (hitright.collider && hitright.collider.tag == "Player") {
            Debug.Log("Hit the collidable object right" + hitright.collider.name);
            print(hitright.collider.name);
            Debug.DrawRay(transform.position, hitright.point, Color.red, 3f);
        } else if(hitleft.collider && hitleft.collider.tag == "Player") {
            Debug.Log("Hit the collidable object left " + hitleft.collider.name);

            Debug.DrawRay(transform.position, hitleft.point, Color.red, 3f);
        }
    }
    
}