using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [Range(-1f,1f)]
    public float RotationSpeed = 0.5f;
    private float offset;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * RotationSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector3(0, offset, 0));
    }
}
