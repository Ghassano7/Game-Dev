using UnityEngine;

public class Instantiate : MonoBehaviour
{
  [SerializeField] GameObject objectPrefab;
  [SerializeField] int count = 0;

  private void Start()
  {
    for (int i = 0; i < count; i++)
    {
      Instantiate(objectPrefab, new Vector3(transform.position.x, transform.position.y + i, transform.position.z), Quaternion.identity, transform);
    }
    Destroy(transform.GetChild(0).gameObject);
  }
}
