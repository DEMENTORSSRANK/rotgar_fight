using Sources.Model.Time;
using UnityEngine;

namespace Sources
{
    public class Tester : MonoBehaviour
    {
        private void Start()
        {
            var timer = new Timer(20);
            
            timer.Ended += delegate
            {
                print("Timer end");
            };
            
            timer.RemainSecondsChanged += delegate(int seconds)
            {
                print($"Timing: {seconds}");
            };
            
            timer.Start();
        }
    }
}