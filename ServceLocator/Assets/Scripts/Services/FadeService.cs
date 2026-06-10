using UnityEngine.UI;
using DG.Tweening;
public class FadeService : IFadeService
{
    public void FadeIn(Image target, float duration)
    {
        target.gameObject.SetActive(true);
        target.DOFade(1f, duration);
    }
    public void FadeOut(Image target, float duration)
    {
        target.DOFade(0f, duration).OnComplete(() => target.gameObject.SetActive(false));
    }
}