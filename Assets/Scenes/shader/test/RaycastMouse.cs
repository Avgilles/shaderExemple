using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMouse : MonoBehaviour
{
    Camera _camera;
    RaycastHit _hit;
    Ray _ray;
    Vector3 _mousePos, _smoothPoint;
    public float _radius, _softness, _smoothSpeed, _sclaleFactor;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _radius += _sclaleFactor * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _radius += _sclaleFactor * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _radius += _sclaleFactor * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _radius += _sclaleFactor * Time.deltaTime;
        }

        Mathf.Clamp(_radius, 0, 100);
        Mathf.Clamp(_softness, 0, 100);
        _mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        _ray = _camera.ScreenPointToRay(_mousePos);

        if( Physics.Raycast(_ray, out _hit))
        {
            _smoothPoint = Vector3.MoveTowards(_smoothPoint, _hit.point, _smoothSpeed * Time.deltaTime);
            Vector4 pos = new Vector4(_smoothPoint.x, _smoothPoint.y, _smoothPoint.z, 0);


            Shader.SetGlobalVector("GlobalMask_Position", pos);
        }
        Shader.SetGlobalFloat("GlobalMask_Radius", _radius);
        Shader.SetGlobalFloat("GlobalMask_Softness", _softness);

    }
}
