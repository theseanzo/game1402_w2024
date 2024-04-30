using System.Collections;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// This may not be the best way to do this, but I thought it would be nice to show an external component that calculates whether it is grounded or not.
    /// Hopefully this helps students break up their code a little more.
    /// </summary>
    public class GroundCheck : MonoBehaviour
    {
        private bool _canCheck = true;
        public bool IsGrounded { get; private set; }
        [SerializeField]
        LayerMask groundLayer;
        /// <summary>
        /// For checking if something is grounded, we cast a ray downwards a small amount and see if it hits. Could also be done with a SphereCast
        /// </summary>
        public void Check()
        {
            if (!_canCheck)
                return;
            RaycastHit hit;
            Vector3 rayCastOrigin = transform.position;
            IsGrounded = Physics.Raycast(rayCastOrigin, Vector3.down, out hit, 0.01f, groundLayer);
        }
        /// <summary>
        /// When we jump, we want to temporarily disable the ground check. 
        /// </summary>
        public void DisableTemporarily()
        {
            _canCheck = false;
            IsGrounded = false;
            StartCoroutine(EnableGroundCheck());
        }
        /// <summary>
        /// Hey look, a Coroutine example (could also be shown to use Invoke, which they know from before)
        /// </summary>
        /// <returns></returns>
        IEnumerator EnableGroundCheck()
        {
            yield return new WaitForSeconds(.01f);
            _canCheck = true;
        }
    }
}