using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;


namespace SharpRunAsUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImpersonationUtil.DoImpersonated(args[0], args[1], args[2], () =>
            {
                PowerShell ps = PowerShell.Create();
                ps.AddCommand("Get-ChildItem");
                var results = ps.Invoke();
            });
           
        }
    }
}
