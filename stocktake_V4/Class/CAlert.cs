using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace stocktake_V4.Class
{
    class CAlert : ISynchronizeInvoke
    {
        private MediaPlayer m_mediaPlayer = new MediaPlayer();
        private readonly object _sync;

        public CAlert()
        {
             m_mediaPlayer = new MediaPlayer();
            _sync = new object();
        }
        public IAsyncResult BeginInvoke(Delegate method, object[] args)
        {
            var result = new SimpleAsyncResult();
            ThreadPool.QueueUserWorkItem(delegate {
                result.AsyncWaitHandle = new ManualResetEvent(false);
                try
                {
                    result.AsyncState = Invoke(method, args);
                }
                catch (Exception exception)
                {
                    result.Exception = exception;
                }
                result.IsCompleted = true;
            });
            return result;
        }
        public object EndInvoke(IAsyncResult result)
        {
            if (!result.IsCompleted)
            {
                result.AsyncWaitHandle.WaitOne();
            }
            return result.AsyncState;
        }

        public object Invoke(Delegate method, object[] args)
        {
            lock (_sync)
            {
                return method.DynamicInvoke(args);
            }
        }
        public object Invoke(Delegate method)
        {
            lock (_sync)
            {
                return method.DynamicInvoke();
            }
        }
        public bool InvokeRequired
        {
            get { return true; }
        }

        public void playWarning()
        {
            m_mediaPlayer.Open(new Uri(Directory.GetCurrentDirectory() + "\\Sounds\\warning.wav"));
            m_mediaPlayer.Play();
        }
        public void playSuccess()
        {
            m_mediaPlayer.Open(new Uri(Directory.GetCurrentDirectory() + "\\Sounds\\success.wav"));
            m_mediaPlayer.Play();

        }

    }
}
