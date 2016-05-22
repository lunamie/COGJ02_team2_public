using UnityEngine;
using System.Collections;
using Leap;

public class Fighter : MonoBehaviour
{

    public Controller controller = new Controller();
    public GameObject FighterObject;
    public Quaternion basisRotation;
    private Vector3 direct = new Vector3(0.0f, 0.0f, 0.0f);
    public float speed = 1.0f;
    public float angle;
    public float test = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        Frame frame = controller.Frame();
        HandList hands = frame.Hands;
        Hand hand = hands.Rightmost;

        direct = transform.forward;

        //右手がLeapMotion上に存在する
        if (hand.IsValid && hand.IsRight)
        {
            //手が一つのみの場合値を変化
            if (hands.Count < 2)
            {
                transform.up = /*transform.localToWorldMatrix * */ToVector3(hand.PalmNormal * -1.0f);
                //Vector3 angle = Vector3.Cross( FighterObject.transform.up, ToVector3(hand.PalmNormal * -1.0f) );
                //float p = Vector3.Angle(FighterObject.transform.up, ToVector3(hand.PalmNormal * -1.0f));
                //FighterObject.transform.transform.rotation = Quaternion.AngleAxis( p, angle );
				transform.Rotate(0, transform.localRotation.z,0) ;
                direct = transform.localToWorldMatrix * ToVector3(hand.Direction);
            }
        }

        transform.position += speed * direct * Time.deltaTime * 1.0f;

    }

    void SetVisible(GameObject obj, bool visible)
    {
        foreach (Renderer component in obj.GetComponents<Renderer>())
        {
            component.enabled = visible;
        }
    }

    Vector3 ToVector3(Vector v)
    {
        return new UnityEngine.Vector3(v.x, v.y, -1.0f * v.z);
    }
}