﻿using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using Aptacode.Geometry.Collision;
using Aptacode.Geometry.Primitives;
using Aptacode.Geometry.Primitives.Extensions;
using Excubo.Blazor.Canvas.Contexts;

namespace Aptacode.Geometry.Blazor.Components.ViewModels
{
    public abstract class ComponentViewModel
    {
        protected ComponentViewModel(Primitive primitive)
        {
            Id = Guid.NewGuid();
            _oldPrimitive = _primitive = primitive;
            CollisionDetectionEnabled = true;
            BorderColor = Color.Black;
            FillColor = Color.Black;
            BorderThickness = DefaultBorderThickness;
        }

        #region Canvas

        public abstract Task Draw(IContext2DWithoutGetters ctx);

        #endregion

        #region Properties

        public static readonly string DefaultBorderColor = Color.Black.ToKnownColor().ToString();
        public static readonly string DefaultFillColor = Color.Black.ToKnownColor().ToString();
        public static readonly int DefaultBorderThickness = 1;

        public Guid Id { get; init; }

        public Primitive _oldPrimitive;

        protected Primitive _primitive;

        public Primitive Primitive => _primitive;

        public float Margin { get; set; }

        public bool IsShown { get; set; }

        private Color _borderColor;

        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                BorderColorName = value.ToKnownColor().ToString();
            }
        }

        public string BorderColorName { get; set; }

        private Color _fillColor;

        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                FillColorName = value.ToKnownColor().ToString();
            }
        }

        public string FillColorName { get; set; }

        public int BorderThickness { get; set; }

        #endregion

        #region CollisionDetection

        public bool CollisionDetectionEnabled { get; set; }
        public bool Invalidated { get; set; } = false;

        public bool CollidesWith(ComponentViewModel component, CollisionDetector collisionDetector) =>
            Primitive.CollidesWith(component.Primitive, collisionDetector);

        public bool CollidesWith(Vector2 point, CollisionDetector collisionDetector) =>
            Primitive.CollidesWith(point.ToPoint(), collisionDetector);

        #endregion

        #region Transformation

        public abstract void Translate(Vector2 delta);

        public abstract void Rotate(float theta);

        public abstract void Rotate(Vector2 rotationCenter, float theta);

        public abstract void Scale(Vector2 delta);

        public abstract void Skew(Vector2 delta);

        #endregion
    }
}