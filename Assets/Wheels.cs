using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    public WheelCollider[] wCollider;
    public Transform[] rodas;
    private Vector3 pos;
    private Quaternion rot;

    public float torque, friccao, freio, ang;

    void Start()
    {
        for(int x=0;x < wCollider.Length;x++){
            wCollider [x].ConfigureVehicleSubsteps (1,6,7);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Rodas();
    }

    void FixedUpdate()
    {
        wCollider [2].steerAngle = ang * Input.GetAxis("Horizontal");
        wCollider [3].steerAngle = ang * Input.GetAxis("Horizontal");

        for(int x = 0; x<wCollider.Length; x++){
            wCollider[x].motorTorque = Input.GetAxis ("Vertical") * torque;
            wCollider[x].brakeTorque = (Input.GetKey(KeyCode.Space)) ? freio : friccao - Mathf.Abs (Input.GetAxis("Vertical")*friccao);
        }
    }
    void Rodas()
    {
        for(int x = 0; x < wCollider.Length; x++){
            wCollider[x].GetWorldPose (out pos, out rot);
            rodas [x].position = pos;
            rodas [x].rotation = rot;
 
        }
    }
}
