using System;
using System.Text;
using System.Linq;
using Kernel.Cryptography.DataProtection;
using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Diagnostics;
using Kernel.Cryptography;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Twilight.Kernel.Cryptography.Tools;
using System.Threading;

namespace Twilight.Kernel.Cryptography.Tests.L0
{
    [TestFixture]
    public class PasswordEncryptorTests1
    {
        [Test]
        public void foo()
        {
            var perm = new List<string>();
            var stopwatch = new Stopwatch();
            //var source = new char[6] {'1', '2', '3', '4', '5', '6' };
            //var source = new char[6] { 'a', 'b', 'c', 'd', 'e', 'f' };
            var source = new char[] { 'a', 'b', 'c', 'd', '1', '2', '3' };
            var salt = new byte[4];
            var sb = new StringBuilder();
            var md5 = MD5.Create();
            var total = 0l;
            stopwatch.Start();
            for (var i = 0; i < source.Length; i++)
            {
                for (var i1 = 0; i1 < source.Length; i1++)
                    for (var i2 = 0; i2 < source.Length; i2++)
                        for (var i3 = 0; i3 < source.Length; i3++)
                            for (var i4 = 0; i4 < source.Length; i4++)
                                for (var i5 = 0; i5 < source.Length; i5++)
                                    for (var i6 = 0; i6 < source.Length; i6++)
                                        for (var i7 = 0; i7 < source.Length; i7++)
                                            for (var i8 = 0; i8 < source.Length; i8++)
                                            {
                                                var d = new char[9] { source[i], source[i1], source[i2], source[i3], source[i4], source[i5], source[i6], source[i7], source[i8] };
                                                sb.Clear();
                                                //var d = new char[4] { source[i], source[i1], source[i2], source[i3] };
                                                var str = new string(d);
                                                //sb.AppendLine(str);
                                                //var p = new string(d);
                                                //perm.Add(sb.ToString());
                                                var hash = HashBase.HashPassword(md5, str, out salt);
                                                //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                                                var base64 = System.Convert.ToBase64String(hash);
                                                sb.AppendFormat("psw - {0} - hash - {1}. Elapsed time: {2}. Generated: {3}", str, base64, stopwatch.Elapsed, ++total);
                                                
                                                Debug.WriteLine(sb.ToString());
                                                //yield return base64;
                                                //ConsoleOutput.Instance.WriteLine(sb.ToString(), OutputLevel.Information);
                                            }
            }
            stopwatch.Stop();
            Debug.WriteLine(stopwatch.Elapsed);
        }

        [Test]
        public void foo1()
        {
            var sb = new StringBuilder();
            var source = new char[] { 'a', 'b', 'c', 'd', '1', '2', '3' };
            foreach(var h in HashPermutations.Generate(source, MD5.Create()))
            {
                sb.AppendFormat("psw - {0} - hash - {1} - salt - {2}. Elapsed time: {3}. Generated: {4}", h.Item1, h.Item2, h.Item3, h.Item4, h.Item5);
                Debug.WriteLine(sb);
                sb.Clear();
            }
        }
        //public void fooInParallel()
        //{
        //    var perm = new List<string>();
        //    var stopwatch = new Stopwatch();
        //    //var source = new char[6] {'1', '2', '3', '4', '5', '6' };
        //    //var source = new char[6] { 'a', 'b', 'c', 'd', 'e', 'f' };
        //    var source = new char[] { 'a', 'b', 'c', 'd', '1', '2', '3' };
        //    var salt = new byte[4];
        //    //var sb = new StringBuilder();
        //    //var md5 = MD5.Create();
        //    var exceptionCount = 0;
        //    ulong total = 0;
        //    stopwatch.Start();
        //    try
        //    {
        //        Parallel.For(0, source.Length, i =>
        //        {
        //            Parallel.For(0, source.Length, i1 =>
        //            {
        //                Parallel.For(0, source.Length, i2 =>
        //                {
        //                    Parallel.For(0, source.Length, i3 =>
        //                    {
        //                        Parallel.For(0, source.Length, i4 =>
        //                        {
        //                            Parallel.For(0, source.Length, i5 =>
        //                            {
        //                                Parallel.For(0, source.Length, i6 =>
        //                                {
        //                                    Parallel.For(0, source.Length, i7 =>
        //                                    {
        //                                        Parallel.For(0, source.Length, i8 =>
        //                                        {
        //                                            try
        //                                            {
        //                                                var sb = new StringBuilder();

        //                                                var d = new char[9] { source[i], source[i1], source[i2], source[i3], source[i4], source[i5], source[i6], source[i7], source[i8] };
        //                                                sb.Clear();
        //                                                //var d = new char[4] { source[i], source[i1], source[i2], source[i3] };
        //                                                var str = new string(d);
        //                                                //sb.AppendLine(str);
        //                                                //var p = new string(d);
        //                                                //perm.Add(sb.ToString());
        //                                                var hash = HashBase.HashPassword(md5, str, out salt);
        //                                                //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        //                                                var base64 = System.Convert.ToBase64String(hash);
        //                                                //sb.AppendFormat("psw - {0} - hash - {1}. Elapsed time: {2}. Generated: {3}", str, base64, stopwatch.Elapsed, Interlocked.Increment(ref total));
        //                                                Debug.WriteLine("psw: " + str + " hash: " + base64 + ". Total:" + Interlocked.Increment(ref total) + " time elapsed: " + stopwatch.Elapsed);
        //                                                //Debug.WriteLine(sb.ToString());
        //                                                //ConsoleOutput.Instance.WriteLine(sb.ToString(), OutputLevel.Information);
        //                                            }
        //                                            catch (ex Exception)
        //                                            {
        //                                                ++exceptionCount;
        //                                                Debug.WriteLine("{0} - {1}. Exceptions:{2}", e.Message, total, exceptionCount);
        //                                            }
        //                                        });
        //                                    });
        //                                });
        //                            });
        //                        });
        //                    });
        //                });
        //            });
        //            stopwatch.Stop();
        //            Debug.WriteLine(stopwatch.Elapsed);
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine("{0} - {1}. Exceptions:{2}", e.Message, total, exceptionCount);
        //    }
        //}

        [Test]
        public void fooRecur(StringBuilder sb, char[] charsToAdd)
        {
            var perm = new List<string>();
            var source = new char[4] { '1', '2', '3', '4' };
            //var sb = new StringBuilder(s);
            for (var i = 0; i < source.Length; i++)
            {
                for (var i1 = 0; i1 < source.Length; i1++)
                    for (var i2 = 0; i2 < source.Length; i2++)
                        for (var i3 = 0; i3 < source.Length; i3++)
                        {
                            var d = new char[4] { source[i], source[i1], source[i2], source[i3] };
                            sb.AppendLine(new string(d));
                            //var p = new string(d);
                            perm.Add(sb.ToString());
                        }
            }
        }

        [Test]
        public void EncryptDecryptByPassword_same_instance_default_AesCryptoServiceProvider()
        {
            //ARRANGE
            var encryptor = new PasswordEncryptor();
            //var decryptor = new PasswordEncryptor();
            var plainTextSource = "Test data to encrypt";
            var result = String.Empty;
            byte[] salt;
            //ACT
            var encrypted = encryptor.Encrypt("Password1", plainTextSource, out salt);
            result = encryptor.Decrypt("Password1", salt, encrypted);
            //ASSERT
            Assert.AreEqual(plainTextSource, result);
        }

        [Test]
        public void EncryptDecryptByPassword_different_instance_default_AesCryptoServiceProvider()
        {
            //ARRANGE
            var encryptor = new PasswordEncryptor();
            var decryptor = new PasswordEncryptor();
            var plainTextSource = "Test data to encrypt";
            var result = String.Empty;
            byte[] salt;
            //ACT
            var c = new UTF8Encoding();
            var readonlySpan = new ReadOnlySpan<byte>(c.GetBytes("þÿ"));
            var cc = c.GetBytes("þÿ");
            var plainText = c.GetString(cc);
            var encrypted = encryptor.Encrypt("Password1", plainTextSource, out salt);
            result = decryptor.Decrypt("Password1", salt, encrypted);
            //ASSERT
            Assert.AreEqual(plainTextSource, result);
        }
    }
}
