using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace stocktake_V4.Class
{
    class SimpleAsyncResult : IAsyncResult
    {
        object _state;
        public bool IsCompleted { get; set; }
        public WaitHandle AsyncWaitHandle { get; internal set; }
        public object AsyncState
        {
            get
            {
                if (Exception != null)
                {
                    throw Exception;
                }
                return _state;
            }
            internal set
            {
                _state = value;
            }
        }
        public bool CompletedSynchronously { get { return IsCompleted; } }
        internal Exception Exception { get; set; }
    }
}
