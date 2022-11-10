using DnDBook.Core.Database;
using DnDBook.Droid;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndriodDBPathBuilder))]
namespace DnDBook.Droid
{
    public class AndriodDBPathBuilder : IDBPathBuilder
    {
        public string BuiltPath(string fileName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);            

            return path;
        }
    }
}