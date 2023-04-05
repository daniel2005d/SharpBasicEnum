using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace SharpSecurityEnum
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //System.Security.Principal.NTAccount
        }
        //public enum WinStatusCodes : uint
        //{
        //    STATUS_SUCCESS = 0
        //}
        //[StructLayout(LayoutKind.Sequential)]
        //public struct LSA_STRING
        //{
        //    public UInt16 Length;
        //    public UInt16 MaximumLength;
        //    public /*PCHAR*/ IntPtr Buffer;
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //public struct TOKEN_SOURCE
        //{
        //    public TOKEN_SOURCE(string name)
        //    {
        //        SourceName = new byte[8];
        //        System.Text.Encoding.GetEncoding(1252).GetBytes(name, 0, name.Length, SourceName, 0);
        //        if (!AllocateLocallyUniqueId(out SourceIdentifier))
        //            throw new System.ComponentModel.Win32Exception();
        //    }

        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] public byte[] SourceName;
        //    public UInt64 SourceIdentifier;
        //}

        //// SECURITY_LOGON_TYPE
        //public enum SecurityLogonType
        //{
        //    Interactive = 2,    // Interactively logged on (locally or remotely)
        //    Network,        // Accessing system via network
        //    Batch,          // Started via a batch queue
        //    Service,        // Service started by service controller
        //    Proxy,          // Proxy logon
        //    Unlock,         // Unlock workstation
        //    NetworkCleartext,   // Network logon with cleartext credentials
        //    NewCredentials,     // Clone caller, new default credentials
        //    RemoteInteractive,  // Remote, yet interactive. Terminal server
        //    CachedInteractive,  // Try cached credentials without hitting the net.
        //    CachedRemoteInteractive, // Same as RemoteInteractive, this is used internally for auditing purpose
        //    CachedUnlock    // Cached Unlock workstation
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //public struct QUOTA_LIMITS
        //{
        //    UInt32 PagedPoolLimit;
        //    UInt32 NonPagedPoolLimit;
        //    UInt32 MinimumWorkingSetSize;
        //    UInt32 MaximumWorkingSetSize;
        //    UInt32 PagefileLimit;
        //    Int64 TimeLimit;
        //}

        //[DllImport("secur32.dll", SetLastError = false)]
        //public static extern WinStatusCodes LsaLogonUser(
        //            [In] IntPtr LsaHandle,
        //            [In] ref LSA_STRING OriginName,
        //            [In] SecurityLogonType LogonType,
        //            [In] UInt32 AuthenticationPackage,
        //            [In] IntPtr AuthenticationInformation,
        //            [In] UInt32 AuthenticationInformationLength,
        //            [In] /*PTOKEN_GROUPS*/ IntPtr LocalGroups,
        //            [In] ref TOKEN_SOURCE SourceContext,
        //            [Out] /*PVOID*/ out IntPtr ProfileBuffer,
        //            [Out] out UInt32 ProfileBufferLength,
        //            [Out] out Int64 LogonId,
        //            [Out] out IntPtr Token,
        //            [Out] out QUOTA_LIMITS Quotas,
        //            [Out] out WinStatusCodes SubStatus
        //            );

        //static void Main(string[] args)
        //{
        //    // var currentIdentt = System.Security.Principal.WindowsIdentity.GetCurrent();
        //    var originName = new LsaStringWrapper("CCSecurityUtilities");
        //    TOKEN_SOURCE sourceContext = new TOKEN_SOURCE("CCSecUt");
        //    System.IntPtr profileBuffer = IntPtr.Zero;
        //    UInt32 profileBufferLength = 0;
        //    Int64 logonId;
        //    WinStatusCodes subStatus;
        //    QUOTA_LIMITS quotas;


        //    //LsaLogonUser(lsaHandle, ref )
        //}

        //public class LsaStringWrapper : IDisposable
        //{
        //    public LSA_STRING _string;

        //    public LsaStringWrapper(string value)
        //    {
        //        _string = new LSA_STRING();
        //        _string.Length = (ushort)value.Length;
        //        _string.MaximumLength = (ushort)value.Length;
        //        _string.Buffer = Marshal.StringToHGlobalAnsi(value);
        //    }

        //    ~LsaStringWrapper()
        //    {
        //        Dispose(false);
        //    }

        //    private void Dispose(bool disposing)
        //    {
        //        if (_string.Buffer != IntPtr.Zero)
        //        {
        //            Marshal.FreeHGlobal(_string.Buffer);
        //            _string.Buffer = IntPtr.Zero;
        //        }
        //        if (disposing)
        //            GC.SuppressFinalize(this);
        //    }

        //    #region IDisposable Members

        //    public void Dispose()
        //    {
        //        Dispose(true);
        //    }

        //    #endregion
        //}

    }
}
