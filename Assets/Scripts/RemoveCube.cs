using UnityEngine;

public class RemoveCube : MonoBehaviour
{

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Obstacle") || other.CompareTag("Multiplier"))
    {
      if (other.CompareTag("Multiplier"))
      {
        other.GetComponent<BoxCollider>().isTrigger = false;
      }
      other.tag = "Untagged";
      transform.parent = other.transform.parent;
    }

    if (other.CompareTag("Lava"))
    {
      Destroy(transform.gameObject);
    }

  }


}
