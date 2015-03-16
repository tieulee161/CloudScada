using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Data Acquisition")]
[assembly: AssemblyDescription("Comunicate with 2 device types :\r\n - VDK (using user-defined driver)\r\n - OPC Server (using OPC Client)")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Sapulico")]
[assembly: AssemblyProduct("HD Data Acquisition")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("31a8c096-0e07-4d23-ab8c-1ba4d2e45770")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
//[assembly: AssemblyVersion("2.0.0.3")] // updated : 29/10/2014
//[assembly: AssemblyVersion("2.0.0.5")] // updated : 26/11/2014
//[assembly: AssemblyVersion("2.0.0.6")] // updated : 7/1/2015
//[assembly: AssemblyVersion("2.0.0.7")] // updated : 14/1/2015
//[assembly: AssemblyVersion("2.0.0.8")] // updated : 19/1/2015 : add logger class
//[assembly: AssemblyVersion("2.0.0.9")] // updated : 21/1/2015 : update VDKDriver 3.0.7 
//[assembly: AssemblyVersion("2.0.1.0")] // updated : 30/1/2015 : update OPC Driver 3.0.0 
//[assembly: AssemblyVersion("2.0.1.1")] // updated : 3/2/2015 : update OPC Driver 3.0.1, VDK Driver 3.0.8 
[assembly: AssemblyVersion("2.0.1.2")] // updated : 3/3/2015 : for showing to governor // the error status of VDK junctions are not showed
[assembly: AssemblyFileVersion("1.0.0.0")]
