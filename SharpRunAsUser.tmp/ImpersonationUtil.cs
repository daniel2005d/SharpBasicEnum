using System;
using System.Runtime.InteropServices;
using System.Security.Principal;


namespace SharpRunAsUser
{
    public static class ImpersonationUtil
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword,
            int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        private const int LOGON32_LOGON_INTERACTIVE = 2;
        private const int LOGON32_PROVIDER_DEFAULT = 0;

        public static void DoImpersonated(string username, string password, string domain, Action action)
        {
            IntPtr userToken = IntPtr.Zero;
            bool result = LogonUser(username, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref userToken);

            if (result)
            {
                WindowsIdentity identity = new WindowsIdentity(userToken);
                WindowsImpersonationContext context = identity.Impersonate();
                t
                try
                {
                    // Realiza la operación que deseas hacer en nombre del usuario impersonado
                    action();
                }
                finally
                {
                    context.Undo();
                    identity.Dispose();
                }
            }
            else
            {
                throw new Exception("No se pudo autenticar al usuario.");
            }
        }
    }
}
