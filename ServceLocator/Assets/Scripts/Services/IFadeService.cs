using UnityEngine.UI;
public interface IFadeService
{
    void FadeIn(Image target, float duration);
    void FadeOut(Image target, float duration);
}
