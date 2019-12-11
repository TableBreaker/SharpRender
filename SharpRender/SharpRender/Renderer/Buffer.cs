﻿using System;
using System.Collections.Generic;
using System.Text;
using SharpRender.Math;

namespace SharpRender.Renderer
{
    partial class RenderBuffer
    {
        public static RenderBuffer NewBuffer(int width_, int height_)
        {
            var buff = new RenderBuffer { id = ++_counter, width = width_, height = height_ };
            return buff;
        }

        private static int _counter = 0;
    }

    partial class RenderBuffer
    {
        public int id;
        public int width;
        public int height;
        public Vector4[] _colorBuffer;
        public float[] _depthBuffer;
        public float[] _stencilBuffer;
    }
}
