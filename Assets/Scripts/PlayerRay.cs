using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    [SerializeField] private Transform _poiner; //указатель
    [SerializeField] private Selectable _currentSelectable;


    private void LateUpdate()
    {
        //Ray ray = new Ray(transform.position, transform.forward);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(transform.position, transform.forward * 100, Color.yellow);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            _poiner.position = hit.point;

            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();

            if (selectable)
            {
                _currentSelectable = selectable;

                selectable.Select();
            }
        }       
    }
}
