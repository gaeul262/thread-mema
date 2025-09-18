using System;
using System.Threading;
using System.Windows.Forms;

namespace BasicThread
{
    internal class MyThreadClass
    {
        public static void Thread1(ListBox listBox)
        {
            for (int loopCount = 0; loopCount <= 5; loopCount++)
            {
                Thread thread = Thread.CurrentThread;
                string message;

                if (!string.IsNullOrEmpty(thread.Name))
                {
                    message = "Name of Thread: Thread " + thread.Name + " Process = " + loopCount;
                }
                else
                {
                    message = "Thread ID: " + thread.ManagedThreadId + " = " + loopCount;
                }

                if (listBox.InvokeRequired)
                {
                    listBox.Invoke(new MethodInvoker(delegate
                    {
                        listBox.Items.Add(message);
                    }));
                }
                else
                {
                    listBox.Items.Add(message);
                }

                Thread.Sleep(1500);
            }
        }
    }
}
