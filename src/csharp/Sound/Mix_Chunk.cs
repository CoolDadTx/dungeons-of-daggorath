/*
 * Copyright © Michael Taylor (P3Net)
 * All Rights Reserved
 *
 * http://www.michaeltaylorp3.net
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SDL2;

namespace DoD.Sound
{
    public sealed class Mix_Chunk : IDisposable
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Mix_Chunk"/> class.</summary>
        public Mix_Chunk ()
        { }

        /// <summary>Initializes an instance of the <see cref="Mix_Chunk"/> class.</summary>
        /// <param name="handle">The existing handle.</param>
        public Mix_Chunk ( IntPtr handle )
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentException("Handle is invalid.", nameof(handle));

            _handle = handle;
        }

        ~Mix_Chunk ()
        {
            Dispose(false);
        }
        #endregion

        public IntPtr Handle
        {
            get => _handle;
        }

        public void Dispose ()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Private Members

        private void Dispose ( bool disposing )
        {
            try
            {
                var handle = Interlocked.Exchange(ref _handle, IntPtr.Zero);
                if (handle != IntPtr.Zero)
                    SDL_mixer.Mix_FreeChunk(handle);
            } catch
            { /* Ignore */ };
        }

        private IntPtr _handle;
        #endregion
    }
}
