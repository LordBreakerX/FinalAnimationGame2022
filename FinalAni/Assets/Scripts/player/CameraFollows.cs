using UnityEngine;
using System.Collections;

public class CameraFollows : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null)
        {
			Vector3 targetCamPos = target.position + offset;
			transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
	}
}
