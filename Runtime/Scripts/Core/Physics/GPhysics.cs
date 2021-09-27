﻿// Copyright (c) Matteo Beltrame
//
// com.tratteo.gibframe -> GibFrame : GPhysics.cs
//
// All Rights Reserved

using System;
using UnityEngine;

namespace GibFrame
{
    public static class GPhysics
    {
        public static int OverlapSphereNonAllocExecute(Vector3 position, float radius, Collider[] buffer, Action<Collider> Operation)
        {
            int res = Physics.OverlapSphereNonAlloc(position, radius, buffer);
            for (int i = 0; i < res; i++)
            {
                Operation(buffer[i]);
            }
            return res;
        }

        public static int OverlapSphereNonAllocExecute(Vector3 position, float radius, Collider[] buffer, int layermask, Action<Collider> Operation)
        {
            int res = Physics.OverlapSphereNonAlloc(position, radius, buffer, layermask);
            for (int i = 0; i < res; i++)
            {
                Operation(buffer[i]);
            }
            return res;
        }

        public static int OverlapSphereNonAllocExecute(Vector3 position, float radius, Collider[] buffer, int layermask, QueryTriggerInteraction queryTriggerInteraction, Action<Collider> Operation)
        {
            int res = Physics.OverlapSphereNonAlloc(position, radius, buffer, layermask, queryTriggerInteraction);
            for (int i = 0; i < res; i++)
            {
                Operation(buffer[i]);
            }
            return res;
        }

        public static TOutput[] ConverterOverlapSphere<TOutput>(Vector3 position, float radius, Converter<Collider, TOutput> converter)
        {
            Collider[] colliders = Physics.OverlapSphere(position, radius);
            return colliders.ConvertAll(converter);
        }

        public static TOutput[] ConverterOverlapSphere<TOutput>(Vector3 position, float radius, int layerMask, Converter<Collider, TOutput> converter)
        {
            Collider[] colliders = Physics.OverlapSphere(position, radius, layerMask);
            return colliders.ConvertAll(converter);
        }

        public static TOutput[] ConverterOverlapSphere<TOutput>(Vector3 position, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction, Converter<Collider, TOutput> converter)
        {
            Collider[] colliders = Physics.OverlapSphere(position, radius, layerMask, queryTriggerInteraction);
            return colliders.ConvertAll(converter);
        }

        public static Vector3 CalculateThrowVelocity(Vector3 origin, Vector3 target, float angle, float gravityMagnitude)
        {
            angle *= Mathf.Deg2Rad;
            float tan = Mathf.Tan(angle);
            float Dx = Vector3.Distance(origin, new Vector3(target.x, origin.y, target.z));
            float Dy = GMath.Abs(target.y - origin.y);
            float vi = (Dx / Mathf.Cos(angle)) * (Mathf.Sqrt(gravityMagnitude) / Mathf.Sqrt(2F * (Dx * tan + Dy)));
            Vector3 planeDir = (new Vector3(target.x, origin.y, target.z) - origin);
            return new Vector3(planeDir.x, planeDir.magnitude * tan, planeDir.z).normalized * vi * (1F + Time.fixedDeltaTime);
        }

        public static Vector3 CalculateThrowVelocity(Vector3 origin, Vector3 target, float angle)
        {
            return CalculateThrowVelocity(origin, target, angle, Physics.gravity.magnitude);
        }
    }
}