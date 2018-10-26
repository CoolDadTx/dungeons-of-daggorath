/*
 * Implementation adapted from SharpDL - https://github.com/babelshift/SharpDL/blob/master/SharpDL.Graphics/Window.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SDL2;

namespace DoD.Graphics
{
    /// <summary>Represents a graphics window.</summary>
    public class SDL_Window : IDisposable
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="SDL_Window"/> class.</summary>
        public SDL_Window ()
        {
        }

        /// <summary>Initializes an instance of the <see cref="SDL_Window"/> class.</summary>
        /// <param name="handle">The existing window handle.</param>
        public SDL_Window ( IntPtr handle )
        {
            _handle = handle;
        }

        ~SDL_Window ()
        {
            Dispose(false);
        }
        #endregion        

        public IntPtr Handle
        {
            get => _handle;
        }

        public string Title { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Close () => Dispose();

        public void Create ( string title, int x, int y, int width, int height, SDL.SDL_WindowFlags flags )
        {
            if (_handle != IntPtr.Zero)
                throw new InvalidOperationException("Window already created.");
            
            _handle = SDL.SDL_CreateWindow(title, x, y, width, height, flags);
            if (_handle == IntPtr.Zero)
                throw new InvalidOperationException("Failed to create window.");

            Title = title;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Dispose ()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose ( bool disposing )
        {
            try
            {
                var handle = Interlocked.Exchange(ref _handle, IntPtr.Zero);
                if (handle != IntPtr.Zero)
                    SDL.SDL_DestroyWindow(handle);
            } catch
            {  /* Ignore */ };
        }

        #region Private Members

        private IntPtr _handle;
        #endregion
    }
}
