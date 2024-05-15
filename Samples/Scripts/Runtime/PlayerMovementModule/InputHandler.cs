using UnityEngine;

namespace Runtime.PlayerMovementModule
{
    public class InputHandler : MonoBehaviour
    {
        //This is for BindFromHierarchy test
        //This object should be on Scene

        public bool inputHandling = true;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                inputHandling = !inputHandling;
            }
        }
    }
}
