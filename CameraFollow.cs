using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.transform.position.y > 14) {
            yMin = 20.35f;
        }
        else if (player.transform.position.y > 10) {
            yMin = 14.35f;
        }
        else if (player.transform.position.y > 4.5) {
            yMin = 8.35f;
        }
        else if (player.transform.position.y > 0.5) {
            yMin = 4.35f;
        }
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
