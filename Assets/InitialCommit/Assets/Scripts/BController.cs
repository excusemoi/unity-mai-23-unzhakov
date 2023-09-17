using UnityEngine;

public class BController : MonoBehaviour
{
    private float _velocity = 0.005f;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale += new Vector3(_velocity, _velocity, 0);
            _renderer.enabled = true;
            return;
        }
        _renderer.enabled = false;
    }
}
