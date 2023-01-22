using Kernel.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Convesys.Kernel.Cryptography.Tools
{
    public class HashPermutations
    {
        public static IEnumerable<Tuple<string, string, string, TimeSpan, Int64>> Generate(char[] source, HashAlgorithm hashAlgorithm)
        {
            var perm = new List<string>();
            var stopwatch = new Stopwatch();
            var salt = new byte[4];
            var total = 0L;
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
                                                var str = new string(d);
                                                var hash = HashBase.HashPassword(hashAlgorithm, str, out salt);
                                                var haseBase64 = System.Convert.ToBase64String(hash);
                                                var saltBase64 = System.Convert.ToBase64String(salt);
                                                yield return Tuple.Create(str, haseBase64, saltBase64, stopwatch.Elapsed, ++total);
                                            }
            }
            stopwatch.Stop();
        }

        public static IEnumerable<string> GenerateAsync(char[] source, HashAlgorithm hashAlgorithm)
        {
            throw new NotImplementedException();
            //var perm = new List<string>();
            //var stopwatch = new Stopwatch();
            //var salt = new byte[4];
            //var sb = new StringBuilder();
            ////var md5 = MD5.Create();
            //var total = 0L;
            //stopwatch.Start();
            //for (var i = 0; i < source.Length; i++)
            //{
            //    for (var i1 = 0; i1 < source.Length; i1++)
            //        for (var i2 = 0; i2 < source.Length; i2++)
            //            for (var i3 = 0; i3 < source.Length; i3++)
            //                for (var i4 = 0; i4 < source.Length; i4++)
            //                    for (var i5 = 0; i5 < source.Length; i5++)
            //                        for (var i6 = 0; i6 < source.Length; i6++)
            //                            for (var i7 = 0; i7 < source.Length; i7++)
            //                                for (var i8 = 0; i8 < source.Length; i8++)
            //                                {
            //                                    var d = new char[9] { source[i], source[i1], source[i2], source[i3], source[i4], source[i5], source[i6], source[i7], source[i8] };
            //                                    sb.Clear();
            //                                    //var d = new char[4] { source[i], source[i1], source[i2], source[i3] };
            //                                    var str = new string(d);
            //                                    //sb.AppendLine(str);
            //                                    //var p = new string(d);
            //                                    //perm.Add(sb.ToString());
            //                                    //var hash = HashBase.HashPassword(md5, str, out salt);
            //                                    var hash = HashBase.HashPassword(hashAlgorithm, str, out salt);
            //                                    //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            //                                    var base64 = System.Convert.ToBase64String(hash);
            //                                    sb.AppendFormat("psw - {0} - hash - {1}. Elapsed time: {2}. Generated: {3}", str, base64, stopwatch.Elapsed, ++total);
            //                                    Console.WriteLine(sb.ToString());
            //                                    yield return base64;
            //                                }
            //}
            //stopwatch.Stop();
        }
    }
}
