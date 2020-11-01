using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.PlayField
{
    [RequireComponent(typeof(Collider2D))]
    public class ScreenLimitView : View
    {
        public event Action OnBallCollision;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<BallView>() != null)
            {
                OnBallCollision?.Invoke();
            }
        }
    }
}