using UnityEngine;

public class Elevation_Exit : MonoBehaviour

{
    [SerializeField] private Collider2D[] buildingColliders;
    [SerializeField] private Collider2D[] boundaryCollidersOff;
    [SerializeField] private Collider2D[] boundaryCollidersOn;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D building in buildingColliders)
            {
                building.enabled = true;
            }
            foreach (Collider2D boundary in boundaryCollidersOff)
            {
                boundary.enabled = false;
            }
            foreach (Collider2D boundary in boundaryCollidersOn)
            {
                boundary.enabled = true;
            }
        }
        collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;


    }
}
