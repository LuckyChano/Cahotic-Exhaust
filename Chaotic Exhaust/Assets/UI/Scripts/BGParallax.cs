using UnityEngine;

public class BGParallax : MonoBehaviour
{
    private Vector2 _startPos;
    [SerializeField] private Camera cam;
    [SerializeField] private int _moveModifier;

    private void Start()
    {
        
        _startPos = transform.position;
    }

    private void Update()
    {
        Vector2 mousePos = cam.ScreenToViewportPoint(Input.mousePosition);

        float posX = Mathf.Lerp(transform.position.x, _startPos.x + (mousePos.x * _moveModifier), 2f * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, _startPos.y + (mousePos.y * _moveModifier), 2f * Time.deltaTime);

        transform.position = new Vector3(posX, posY, 0);
    }
}
