using _ShipBlaster1c.Scripts.StringValues;
using UnityEngine;

namespace _ShipBlaster1c.Scripts.Inputting
{
    public class KeyboardInput : PlayerInput
    {
        protected override InputData GetInputData()
        {
            var inputData = new InputData()
            {
                Direction = new Vector2(Input.GetAxisRaw(InputName.Horizontal),
                                        Input.GetAxisRaw(InputName.Vertical))
            };

            return inputData;
        }
    }
}