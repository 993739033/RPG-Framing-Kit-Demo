namespace UnityEngine.EventSystems
{
    public class PointerEventTest : MonoBehaviour, IPointerClickHandler,IDragHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            int i = eventData.clickCount;
            float time = eventData.clickTime;
            Vector2 delta = eventData.delta;
            //时间从第一点击开始不断累计
            Debug.Log($"i+time+delta:{i}+{time}+{delta}");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log($"delta:{eventData.delta}");
        }
    }
}