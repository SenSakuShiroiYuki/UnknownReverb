using System.Collections;
using UnityEngine;

public class FindObjOutCam : MonoBehaviour
{
    public GameObject Find_UI;
    public Transform arrows;
    public Transform target;
    Vector3 prePos = Vector3.zero;
    public float checkTime = 0.2f;

    //被指向的3D对象传入这里，在全局的任何地方，调用一次这个方法即可
    public void SetGuid(Transform _target)
    {
        target = _target;
    }
    void Start()
    {
        arrows.gameObject.SetActive(false);
        StartCoroutine(TrakerGuider());
    }

    private IEnumerator TrakerGuider()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkTime);
            SetGuid();
        }
    }

    private void SetGuid()
    {
        if (target)
        {
            var pos = Camera.main.WorldToScreenPoint(target.transform.position);
            var distance = Vector3.Distance(prePos, pos);
            if (distance < 1) { return; };
            prePos = pos;
            if (0 < pos.x && pos.x < Screen.width && pos.y > 0 && pos.y < Screen.height && pos.z > 0)
            {
                arrows.gameObject.SetActive(false);
                Find_UI.SetActive(true);
                return;
            }
            else
            {
                arrows.gameObject.SetActive(true);
                Find_UI.SetActive(false);
            }
            if (pos.z < 0)
                pos = pos * -1;
            var startpos = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
            var dir = pos - startpos;

            //通过反余弦函数获取 向量 a、b 夹角（默认为 弧度）
            float radians = Mathf.Atan2(dir.y, dir.x);

            //将弧度转换为 角度
            float angle = radians * Mathf.Rad2Deg;
            arrows.localEulerAngles = new Vector3(0, 0, angle);
            // arrows.transform.LookAt(new Vector3(pos.x, pos.y, 0));
            float sereenangle = (float)Screen.height / (float)Screen.width;
            var va = System.Math.Abs(dir.y / dir.x);
            if (va <= sereenangle)
            {
                var length = arrows.GetComponent<RectTransform>().sizeDelta.x;
                if (pos.x < 0)
                    arrows.transform.position = Vector3.Lerp(arrows.transform.position, GetNode(pos, startpos, length * 0.5f), 1 * Time.deltaTime);
                else
                    arrows.transform.position = Vector3.Lerp(arrows.transform.position, GetNode(pos, startpos, Screen.width - length * 0.5f),1 * Time.deltaTime);
            }
            else
            {
                var length = arrows.GetComponent<RectTransform>().sizeDelta.x;

                if (pos.y < 0)
                    arrows.transform.position = Vector3.Lerp(arrows.transform.position, GetNode2(pos, startpos, length * 0.5f), 1 * Time.deltaTime);
                else
                    arrows.transform.position = Vector3.Lerp(arrows.transform.position, GetNode2(pos, startpos, Screen.height - length * 0.5f), 1 * Time.deltaTime);
            }
        }
    }

    private Vector3 GetNode2(Vector3 pos, Vector3 startpos, float v)
    {
        pos = new Vector3(pos.x, pos.y, 0);
        Vector3 ab = pos - startpos;
        Vector3 am = ab * (Mathf.Abs(startpos.y - v) / Mathf.Abs(pos.y - startpos.y));
        Vector3 om = startpos + am;
        return om;
    }

    private Vector3 GetNode(Vector3 pos, Vector3 startpos, float v)
    {
        //float high = ((startpos.x - length) * (pos.y - startpos.y) / (startpos.x - pos.x)) + startpos.y;
        //return new Vector3(length, high, 0);
        pos = new Vector3(pos.x, pos.y, 0);
        Vector3 ab = pos - startpos;
        Vector3 am = ab * (Mathf.Abs(startpos.x - v) / Mathf.Abs(pos.x - startpos.x));
        Vector3 om = startpos + am;
        return om;
    }
}