using Kernel.Cryptography;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit;


namespace Convesys.Kernel.Cryptography.Tests.L1
{
    [TestFixture]
    public class PasswordEncryptorTests1
    {
        static MD5 md5 = MD5.Create();

        [NUnit.Framework.Test]
        public void fooInParallel()
        {
            var perm = new List<string>();
            var stopwatch = new Stopwatch();
            //var source = new char[6] {'1', '2', '3', '4', '5', '6' };
            //var source = new char[6] { 'a', 'b', 'c', 'd', 'e', 'f' };
            var source = new char[] { 'a', 'b', 'c', 'd', '1', '2', '3' };
            var salt = new byte[4];
            //var sb = new StringBuilder();
            //var md5 = MD5.Create();
            var exceptionCount = 0;
            ulong total = 0;
            stopwatch.Start();
            try
            {
                Parallel.For(0, source.Length, i =>
                {
                    Parallel.For(0, source.Length, i1 =>
                    {
                        Parallel.For(0, source.Length, i2 =>
                        {
                            Parallel.For(0, source.Length, i3 =>
                            {
                                Parallel.For(0, source.Length, i4 =>
                                {
                                    Parallel.For(0, source.Length, i5 =>
                                    {
                                        Parallel.For(0, source.Length, i6 =>
                                        {
                                            Parallel.For(0, source.Length, i7 =>
                                            {
                                                Parallel.For(0, source.Length, i8 =>
                                                {
                                                    try
                                                    {
                                                        var sb = new StringBuilder();

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
                                                        //sb.AppendFormat("psw - {0} - hash - {1}. Elapsed time: {2}. Generated: {3}", str, base64, stopwatch.Elapsed, Interlocked.Increment(ref total));
                                                        Debug.WriteLine("psw: " + str + " hash: " + base64 + ". Total:" + Interlocked.Increment(ref total) + " time elapsed: " + stopwatch.Elapsed);
                                                        //Debug.WriteLine(sb.ToString());
                                                        //ConsoleOutput.Instance.WriteLine(sb.ToString(), OutputLevel.Information);
                                                    }
                                                    catch(ex Exception)
                                                    {
                                                        ++exceptionCount;
                                                        Debug.WriteLine("{0} - {1}. Exceptions:{2}", e.Message, total, exceptionCount);
                                                    }
                                                });
                                            });
                                        });
                                    });
                                });
                            });
                        });
                    });
                    stopwatch.Stop();
                    Debug.WriteLine(stopwatch.Elapsed);
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine("{0} - {1}. Exceptions:{2}", e.Message, total, exceptionCount);
            }
        }
    }
}