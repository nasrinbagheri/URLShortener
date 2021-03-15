using HashidsNet;
using Microsoft.Extensions.Options;
using System;
using URLShortener.Encryption.Contracts;

namespace URLShortener.Encryption
{
    public class HashIdService : IHashIdService
    {
        private readonly Hashids hashids;
        public HashIdService(IOptions<HashIdOptions> option)
        {
            var hashIdOption = option.Value;
            hashids = new Hashids(hashIdOption.Salt, hashIdOption.MinLength, hashIdOption.Alphabet);
        }

        public long Decrypt(string encryptedId)
        {
            encryptedId = encryptedId?.Trim();
            //todo:if (string.IsNullOrEmpty(encryptedId))

            var result = hashids.Decode(encryptedId);

            //todo: if (result.Length != 1)

            return result[0];

        }

        public string Encrypt(long id)
        {
            var encryptedId = hashids.EncodeLong(id);
            return encryptedId;
        }
    }
}
