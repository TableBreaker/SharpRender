﻿using System;

namespace FakeEngine.Mathematics
{
    struct Vector3
    {
        public Vector3(float x_, float y_, float z_)
        {
            x = x_; y = y_; z = z_;
        }

        public Vector3(float[] vec)
        {
            if (vec.Length != dimension)
                throw new ArgumentException("Vector3 must have 3 elements");

            x = vec[0];
            y = vec[1];
            z = vec[2];
        }

        public float Dot(Vector3 v)
        {
            return Dot(this, v);
        }

        public static float Dot(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public Vector3 Cross(Vector3 v)
        {
            return Cross(this, v);
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.x, -v.y, -v.z);
        }

        public static Vector3 operator *(Vector3 v, float c)
        {
            return new Vector3(v.x * c, v.y * c, v.z * c);
        }

        public static Vector3 operator *(float c, Vector3 v)
        {
            return v * c;
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static Vector3 operator /(Vector3 v, float c)
        {
            return new Vector3(v.x / c, v.y / c, v.z / c);
        }

        public static implicit operator Vector3(Vector4 v)
        {
            return new Vector3(v.x, v.y, v.z);
        }

        public static bool operator ==(Vector3 a, Vector3 b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }

        public static bool operator !=(Vector3 a, Vector3 b)
        {
            return !(a == b);
        }

        public bool EqualEpsilon(Vector3 vec, float eps)
        {
            return Utils.CompareFloat(x, vec.x, eps) && Utils.CompareFloat(y, vec.y, eps) && Utils.CompareFloat(z, vec.z, eps);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vector3))
                return false;

            return this == (Vector3)obj;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z);
        }

        public float Magnitude
        {
            get
            {
                return Utils.Magnitude(x, y, z);
            }
        }

        public Vector3 normalized
        {
            get
            {
                var mag = Magnitude;
                return this / (mag == 0f ? 1f : mag);
            }
        }

        public static readonly Vector3 One = new Vector3(1f, 1f, 1f);
        public static readonly Vector3 Zero = new Vector3(0f, 0f, 0f);
        public static readonly Vector3 Up = new Vector3(0f, 1f, 0f);
        public static readonly Vector3 Right = new Vector3(1f, 0f, 0f);
        public static readonly Vector3 Forward = new Vector3(0f, 0f, 1f);

        public float x, y, z;
        public const int dimension = 3;
    }
}
