using HashidsNet;
using Microsoft.Extensions.Options;
using System;
using URLShortener.Common.ErrorTypes;
using URLShortener.Common.Exceptions;
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
            if (string.IsNullOrEmpty(encryptedId))
                throw new BusinessException<CommonErrorType>(CommonErrorType.NullArguments);

            encryptedId = encryptedId?.Trim();

            int[] result;
            try
            {
                result = hashids.Decode(encryptedId);
            }
            catch (Exception)
            {

                throw new BusinessException<EncryptionErrorType>(EncryptionErrorType.ErrorInDecryption);
            }


            if (result == null || result.Length != 1)
                throw new BusinessException<EncryptionErrorType>(EncryptionErrorType.ErrorInDecryption);

            return result[0];

        }

        public string Encrypt(long id)
        {
            string encryptedId;
            try
            {
                encryptedId = hashids.EncodeLong(id);
            }
            catch (Exception)
            {

                throw new BusinessException<EncryptionErrorType>(EncryptionErrorType.ErrorInEncryption);
            }

            return encryptedId;
        }
    }
}
