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
    /// <summary>Represents a graphics renderer.</summary>
    public class SDL_Renderer : IDisposable
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="SDL_Renderer"/> class.</summary>
        public SDL_Renderer ()
        {
        }

        /// <summary>Initializes an instance of the <see cref="SDL_Renderer"/> class.</summary>
        /// <param name="handle">The existing window handle.</param>
        public SDL_Renderer ( IntPtr handle )
        {
            _handle = handle;
        }

        ~SDL_Renderer ()
        {
            Dispose(false);
        }
        #endregion        
    
        public IntPtr Handle
        {
            get => _handle;
        }

        public int Index { get; private set; }

        public SDL_Window Window { get; private set;  }

        public void Close () => Dispose();

        public void Create ( SDL_Window window, int index, SDL.SDL_RendererFlags flags )
        {
            if (_handle != IntPtr.Zero)
                throw new InvalidOperationException("Renderer already created.");

            _handle = SDL.SDL_CreateRenderer(window.Handle, index, flags);
            if (_handle == IntPtr.Zero)
                throw new InvalidOperationException("Failed to create renderer.");

            Index = index;
            Window = window;
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
                    SDL.SDL_DestroyRenderer(handle);

                Window = null;
                Index = -1;
            } catch
            {  /* Ignore */ };
        }

        #region Private Members

        private IntPtr _handle;
        #endregion
    }
}
