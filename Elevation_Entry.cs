using UnityEngine;

public class Elevation_Entry : MonoBehaviour

{
    [SerializeField] private Collider2D[] buildingCollidersOff;
    [SerializeField] private Collider2D[] boundaryCollidersOn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            foreach (Collider2D building in buildingCollidersOff)
            {
                building.enabled = false;
            }
            foreach (Collider2D boundary in boundaryCollidersOn)
            {
                boundary.enabled = true;
            }


        collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;


    }
}
