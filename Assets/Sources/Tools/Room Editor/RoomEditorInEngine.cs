using BlockRooms.Model;
using UnityEngine;

[ExecuteInEditMode]
public class RoomEditor : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Sprite example;
    private float delta = Config.CellDelta;
    private PlayerBallInput input;

    private void OnEnable()
    {
        input = new PlayerBallInput();
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        //Vector2 roundedMousePosition = CalculateMouseRoundedPosition();
        //Instantiate(example, roundedMousePosition, Quaternion.identity);
    }

    //public Vector2 CalculateMouseRoundedPosition()
    //{
    //    //Vector3 mousePosition = mainCamera.ScreenToWorldPoint(input.PlayerBall.MousePosition.ReadValue<Vector2>());
    //    //Debug.Log(Input.mousePosition);
    //    //Vector2 roundedMousePosition = CalculateRoundedPosition(mousePosition);
    //    //return roundedMousePosition;
    //}

    private Vector2 CalculateRoundedPosition(Vector2 position)
    {
        Vector2 remainder = new(position.x % delta, position.y % delta);
        position.x = CalculateRoundedValue(position.x, remainder.x);
        position.y = CalculateRoundedValue(position.y, remainder.y);
        return position;
    }

    private float CalculateRoundedValue(float value, float remainder)
    {
        float roundedValue;
        sbyte coefficient = 1;

        if (value < 0)
        {
            coefficient = -1;
            value = -value;
            remainder = -remainder;
        }

        if (remainder < delta / 2)
            roundedValue = value - remainder;
        else if (remainder > delta / 2)
            roundedValue = value - remainder + delta;
        else
            roundedValue = value;

        return roundedValue * coefficient;
    }
}
