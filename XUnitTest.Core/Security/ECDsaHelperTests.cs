﻿using System;
using System.Security.Cryptography;
using NewLife;
using NewLife.Security;
using Xunit;

namespace XUnitTest.Security
{
    public class ECDsaHelperTests
    {
        String prvKey = @"-----BEGIN PRIVATE KEY-----
MIGHAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBG0wawIBAQQgevZzL1gdAFr88hb2
OF/2NxApJCzGCEDdfSp6VQO30hyhRANCAAQRWz+jn65BtOMvdyHKcvjBeBSDZH2r
1RTwjmYSi9R/zpBnuQ4EiMnCqfMPWiZqB4QdbAd0E7oH50VpuZ1P087G
-----END PRIVATE KEY-----";
        String pubKey = @"-----BEGIN PUBLIC KEY-----
MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEEVs/o5+uQbTjL3chynL4wXgUg2R9
q9UU8I5mEovUf86QZ7kOBIjJwqnzD1omageEHWwHdBO6B+dFabmdT9POxg==
-----END PUBLIC KEY-----";

        [Theory]
        [InlineData(256)]
        [InlineData(384)]
        [InlineData(521)]
        public void GenerateKey(Int32 keySize)
        {
            var ks = ECDsaHelper.GenerateKey(keySize);
            Assert.NotNull(ks);
            Assert.Equal(2, ks.Length);

            var dsa = new ECDsaCng(CngKey.Import(ks[0].ToBase64(), CngKeyBlobFormat.EccPrivateBlob));
            var dsa2 = new ECDsaCng(CngKey.Import(ks[1].ToBase64(), CngKeyBlobFormat.EccPublicBlob));
        }

        [Fact]
        public void Create()
        {
            var ks = ECDsaHelper.GenerateKey();

            var ec = ECDsaHelper.Create(ks[0]);
            Assert.NotNull(ec);

            //var ec2 = ECDsaHelper.Create(prvKey);
            //Assert.NotNull(ec2);

            //var ec3 = ECDsaHelper.Create(pubKey);
            //Assert.NotNull(ec3);
        }

        [Fact]
        public void SignAndVerify()
        {
            var ks = ECDsaHelper.GenerateKey(256);

            var data = Rand.NextBytes(1000);

            {
                var sign = ECDsaHelper.Sign(data, ks[0]);
                Assert.NotNull(sign);

                var rs = ECDsaHelper.Verify(data, ks[1], sign);
                Assert.True(rs);
            }

            {
                var sign = ECDsaHelper.SignSha256(data, ks[0]);
                Assert.NotNull(sign);

                var rs = ECDsaHelper.VerifySha256(data, ks[1], sign);
                Assert.True(rs);
            }

            {
                var sign = ECDsaHelper.SignSha384(data, ks[0]);
                Assert.NotNull(sign);

                var rs = ECDsaHelper.VerifySha384(data, ks[1], sign);
                Assert.True(rs);
            }

            {
                var sign = ECDsaHelper.SignSha512(data, ks[0]);
                Assert.NotNull(sign);

                var rs = ECDsaHelper.VerifySha512(data, ks[1], sign);
                Assert.True(rs);
            }
        }

        [Fact]
        public void TestPublicPem()
        {
            var p = ECDsaHelper.ReadPem(pubKey);
            var rsa = new ECDsaCng();
            //rsa.ImportParameters(p);

            var key = rsa.ToXmlString(false);
            Assert.Equal("<RSAKeyValue><Modulus>6bA6/luOWhRyJL6LWWhiv0x5RRabmX1LYIYVpBwJtx+8ry+NieMR606+iHlAwpeHinuqoiIL2EjaC97uEhERjnmJldRfnKHLvSDBpzaInG4dc1VunvP4hk98WmEIsyaFblgP0wv83XbNooQiXxwwQ7KLjgl3nD2qclghkDbB+bE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>", key);

            //var rs = rsa.VerifyData("NewLife".GetBytes(), MD5.Create(), "WfMouV+yZ0EmATNiFVsgMIsMzx1sS7zSKcOZ1FmSiUnkq7nB4wEKcketdakn859/pTWZ31l8XF1+GelhdNHjwjuQmsawdTW+imnn5Z1J+XzhNgxdnpJ6O1txcE8oHKCTd2bS2Yv55Mezu4Ih9BbX0JovSnFCsGMxLS6afYQqXUU=".ToBase64());
            //Assert.True(rs);
        }

        [Fact]
        public void TestPrivatePem()
        {
            var p = ECDsaHelper.ReadPem(prvKey);
            var rsa = new ECDsaCng();
            //rsa.ImportParameters(p);

            var key = rsa.ToXmlString(true);
            Assert.Equal("<RSAKeyValue><Modulus>6bA6/luOWhRyJL6LWWhiv0x5RRabmX1LYIYVpBwJtx+8ry+NieMR606+iHlAwpeHinuqoiIL2EjaC97uEhERjnmJldRfnKHLvSDBpzaInG4dc1VunvP4hk98WmEIsyaFblgP0wv83XbNooQiXxwwQ7KLjgl3nD2qclghkDbB+bE=</Modulus><Exponent>AQAB</Exponent><P>/flrxJSy1Z+nY1RPgDOeDqyG6MhwU1Jl0yJ1sw3Or4qGRXhjTeGsCrKqV0/ajqdkDEM7FNkqnmsB+vPd116J6w==</P><Q>641jeg5a/LZ9DfaaPpdX5La9wbWiwRRoS5a8SCQaon1yjrXTRCmPXnTfoBAQQOpuN2pLRKF95FLB69Mlkhqn0w==</Q><DP>J4wYMOMqucMDkJ8HRiJDgWtyEntrqj3RZ0AdbcU/ouwCHn0xkWYLoRrTFYd0s/Pyy0oIwCVU0pg9FbO1npy1Aw==</DP><DQ>vIlm3gMvgKbwYYTI4OByUXaTW8DujGyxLg9wlK2RRA3065VNjHlXb9tMQumYmN0Lav+BT2WTRnWXEhLnN5JuUQ==</DQ><InverseQ>KRpGZlnrTcAyTHFCW0ga0DBX60Dm6jDwT3voBJ4kKk7cLtTlCx5ZlIPXlt9cESNrol3BQiTB7q6OojkNVSeELA==</InverseQ><D>z8lsWzjLlZsydyuaOlCP5Ss5dU4J4uu+tz/iRD7OAK9OlbLBtoZaK5Gj5zNxetVDpsYZTfrZ72Gvx/hcVWIp6YMvhKYluBINrUrvWL78uefMXqyOIMEVD+MD1Irg9itjtrciR4FCcmaSdqfKS6DJDXGYKNu6Hnnp855E9oeeHHU=</D></RSAKeyValue>", key);

            //var sign = rsa.SignData("NewLife".GetBytes(), MD5.Create());
            //Assert.Equal("WfMouV+yZ0EmATNiFVsgMIsMzx1sS7zSKcOZ1FmSiUnkq7nB4wEKcketdakn859/pTWZ31l8XF1+GelhdNHjwjuQmsawdTW+imnn5Z1J+XzhNgxdnpJ6O1txcE8oHKCTd2bS2Yv55Mezu4Ih9BbX0JovSnFCsGMxLS6afYQqXUU=", sign.ToBase64());
        }
    }
}