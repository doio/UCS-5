/*
 * Program : Ultrapowa Clash Server
 * Description : A C# Writted 'Clash of Clans' Server Emulator !
 *
 * Authors:  Jean-Baptiste Martin <Ultrapowa at Ultrapowa.com>,
 *           And the Official Ultrapowa Developement Team
 *
 * Copyright (c) 2016  UltraPowa
 * All Rights Reserved.
 */

using System;
using UCS.Core.Crypto.TweetNaCl;

namespace UCS.Core.Crypto.CustomNaCl
{
    public class PublicBox
    {
        const int KEYBYTES = 32;
        const int NONCEBYTES = 24;
        const int ZEROBYTES = 32;
        const int BOXZEROBYTES = 16;
        const int BEFORENMBYTES = 32;

        byte[] PrecomputedSharedKey = new byte[BEFORENMBYTES];

        public PublicBox(byte[] privatekey, byte[] publickey)
        {
            // generate a precomputed sharedkey, enhances performance drastically
            curve25519xsalsa20poly1305.crypto_box_beforenm(this.PrecomputedSharedKey, publickey, privatekey);
        }

        public byte[] create(byte[] plain, byte[] nonce)
        {
            int plainLength = plain.Length;
            byte[] paddedbuffer = new byte[plainLength + ZEROBYTES];
            Array.Copy(plain, 0, paddedbuffer, ZEROBYTES, plainLength);

            if (curve25519xsalsa20poly1305.crypto_box_afternm(paddedbuffer, paddedbuffer, paddedbuffer.Length, nonce, this.PrecomputedSharedKey) != 0)
                throw new Exception("PublicBox Encryption failed");

            byte[] output = new byte[plainLength + BOXZEROBYTES];
            Array.Copy(paddedbuffer, ZEROBYTES - BOXZEROBYTES, output, 0, output.Length);
            return output;
        }

        public byte[] open(byte[] cipher, byte[] nonce)
        {
            int cipherLength = cipher.Length;
            byte[] paddedbuffer = new byte[cipherLength + BOXZEROBYTES];
            Array.Copy(cipher, 0, paddedbuffer, BOXZEROBYTES, cipherLength);

            if (curve25519xsalsa20poly1305.crypto_box_afternm(paddedbuffer, paddedbuffer, paddedbuffer.Length, nonce, this.PrecomputedSharedKey) != 0)
                throw new Exception("PublicBox Decryption failed");

            byte[] output = new byte[paddedbuffer.Length - ZEROBYTES];
            Array.Copy(paddedbuffer, ZEROBYTES, output, 0, output.Length);
            return output;
        }
    }
}