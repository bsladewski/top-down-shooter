using UnityEngine;

public class PlayerAimMouse : MonoBehaviour
{
    private void Update()
    {
        // find mouse position relative to player position
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float enter))
        {
            // update player rotation to look at mouse position
            Vector3 hitPoint = ray.GetPoint(enter);
            transform.LookAt(hitPoint, Vector3.up);
        }
    }
}
