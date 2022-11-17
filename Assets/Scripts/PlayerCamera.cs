using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public GameObject target;

    Player player;
    Volume volume;
    Vignette vignette;

    private void Start()
    {
        player = target.GetComponent<Player>();
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        var targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -10);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10f * Time.unscaledDeltaTime);
        vignette.intensity.Override(1 - player.GetHPRatio());
    }
}
