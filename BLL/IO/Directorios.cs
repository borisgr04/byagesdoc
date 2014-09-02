using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL.IO
{
    public class Directorios
    {
        public string sourcePath { get; set; }
        public string targetPath { get; set; }
        public BandejaEntrada be{get; set;}

        public Directorios(string sourcePath, string targetPath, BandejaEntrada be)
        {
            this.sourcePath = sourcePath;
            this.targetPath = targetPath;
            this.be = be;

        }

        public Directorios(string sourcePath, string targetPath)
        {
            this.sourcePath = sourcePath;
            this.targetPath = targetPath;
        }

        public byte[] GetBytes()
        {
                string sourceFile = System.IO.Path.Combine(sourcePath, be.Archivo);
                MemoryStream ms = new MemoryStream();
                using (FileStream file = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    ms.Write(bytes, 0, (int)file.Length);
                }
                return ms.ToArray();
        }
        public string GetExtension()
        {
            string sourceFile = System.IO.Path.Combine(sourcePath, be.Archivo);
            return Path.GetExtension(sourceFile);
        }

        public string GetFileName()
        {
            return GetFileName(be.Archivo);
        }

        public string GetFileName(string Nombre)
        {
            string sourceFile = System.IO.Path.Combine(sourcePath, be.Archivo);
            return Path.GetFileNameWithoutExtension(sourceFile);
        }
        
        public void MoverArchivos()
        {
                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath, be.Archivo);
                string destFile = System.IO.Path.Combine(targetPath, be.Archivo);
                Directory.Move(sourceFile, destFile);
        }

        public void MoverArchivos(List<BandejaEntrada> lBE)
        {
            foreach (BandejaEntrada be in lBE)
            {
                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath, be.Archivo);
                string destFile = System.IO.Path.Combine(targetPath, be.Archivo);

                Directory.Move(sourceFile, destFile);


            }
        }

        public List<BandejaEntrada> ObtenerBE()
        {
            string[] lista1;
            lista1 = Directory.GetFiles(sourcePath);
            IEnumerator lista2 = lista1.GetEnumerator();
            List<BandejaEntrada> listaBE = new List<BandejaEntrada>();
            while (lista2.MoveNext())
            {
                listaBE.Add(new BandejaEntrada { Completa = lista2.Current.ToString(), Archivo = lista2.Current.ToString().Remove(0, (sourcePath.Length)) });
            }
            return listaBE;
        }
    }
    //
    public  class BandejaEntrada
    {
        public bool Chk { get; set; }
        public string Completa { get; set; }
        public string Archivo { get; set; }
    }
}
