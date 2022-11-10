using DnDBook.Core.Database;
using DnDBook.iOS;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSDBBuilder))]
namespace DnDBook.iOS
{
    public class IOSDBBuilder : IDBPathBuilder
    {
        public string BuiltPath(string fileName)
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            return Path.Combine(folderPath, "..", "Library", fileName);
        }
    }
}