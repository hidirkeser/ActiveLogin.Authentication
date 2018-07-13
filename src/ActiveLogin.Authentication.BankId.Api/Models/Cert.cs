﻿using System;
using System.Runtime.Serialization;

namespace ActiveLogin.Authentication.BankId.Api.Models
{
    [DataContract]
    public class Cert
    {
        [DataMember(Name = "notBefore")]
        private string notBefore { get; set; }
        public DateTime NotBefore => ParseUnixTimestampMillis(notBefore);

        [DataMember(Name = "notAfter")]
        private string notAfter { get; set; }
        public DateTime NotAfter => ParseUnixTimestampMillis(notAfter);


        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private static DateTime ParseUnixTimestampMillis(string milliseconds)
        {
            return DateTimeFromUnixTimestampMillis(long.Parse(milliseconds));
        }

        private static DateTime DateTimeFromUnixTimestampMillis(long milliseconds)
        {
            return UnixEpoch.AddMilliseconds(milliseconds);
        }
    }
}