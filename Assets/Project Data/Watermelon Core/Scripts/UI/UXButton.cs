﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Watermelon
{
    public class UXButton : BaseButton
    {
        public UnityEvent onClick;

        public override void OnClick(SimpleCallback callback = null)
        {
            base.OnClick(delegate
            {
                if (onClick != null)
                    onClick.Invoke();
            });
        }
    }
}