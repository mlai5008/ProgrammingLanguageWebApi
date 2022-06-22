using System;
using System.Windows;

namespace ProgrammingLanguage.Client.Infrastructure.Helpers
{
    public static class AppDispatcherHelper
    {
        public static void Invoke(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }

        public static void InvokeException(Action<Exception> action, Exception e)
        {
            Application.Current.Dispatcher.Invoke(action, e);
        }
    }
}