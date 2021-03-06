﻿using System.Numerics;

namespace Aptacode.Geometry.Collision.Rectangles
{
    public readonly struct BoundingRectangle
    {
        #region Properties

        public readonly Vector2 TopLeft;
        public readonly Vector2 TopRight;
        public readonly Vector2 BottomRight;
        public readonly Vector2 BottomLeft;
        public readonly Vector2 Size;
        public readonly Vector2 Center;

        #endregion

        #region Ctor

        public BoundingRectangle(Vector2 topLeft, Vector2 topRight, Vector2 bottomRight, Vector2 bottomLeft)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomRight = bottomRight;
            BottomLeft = bottomLeft;
            Size = BottomRight - TopLeft;
            Center = TopLeft + Size / 2.0f;
        }

        public static BoundingRectangle FromTwoPoints(Vector2 topLeft, Vector2 bottomRight)
        {
            var topRight = new Vector2(bottomRight.X, topLeft.Y);
            var bottomLeft = new Vector2(topLeft.X, bottomRight.Y);

            return new BoundingRectangle(topLeft, topRight, bottomRight, bottomLeft);
        }

        public static readonly BoundingRectangle Zero = FromTwoPoints(Vector2.Zero, Vector2.Zero);

        #endregion
    }
}