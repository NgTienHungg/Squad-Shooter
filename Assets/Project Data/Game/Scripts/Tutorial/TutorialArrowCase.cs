﻿using UnityEngine;

namespace Watermelon
{
    public class TutorialArrowCase
    {
        private GameObject arrowObject;
        public GameObject ArrowObject => arrowObject;

        public Vector3 Position
        {
            get => arrowObject.transform.position;
            set => arrowObject.transform.position = value;
        }

        private bool isDisabled;
        public bool IsDisabled => isDisabled;

        private TweenCase scaleTweenCase;

        public TutorialArrowCase(GameObject arrowObject)
        {
            this.arrowObject = arrowObject;
        }

        public void Show()
        {
            scaleTweenCase.KillActive();

            arrowObject.transform.localScale = Vector3.zero;
            scaleTweenCase = arrowObject.transform.DOScale(1, 0.3f).SetEasing(Ease.Type.SineOut);
        }

        public void Hide(SimpleCallback onHidded = null)
        {
            scaleTweenCase.KillActive();

            scaleTweenCase = arrowObject.transform.DOScale(0, 0.3f).SetEasing(Ease.Type.SineIn).OnComplete(delegate
            {
                Disable();

                onHidded?.Invoke();
            });
        }

        public void Disable()
        {
            arrowObject.SetActive(false);

            isDisabled = true;
        }
    }
}