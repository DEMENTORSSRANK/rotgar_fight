using Sources.Model.Bodies;
using Sources.Model.Time;
using UnityEngine;

namespace Sources
{
    public class Tester : MonoBehaviour
    {
        private void Start()
        {
            var rangeTime = new TimeRange(1, 5);

            for (int i = 0; i < 100; i++)
            {
                print(rangeTime.Random);
            }
        }
    }
}