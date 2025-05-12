using System.Runtime.CompilerServices;
using System.Windows;

// Make internal members visible to test projects
[assembly: InternalsVisibleTo("EasyType.Tests")]

// Set theme dictionary location for WPF
[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, // where theme specific resource dictionaries are located
    ResourceDictionaryLocation.SourceAssembly // where the generic resource dictionary is located
)]