using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour {

    public GameObject player;
    public GameObject reference;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        Vector3 copiaRotacion = new Vector3(0, transform.eulerAngles.y, 0);

        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * 2, Vector3.up) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);

        //Refrerencia para los controles
        reference.transform.eulerAngles = copiaRotacion;

	}
}
