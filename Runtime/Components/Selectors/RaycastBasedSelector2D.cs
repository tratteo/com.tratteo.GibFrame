﻿// Copyright (c) Matteo Beltrame
//
// com.tratteo.gibframe -> GibFrame : RaycastBasedSelector.cs
//
// All Rights Reserved

using System.Collections;
using UnityEngine;

namespace GibFrame.Selectors
{
    public class RaycastBasedSelector2D : DiscreteSelector2D
    {
        private Vector3 direction;
        private bool directionOverride = false;
        private Vector3 offset;

        public void OverrideDirection(Vector3 direction)
        {
            this.direction = direction;
            directionOverride = true;
        }

        public void ResetDirection()
        {
            directionOverride = false;
        }

        public void StartPointOffset(Vector3 offset)
        {
            this.offset = offset;
        }

        protected override IEnumerator SelectCoroutine()
        {
            var delay = new WaitForSecondsRealtime(updateInterval);
            yield return delay;
            while (Enabled)
            {
                var dir = directionOverride ? direction : transform.right;

                var hit = Physics2D.Raycast(transform.position + offset, dir, float.MaxValue, mask);
                if (hit.collider)
                {
                    if (IsCollider2DValid(hit.collider))
                    {
                        Select(hit.collider);
                    }
                    else
                    {
                        ResetSelection();
                    }
                }
                else
                {
                    ResetSelection();
                }

                yield return delay;
            }
        }

        private void OnDrawGizmos()
        {
            if (DebugRender)
            {
                var dir = directionOverride ? direction : transform.right;
                Gizmos.DrawRay(transform.position, dir * 2F);
            }
        }
    }
}