using System;
using System.Security.Cryptography;
using NetCoreKit.Utils.Extensions;

namespace NetCoreKit.Utils.Helpers
{
  public class CryptoRandomHelper
  {
    private static RandomNumberGenerator _rng = RandomNumberGenerator.Create();

    public static byte[] CreateRandomBytes(int length)
    {
      byte[] bytes = new byte[length];
      _rng.GetBytes(bytes);

      return bytes;
    }

    public static string CreateRandomKey(int length)
    {
      byte[] bytes = new byte[length];
      _rng.GetBytes(bytes);

      return Convert.ToBase64String(CreateRandomBytes(length));
    }

    public static string CreateUniqueKey(int length = 8) => CreateRandomBytes(length).ToHexString();

    public static string CreateSeriesNumber(string prefix = "MSK") => $"{prefix}{DateTime.Now.ToString("yyyyMMddHHmmss")}{CreateUniqueKey()}";
  }
}
