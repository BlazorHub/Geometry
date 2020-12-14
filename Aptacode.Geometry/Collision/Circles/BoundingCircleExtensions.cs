﻿using System.Numerics;

namespace Aptacode.Geometry.Collision.Circles
{
    public static class BoundingCircleExtensions
    {
        public static BoundingCircle Translate(this BoundingCircle boundingCircle, Vector2 delta) =>
            new BoundingCircle(boundingCircle.Center + delta, boundingCircle.Radius);

        public static bool Contains(this BoundingCircle circle, Vector2 point) =>
            (point - circle.Center).Length() <= circle.Radius;
    }
}