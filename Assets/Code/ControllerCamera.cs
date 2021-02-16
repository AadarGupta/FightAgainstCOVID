
using UnityEngine;

public class ControllerCamera : MonoBehaviour {


    public float speedCamera = 30f;
    public float minY;
    public float maxY;

	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {

            transform.Translate(-Vector3.forward * speedCamera * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {

            transform.Translate(Vector3.forward * speedCamera * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {

            transform.Translate(-Vector3.right * speedCamera * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Translate(Vector3.right * speedCamera * Time.deltaTime, Space.World);
        }


        if (Input.GetKey("=") && transform.position.y > maxY)
        {
            transform.Translate(-Vector3.up * speedCamera * Time.deltaTime, Space.World);
        }


        if (Input.GetKey("-") && transform.position.y < minY)
        {
            transform.Translate(Vector3.up * speedCamera * Time.deltaTime, Space.World);
        }

    }
}
