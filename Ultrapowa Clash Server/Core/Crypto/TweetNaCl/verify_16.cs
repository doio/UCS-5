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

namespace UCS.Core.Crypto.TweetNaCl
{
    public class verify_16
    {
        internal readonly int crypto_verify_16_ref_BYTES = 16;

        public static int crypto_verify(byte[] x, int xoffset, byte[] y)
        {
            int differentbits = 0;

            for (int i = 0; i < 15; i++)
            {
                differentbits |= ((int) (x[xoffset + i] ^ y[i])) & 0xff;
            }

            return (1 & ((int) ((uint) ((int) differentbits - 1) >> 8))) - 1;
        }
    }
}