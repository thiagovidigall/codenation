using System;
using Xunit;

namespace Codenation.Challenge
{
    public class CesarCypherTest
    {
        [Fact]
        public void Should_Not_Accept_Null_When_Crypt()
        {            
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentNullException>(() => cypher.Crypt(null));
        }

        [Fact]
        public void Should_Keep_Numbers_Out_When_Crypt()
        {
            var cypher = new CesarCypher();
            // Assert.Equal("d1e2f3g4h5i6j7k8l9m0", cypher.Crypt("a1b2c3d4e5f6g7h8i9j0"));
            Assert.Equal("wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj", cypher.Crypt("the quick brown fox jumps over the lazy dog"));
        }

        [Fact]
        public void Should_Keep_Numbers_Out_When_Decrypt()
        {
            var cypher = new CesarCypher();
            //Assert.Equal("a1b2c3d4e5f6g7h8i9j0", cypher.Decrypt("d1e2f3g4h5i6j7k8l9m0"));
            Assert.Equal("the quick brown fox jumps over the lazy dog", cypher.Decrypt("wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj"));
        }

    }
}
