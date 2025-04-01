using UnityEngine;

public class Grave : MonoBehaviour
{
    public void PlaySFX() {
        SoundManager.PlaySfx(SoundManager.Instance.graveHit);
    }
}
